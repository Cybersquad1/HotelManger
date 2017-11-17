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

namespace HotelManger
{
    public partial class RoomManageForm : Form
    {
        List<RoomManageModel> list = null;

        public RoomManageForm()
        {
            InitializeComponent();
            LoadDate();
        }

        private void LoadDate()
        {
            RoomList.Rows.Clear();

            list = RoomManger.GetAllModelList();

            int index = 0;

            for (int i = 0; i < list.Count; i++)
            {
                index = RoomList.Rows.Add();
                RoomList.Rows[index].Cells[0].Value = list[i].RoomName;
                RoomList.Rows[index].Cells[1].Value = list[i].RoomType;
                RoomList.Rows[index].Cells[2].Value = list[i].BedNum;
                RoomList.Rows[index].Cells[3].Value = list[i].MaxCustNum;
                RoomList.Rows[index].Cells[4].Value = list[i].RoomStatus;
                RoomList.Rows[index].Cells[5].Value = list[i].Description;
            }
        }

        private void RoomList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void Query_Click(object sender, EventArgs e)
        {
            if(QueryType.Text==null||QueryValue.Text=="")
            {
                MessageBox.Show("请填写完整后再尝试搜索！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int a = -1;
            if (QueryType.SelectedIndex == 2 || QueryType.SelectedIndex == 3)
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

            RoomList.Rows.Clear();

            int index = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (QueryType.SelectedIndex == 0)
                {
                    if (list[i].RoomName != QueryValue.Text)
                    {
                        continue;
                    }
                }
                else if (QueryType.SelectedIndex == 1)
                {
                    if (list[i].RoomType != QueryValue.Text)
                    {
                        continue;
                    }
                }
                else if (QueryType.SelectedIndex == 2)
                {
                    if (list[i].BedNum != Convert.ToInt32(QueryValue.Text))
                    {
                        continue;
                    }
                }
                else if (QueryType.SelectedIndex == 3)
                {
                    if (list[i].MaxCustNum != Convert.ToInt32(QueryValue.Text))
                    {
                        continue;
                    }
                }
                else if (QueryType.SelectedIndex == 4)
                {
                    if (list[i].RoomStatus != QueryValue.Text)
                    {
                        continue;
                    }
                }
                else if (QueryType.SelectedIndex == 5)
                {
                    if(list[i].Description.IndexOf(QueryValue.Text)==-1)
                    {
                        continue;
                    }
                }

                index = RoomList.Rows.Add();
                RoomList.Rows[index].Cells[0].Value = list[i].RoomName;
                RoomList.Rows[index].Cells[1].Value = list[i].RoomType;
                RoomList.Rows[index].Cells[2].Value = list[i].BedNum;
                RoomList.Rows[index].Cells[3].Value = list[i].MaxCustNum;
                RoomList.Rows[index].Cells[4].Value = list[i].RoomStatus;
                RoomList.Rows[index].Cells[5].Value = list[i].Description;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDate();
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
            else if(RoomList.SelectedRows.Count!=1)
            {
                MessageBox.Show("请仅选择一行记录后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            roomid = RoomManger.FindRoomIDByName(RoomList.SelectedRows[0].Cells[0].Value.ToString());

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

            //房间号
            //房间类型
            //床数
            //最大旅客数
            //房间状态
            //描述

            switch (index)
            {
                case 0:
                    statuscode = RoomManger.ChangeRoomValue(roomid, ChangeValue.Text, "", -1, -1, "", "", 0);
                    break;
                case 1:
                    statuscode = RoomManger.ChangeRoomValue(roomid, "", SelectType.Text, -1, -1, "", "", 1);
                    break;
                case 2:

                    statuscode = RoomManger.ChangeRoomValue(roomid, "", "", a, -1, "", "", 2);
                    break;
                case 3:
                    statuscode = RoomManger.ChangeRoomValue(roomid, "", "", -1, a, "", "", 3);
                    break;
                case 4:
                    statuscode = RoomManger.ChangeRoomValue(roomid, "", "", -1, -1, SelectType.Text, "", 4);
                    break;
                case 5:
                    statuscode = RoomManger.ChangeRoomValue(roomid, "", "", -1, -1, "", ChangeValue.Text, 5);
                    break;
            }

            if(statuscode==1)
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

        private void ChangeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangeType.SelectedIndex == 1)
            {
                List<string> typelist = RoomManger.GetRoomTypeList();
                SelectType.Items.Clear();
                foreach (string i in typelist)
                {
                    SelectType.Items.Add(i);
                }
                SelectType.Visible = true;
            }
            else if (ChangeType.SelectedIndex == 4)
            {
                List<string> statuslist = RoomManger.GetRoomStatusList();
                SelectType.Items.Clear();
                foreach (string i in statuslist)
                {
                    SelectType.Items.Add(i);
                }
                SelectType.Visible = true;
            }
            else
            {
                SelectType.Items.Clear();
                SelectType.Visible = false;
            }
        }

        private void OperItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OperItem.SelectedIndex != 2)
            {
                return;
            }
            NewRoomType.Items.Clear();
            NewRoomStatus.Items.Clear();
            if(OperItem.SelectedIndex==2)
            {
                List<string> typelist = RoomManger.GetRoomTypeList();
                List<string> statuslist = RoomManger.GetRoomStatusList();

                foreach(string i in typelist)
                {
                    NewRoomType.Items.Add(i);
                }

                foreach(string i in statuslist)
                {
                    NewRoomStatus.Items.Add(i);
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(NewRoomName.Text==""||NewRoomStatus.Text==""||NewRoomType.Text==""||NewNumCust.Text==""||NewBedNum.Text=="")
            {
                MessageBox.Show("请填写完毕后重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(NewRoomDesc.Text=="")
            {
                MessageBox.Show("请填写描述后再试，如果没有描述请填写“无”！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int a = 0, b = 0;

            try
            {
                a = Convert.ToInt32(NewBedNum.Text);
                b = Convert.ToInt32(NewNumCust.Text);

                if (a <= 0 || b <= 0) 
                {
                    MessageBox.Show("输入的数值不能小于等于0，请修改后重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("指定项目内输入不符合要求，请修改后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int statuscode = RoomManger.AddNewRoom(NewRoomName.Text, NewRoomType.Text, a, b, NewRoomStatus.Text, NewRoomDesc.Text);

            if (statuscode == 1)
            {
                MessageBox.Show("添加成功，请在信息刷新选项卡中刷新信息后查看！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (statuscode == -1) 
            {
                MessageBox.Show("不允许添加重复房间号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("出现问题添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DeleteRoom_Click(object sender, EventArgs e)
        {
            if (RoomList.SelectedRows.Count != 1) 
            {
                MessageBox.Show("请仅选择一条记录后再尝试删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusname = RoomList.SelectedRows[0].Cells[4].Value.ToString();

            if (RoomManger.IsRemoveable(statusname) == false)
            {
                MessageBox.Show("您选择的房间记录当前状态为："+statusname+"，暂时无法删除，请将房间进行退房操作后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;                
            }

            DialogResult result = MessageBox.Show("确认删除选中记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result==DialogResult.No)
            {
                MessageBox.Show("删除过程取消！", "结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int statuscode = RoomManger.DeleteRoom(RoomList.SelectedRows[0].Cells[0].Value.ToString());

            if(statuscode==1)
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
