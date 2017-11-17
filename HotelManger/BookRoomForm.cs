using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelLogic;
using HotelModels;
using System.Text.RegularExpressions;

namespace HotelManger
{
    public partial class BookRoom : Form
    {
        public struct Infos
        {
            public string Name;
            public string IDNumber;
        }

        int maxcust = -1;//最大人数
        int Price = -1;
        int index = 0;
        List<Infos> InfoList = new List<Infos>();
        
        Regex idnumber = new Regex("[1-9][0-9]{16}[0-9Xx]", RegexOptions.Singleline);

        public BookRoom(Room i)
        {
            InitializeComponent();
            maxcust = i.NumOfCust;
            Price = RoomManger.GetRoomPrice(i.RoomTypeID);
            RoomNumber.Text = i.RoomNumber;
            RoomType.Text = RoomManger.GetRoomTypeName(i.RoomTypeID);
            bedNum.Text = i.NumOfBeds.ToString();
            MaxCustNum.Text = i.NumOfCust.ToString();
            RoomDesc.Text = i.Description;
            RoomPrice.Text = Price.ToString();
            this.Text = RoomNumber.Text.Trim() + "信息登记";
            LoadStatus();
        }

        private bool IsChecked(string name,string IDNumber)
        {
            foreach(Infos i in InfoList)
            {
                if(i.IDNumber==IDNumber&&i.Name==name)
                {
                    return false;
                }
            }

            return true;
        }

        private void LoadStatus()
        {
            List<string> list = RoomManger.GetRoomStatusList();

            RoomStatus.Items.Clear();

            foreach(string i in list)
            {
                RoomStatus.Items.Add(i);
            }
        }

        private bool CheckIdientNumber(string idnumbers)
        {
            if(idnumbers.Length!=18||idnumber.IsMatch(idnumbers)==false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void BookRoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private bool CheckIdent()
        {
            DateTime begin = Convert.ToDateTime(CheckInTime.Value);
            DateTime end = Convert.ToDateTime(CheckOutTime.Value);

            if(end<=begin)
            {
                return false;
            }

            return true;
        }

        private void RefreshList()
        {
            CustInfo.Rows.Clear();
            int index = 0;
            foreach(Infos i in InfoList)
            {
                index = CustInfo.Rows.Add();
                CustInfo.Rows[index].Cells[0].Value = i.Name;
                CustInfo.Rows[index].Cells[1].Value = i.IDNumber;
            }
        }

        private void CustCheckIn_Click(object sender, EventArgs e)
        {
            if(CustName.Text==""||CustIDNumber.Text==""||RoomStatus.Text=="")
            {
                MessageBox.Show("请填写完信息后重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(CheckIdientNumber(CustIDNumber.Text)==false)
            {
                MessageBox.Show("身份证号码不合法！请重新填写！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(InfoList.Count==maxcust)
            {
                MessageBox.Show("添加人数超过上限，无法添加。请删除记录后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(CustManager.GetCustIDByIDNumber(CustIDNumber.Text)==-1)
            {
                //添加新用户
                int status=CustManager.AddNewCust(CustName.Text, CustIDNumber.Text, "");
                if(status==1)
                {
                    MessageBox.Show("新用户添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("无法添加新用户，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                //验证用户的身份证号码和姓名是否匹配
                if(CustManager.IsNameBelongToIDNumber(CustIDNumber.Text,CustName.Text)==false)
                {
                    MessageBox.Show("输入内容与记录不符！请重新填写！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if(IsChecked(CustName.Text,CustIDNumber.Text)==false)
                {
                    MessageBox.Show("请勿重复添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Infos node = new Infos();
            node.IDNumber = CustIDNumber.Text;
            node.Name = CustName.Text;
            InfoList.Add(node);

            RefreshList();
        }

        private void DeleteInfo_Click(object sender, EventArgs e)
        {
            if(CustInfo.SelectedRows.Count!=1)
            {
                MessageBox.Show("请仅选择一条记录后再尝试删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InfoList.RemoveAt(CustInfo.SelectedRows[0].Index);

            RefreshList();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            InfoList.Clear();

            RefreshList();
        }

        private int CaluDay()
        {
            int day = 1;

            DateTime begin = Convert.ToDateTime(CheckInTime.Value);
            DateTime end = Convert.ToDateTime(CheckOutTime.Value);

            day = (end - begin).Days == 0 ? 1 : (end - begin).Days;

            return day;
        }

        private void BookIn_Click(object sender, EventArgs e)
        {
            int a=-1;
            int days = 1;
            string GiveFeeID = "";

            if(Cash.Text=="")
            {
                MessageBox.Show("请填写押金后再试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(CheckIdent()==false)
            {
                MessageBox.Show("退房时间不能早于入住时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(InfoList.Count==0)
            {
                MessageBox.Show("请添加旅客信息后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(CustManager.IsFree(CustIDNumber.Text)==false)
            {
                MessageBox.Show("旅客当前已入住，无法登记！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            days = CaluDay();

            try
            {
                a=Convert.ToInt32(Cash.Text);
            }
            catch
            {
                MessageBox.Show("输入的押金不是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double finalprice = 1;
            int CashBound = 1;

            foreach(Infos i in InfoList)
            {
                double count=CustManager.GetDegreeDisCount(i.IDNumber);
                if (finalprice > count)
                {
                    finalprice = count;
                    GiveFeeID = i.IDNumber;
                }
                if (CustManager.IsFreeCash(i.IDNumber) == true && CustManager.GetDegreeDisCount(i.IDNumber)<=finalprice)
                {
                    CashBound = 0;
                }
            }

            string messages = "登记信息如下\r\n" +
                "==========================\r\n";

            for (int i = 1; i <= InfoList.Count; i++)
            {
                messages += "顾客" + i.ToString() + ":" + InfoList[i - 1].Name + "\r\n";
            }

            messages += "==========================\r\n";

            messages += "应收押金：" + (CashBound * a).ToString() + "\r\n";
            messages += "应收房费：" + (finalprice*Price*days).ToString() + "\r\n";

            messages += "==========================\r\n";

            messages += "请确认信息无误后选择“是”\r\n";

            DialogResult result=MessageBox.Show(messages, "信息确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if(result==DialogResult.No)
            {
                return;
            }
            else
            {
                foreach(Infos i in InfoList)
                {
                    int CustID = CustManager.GetCustIDByIDNumber(i.IDNumber);
                    int RoomID = RoomManger.FindRoomIDByName(RoomNumber.Text);
                    DateTime begin = Convert.ToDateTime(CheckInTime.Value);
                    DateTime end = Convert.ToDateTime(CheckOutTime.Value);
                    int cash = CashBound * a;
                    int price = Convert.ToInt32(finalprice * Price);
                    double recmoney = CashBound * a + finalprice * Price * days;
                    CheckInLogManager.AddNewLog(CustID, RoomID, begin, end, cash, price, recmoney, 2);
                    List<CheckInLog> loglists = CheckInLogManager.GetList(CustID);
                    CustManager.ChangeStatus(i.IDNumber, price * days, loglists[loglists.Count - 1].CheckInID);
                    CustManager.CheckInChange(i.IDNumber, loglists[loglists.Count - 1].CheckInID);
                    if(i.IDNumber==GiveFeeID)
                    {
                        CustManager.ChangeMoney(i.IDNumber, Convert.ToInt32(recmoney));
                    }
                    RoomManger.ChangeRoomValue(RoomID, "", "", -1, -1, RoomStatus.Text, "", 4);
                }

                MessageBox.Show("登记成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
