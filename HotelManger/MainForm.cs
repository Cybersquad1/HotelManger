using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using HotelDBA;
using HotelModels;

namespace HotelManger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //通过ID查询
            //ModelType i = ModelTypeService.FindModelTypeByID(Convert.ToInt32(textBox1.Text));

            //MessageBox.Show("ID:" + Convert.ToString(i.ModelID) + " Name:" + i.ModelName);

            //获取所有对象
            //List<Room> list;

            //list = RoomService.GetRoomList();

            //string str = "";

            //foreach (Room i in list)
            //{
            //    str += i.RoomID.ToString() + " " + i.RoomNumber + " " + i.RoomTypeID + " " + i.RoomStatus + " " + i.Description + " " + i.NumOfBeds.ToString() + " " + i.NumOfCust.ToString() + "\r\n";
            //}

            //MessageBox.Show(str);

            ///通过关键字查询
            //List<CustDegree> list;

            //list = CustDegreeService.FindCustDegreeByKeyword(textBox1.Text, true);
            //string str = "";

            //foreach (CustDegree i in list)
            //{
            //    str += "ID:" + Convert.ToString(i.DegreeID) + " Name:" + i.DegreeName + " RoomDiscount:" + i.RoomDiscount + " PledgeCashDisCount:" + Convert.ToString(i.PledgeCashDisCount) + " TotalMoneyLimit:" + Convert.ToString(i.TotalMoneyLimit) + " RoomCheck:" + Convert.ToString(i.RoomCheck) + " FreeBreakfast:" + Convert.ToString(i.FreeBreakfast) + "\r\n";
            //}

            //MessageBox.Show(str);

            //新增项目
            //MessageBox.Show(Convert.ToString(CustDegreeService.AddNewCustStatus("金卡会员", 0.90, 0, 3000, true, true)));
            //MessageBox.Show(Convert.ToString(CustDegreeService.AddNewCustStatus("金卡会员", 0.90, 0, 3000, true, true)));
            //CustDegree i = CustDegreeService.FindCustDegreeByID(Convert.ToInt32(3));

            //MessageBox.Show("ID:" + Convert.ToString(i.DegreeID) + " Name:" + i.DegreeName + " RoomDiscount:" + i.RoomDiscount + " PledgeCashDisCount:" + Convert.ToString(i.PledgeCashDisCount) + " TotalMoneyLimit:" + Convert.ToString(i.TotalMoneyLimit) + " RoomCheck:" + Convert.ToString(i.RoomCheck) + " FreeBreakfast:" + Convert.ToString(i.FreeBreakfast));
            //CustDegreeService.AddNewCustStatus("金卡会员", 0.90, 0, 3000, true, true);

            //修改项目内容
            //MessageBox.Show(Convert.ToString(CustStatusService.ChangeStatusName("已入住", 3)));
            //MessageBox.Show(Convert.ToString(CustStatusService.ChangeStatusName("已入住", 5)));

            //删除项目
            //CustStatusService.AddNewCustStatus("正在入住");

            //CustStatus node = CustStatusService.FindCustStatusByID(4);

            //MessageBox.Show("ID:" + Convert.ToString(node.StatusID) + " Name:" + node.StatusName);

            //MessageBox.Show(Convert.ToString(CustStatusService.DeleteStatusName(4)));

            //node = CustStatusService.FindCustStatusByID(4);

            //MessageBox.Show("ID:" + Convert.ToString(node.StatusID) + " Name:" + node.StatusName);

            //MessageBox.Show(CheckInLogService.AddNewCheckInLog(1, 1, Convert.ToDateTime("2017-1-1 10:00:00"), Convert.ToDateTime("2017-2-1 10:00:00"), 200, 80, 500, 1).ToString());



            MessageBox.Show(CheckInLogService.DeleteCheckInLog(8).ToString());

                List<CheckInLog> list = CheckInLogService.GetCheckInLogByIDorCust(8, Convert.ToInt32(textBox1.Text), 1);

            for (int i = 0; i < list.Count; i++)
            {
                MessageBox.Show(list[i].CheckInID.ToString() + " " + list[i].CustomerID.ToString() + " " + list[i].RoomID.ToString() + " " + list[i].CheckInDate.ToString() + " " + list[i].CheckOutDate.ToString() + " FinalDate:" + list[i].FinalOutDate.ToString() + " " + list[i].PledgeCash.ToString() + " " + list[i].RoomPrice.ToString() + " " + list[i].ReceiveMoney.ToString() + " " + list[i].FinalPrice.ToString() + " " + list[i].ReturnMoney.ToString() + " " + list[i].StatusID.ToString());
            }
        }

    }
}
