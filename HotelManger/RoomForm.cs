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
using HotelDBA;
using HotelModels;

namespace HotelManger
{
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
        }

        List<Room> list = null;
        BookRoom form = null;

        private void InitTreeView()
        {
            List<string> list = RoomManger.GetRoomTypeList();

            foreach (string i in list)
            {
                RoomTypeList.Nodes.Add(i);
            }
        }

        private void Init(object sender, EventArgs e)
        {
            InitTreeView();
        }

        private void RoomTypeList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RoomsList.Items.Clear();

            list = RoomManger.GetRoomList(RoomTypeList.SelectedNode.Text);

            foreach(Room i in list)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = 0;
                lvi.Text = i.RoomNumber.Trim();
                lvi.Tag = i;
                string output = "类型：" + RoomTypeService.GetRoomType(i.RoomTypeID).TypeName + "\r\n状态：" +
                    RoomStatusService.FindStatusByID(i.RoomStatus).RoomStatusName + "\r\n描述：" + i.Description + "\r\n床数：" +
                    i.NumOfBeds.ToString() + "\r\n最大居住人数：" + i.NumOfCust.ToString();
                lvi.ToolTipText = output;
                
                RoomsList.Items.Add(lvi);
            }

            
        }

        private void RoomMenu_Opening(object sender, CancelEventArgs e)
        {
            if(RoomsList.SelectedItems.Count!=1)
            {
                BookIn.Enabled = false;
                return;
            }
            else
            {
                Room node = (Room)RoomsList.SelectedItems[0].Tag;

                if(node.RoomStatus==5)
                {
                    BookIn.Enabled = true;
                }
                else
                {
                    BookIn.Enabled = false;
                }
            }
        }

        private void BookIn_Click(object sender, EventArgs e)
        {
            if(form==null||form.IsDisposed)
            {
                form = new BookRoom((Room)RoomsList.SelectedItems[0].Tag);
                form.Show();
            }
            else
            {
                MessageBox.Show("请完成当前房间的信息登记后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.Activate();
            }
        }
    }
}
