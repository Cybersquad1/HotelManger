using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using HotelModels;
using HotelLogic;

namespace HotelManger
{
    public partial class CustManageForm : Form
    {
        public CustManageForm()
        {
            InitializeComponent();
            LoadCust();
        }

        List<CustManageModel> list = null;

        private void LoadCust()
        {
            list = CustManager.GetModelList();

            CustList.Rows.Clear();

            int index = 0;

            for (int i = 0; i < list.Count; i++)
            {
                index = CustList.Rows.Add();
                CustList.Rows[index].Cells[0].Value = list[i].Name;
                CustList.Rows[index].Cells[1].Value = list[i].IDNumber;
                CustList.Rows[index].Cells[2].Value = list[i].CustDegree.Trim();
                CustList.Rows[index].Cells[3].Value = list[i].Money;
                CustList.Rows[index].Cells[4].Value = list[i].CheckCount;
                CustList.Rows[index].Cells[5].Value = list[i].CustStatus;
            }
        }

        private void RefreshList_Click(object sender, EventArgs e)
        {
            LoadCust();
        }

        private void Query_Click(object sender, EventArgs e)
        {
            if(QueryType.Text==""||QueryValue.Text=="")
            {
                MessageBox.Show("请填写完整后再尝试搜索！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int a = -1;
            if (QueryType.SelectedIndex == 3 || QueryType.SelectedIndex == 4)
            {
                try
                {
                    a = Convert.ToInt32(QueryValue.Text);
                }
                catch
                {
                    MessageBox.Show("输入的内容不是数字，请重新输入后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            CustList.Rows.Clear();

            //姓名
            //身份证号
            //用户级别
            //总消费
            //入住次数
            //客户状态

            int index = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (QueryType.SelectedIndex == 0)
                {
                    if (QueryValue.Text != list[i].Name)
                    {
                        continue;
                    }
                }
                else if (QueryType.SelectedIndex == 1)
                {
                    if (QueryValue.Text != list[i].IDNumber)
                    {
                        continue;
                    }
                }
                else if (QueryType.SelectedIndex == 2)
                {
                    if (QueryValue.Text != list[i].CustDegree.Trim())
                    {
                        continue;
                    }
                }
                else if (QueryType.SelectedIndex == 3)
                {
                    if (a != list[i].Money)
                    {
                        continue;
                    }
                }
                else if (QueryType.SelectedIndex == 4)
                {
                    if (a != list[i].CheckCount)
                    {
                        continue;
                    }
                }
                else if (QueryType.SelectedIndex == 5)
                {
                    if(QueryValue.Text!=list[i].CustStatus)
                    {
                        continue;
                    }
                }

                index = CustList.Rows.Add();
                CustList.Rows[index].Cells[0].Value = list[i].Name;
                CustList.Rows[index].Cells[1].Value = list[i].IDNumber;
                CustList.Rows[index].Cells[2].Value = list[i].CustDegree;
                CustList.Rows[index].Cells[3].Value = list[i].Money;
                CustList.Rows[index].Cells[4].Value = list[i].CheckCount;
                CustList.Rows[index].Cells[5].Value = list[i].CustStatus;
            }
        }

        private void ManageMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ManageMenu.SelectedIndex != 2)
            {
                return;
            }

            List<string> degreelist = CustManager.GetDegreeList();

            NewCustDegree.Items.Clear();

            foreach(string i in degreelist)
            {
                NewCustDegree.Items.Add(i);
            }
        }

        private void ChangeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangeType.SelectedIndex == 1 || ChangeType.SelectedIndex == 4)
            {
                SelectType.Items.Clear();
                List<string> lists = null;

                if (ChangeType.SelectedIndex == 1)
                {
                    lists = CustManager.GetDegreeList();
                }
                else
                {
                    lists = CustManager.GetStatusList();
                }

                foreach(string i in lists)
                {
                    SelectType.Items.Add(i);
                }

                SelectType.Visible = true;
            }
            else
            {
                SelectType.Visible = false;
            }
        }

        private void Change_Click(object sender, EventArgs e)
        {
            int statuscode = -2;
            int roomid = 0;
            int index = -99;
            int a = -1000;

            if (ChangeType.Text == "" || SelectType.Text == "" && SelectType.Visible == true || ChangeValue.Text == "" && SelectType.Visible == false)
            {
                MessageBox.Show("请将选项填写完整后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CustList.SelectedRows.Count != 1)
            {
                MessageBox.Show("请仅选择一行记录后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            roomid = RoomManger.FindRoomIDByName(CustList.SelectedRows[0].Cells[0].Value.ToString());

            index = ChangeType.SelectedIndex;

            if(index==2||index==3)
            {
                try
                {
                    a = Convert.ToInt32(ChangeValue.Text);
                }
                catch
                {
                    MessageBox.Show("输入值为非数字，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //姓名
            //用户级别
            //总消费
            //入住次数
            //客户状态

            string IDNumber=CustList.SelectedRows[0].Cells[1].Value.ToString();

            switch (index)
            {
                case 0:
                    statuscode=CustManager.ChangeCustValue(IDNumber, ChangeValue.Text, "", -1, -1, "", 1);
                    break;
                case 1:
                    statuscode = CustManager.ChangeCustValue(IDNumber, "", SelectType.Text, -1, -1, "", 2);
                    break;
                case 2:
                    statuscode = CustManager.ChangeCustValue(IDNumber, "", "", a, -1, "", 3);
                    break;
                case 3:
                    statuscode = CustManager.ChangeCustValue(IDNumber, "", "", -1, a, "", 4);
                    break;
                case 4:
                    statuscode = CustManager.ChangeCustValue(IDNumber, "", "", -1, -1, SelectType.Text, 5);
                    break;
            }

            if (statuscode == 1)
            {
                MessageBox.Show("修改成功！请切换至信息刷新选项卡刷新列表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("出现异常修改失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ChangeType.Text = null;
            SelectType.Text = null;
            ChangeValue.Text = "";
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Regex idnumber = new Regex("[1-9][0-9]{16}[0-9Xx]", RegexOptions.Singleline);

            if (NewCustDegree.Text == "" || NewCustID.Text == "" || NewCustName.Text == "")
            {
                MessageBox.Show("请输入完整后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (idnumber.IsMatch(NewCustID.Text) == false || NewCustID.Text.Length != 18) 
            {
                MessageBox.Show("身份证号码不合法，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int statuscode = CustManager.AddNewCust(NewCustName.Text, NewCustID.Text,NewCustDegree.Text);

            if(statuscode==1)
            {
                MessageBox.Show("添加成功！请切换至信息刷新选项卡刷新列表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(statuscode==-1)
            {
                MessageBox.Show("由于已经存在相同身份证号故添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("出现异常修改失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            NewCustDegree.Text = null;
            NewCustID.Text = "";
            NewCustName.Text = "";
        }

        private void DeleteCust_Click(object sender, EventArgs e)
        {
            if (CustList.SelectedRows.Count != 1)
            {
                MessageBox.Show("请仅选择一条记录后再尝试删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("确认删除选中记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                MessageBox.Show("删除过程取消！", "结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string idnumber=CustList.SelectedRows[0].Cells[1].Value.ToString();

            int statuscode = CustManager.DeleteCust(idnumber);

            if (statuscode == 1)
            {
                MessageBox.Show("删除成功，请刷新信息后查看！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("出现错误，请稍候尝试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
