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
            //CustDegree i = CustDegreeService.FindCustDegreeByID(Convert.ToInt32(textBox1.Text));

            //MessageBox.Show("ID:" + Convert.ToString(i.DegreeID) + " Name:" + i.DegreeName + " RoomDiscount:" + i.RoomDiscount + " PledgeCashDisCount:" + Convert.ToString(i.PledgeCashDisCount) + " TotalMoneyLimit:" + Convert.ToString(i.TotalMoneyLimit) + " RoomCheck:" + Convert.ToString(i.RoomCheck) + " FreeBreakfast:" + Convert.ToString(i.FreeBreakfast));

            //获取所有对象
            //List<CustDegree> list;

            //list = CustDegreeService.GetAllCustStatus();

            //string str = "";

            //foreach (CustDegree i in list)
            //{
            //    str += "ID:" + Convert.ToString(i.DegreeID) + " Name:" + i.DegreeName + " RoomDiscount:" + i.RoomDiscount + " PledgeCashDisCount:" + Convert.ToString(i.PledgeCashDisCount) + " TotalMoneyLimit:" + Convert.ToString(i.TotalMoneyLimit) + " RoomCheck:" + Convert.ToString(i.RoomCheck) + " FreeBreakfast:" + Convert.ToString(i.FreeBreakfast) + "\r\n";
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


            MessageBox.Show(Convert.ToString(CustDegreeService.AddNewCustStatus("像样会员", 0.90, 0, 3000, true, true)));
            ShowIt();
            MessageBox.Show(Convert.ToString(CustDegreeService.ChangeStatusName(4, "像样会员", 0.93, 0, 9999, true, true, 1)));
            ShowIt();
            MessageBox.Show(Convert.ToString(CustDegreeService.ChangeStatusName(4, "像样会员", 0.93, 0, 9999, true, true, 2)));
            ShowIt();
            MessageBox.Show(Convert.ToString(CustDegreeService.ChangeStatusName(4, "像样会员", 0.93, 0, 9999, true, true, 3)));
            ShowIt();
            MessageBox.Show(Convert.ToString(CustDegreeService.ChangeStatusName(4, "像样会员", 0.93, 0, 9999, true, true, 4)));
            ShowIt();
            MessageBox.Show(Convert.ToString(CustDegreeService.ChangeStatusName(4, "像样会员", 0.93, 0, 9999, true, true, 5)));
            ShowIt();
            MessageBox.Show(Convert.ToString(CustDegreeService.ChangeStatusName(4, "像样会员", 0.93, 0, 9999, true, true, 6)));
            ShowIt();

            MessageBox.Show(Convert.ToString(CustDegreeService.DeleteTypeFromID(4)));
            ShowIt();
        }

        private void ShowIt()
        {
            CustDegree i = CustDegreeService.FindCustDegreeByID(4);

            MessageBox.Show("ID:" + Convert.ToString(i.DegreeID) + " Name:" + i.DegreeName + " RoomDiscount:" + i.RoomDiscount + " PledgeCashDisCount:" + Convert.ToString(i.PledgeCashDisCount) + " TotalMoneyLimit:" + Convert.ToString(i.TotalMoneyLimit) + " RoomCheck:" + Convert.ToString(i.RoomCheck) + " FreeBreakfast:" + Convert.ToString(i.FreeBreakfast));
        }
    }
}
