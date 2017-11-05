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
            //CustStatus node = CustStatusService.FindCustStatusByID(Convert.ToInt32(textBox1.Text));

            //MessageBox.Show("ID:" + Convert.ToString(node.StatusID) + " Name:" + node.StatusName);

            //获取所有对象
            //List<CustStatus> list;

            //list = CustStatusService.GetAllLogStatus();

            //string str = "";

            //foreach (CustStatus i in list)
            //{
            //    str += "ID:" + Convert.ToString(i.StatusID) + " Name:" + i.StatusName + "\r\n";
            //}

            //MessageBox.Show(str);

            ///通过关键字查询
            //List<CustStatus> list;

            //list = CustStatusService.FindLogStatusByKeyword(textBox1.Text, false);
            //string str = "";

            //foreach (CustStatus i in list)
            //{
            //    str += "ID:" + Convert.ToString(i.StatusID) + " Name:" + i.StatusName + "\r\n";
            //}

            //MessageBox.Show(str);

            //新增项目
            //MessageBox.Show(Convert.ToString(CustStatusService.AddNewCustStatus("已入住")));
            //MessageBox.Show(Convert.ToString(CustStatusService.AddNewCustStatus("正在入住")));

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

        }
    }
}
