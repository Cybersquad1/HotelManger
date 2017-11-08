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
            //RoomsList.OwnerDraw = true;
            //RoomsList.DrawSubItem+=(RoomsList_DrawSubItem);
            //RoomsList.DrawColumnHeader += (RoomsList_DrawColumnHeader);
        }

        //private void RoomsList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        //{
        //    // This is the default text alignment
        //    TextFormatFlags flags = TextFormatFlags.Left;

        //    // Align text on the right for the subitems after row 11 in the 
        //    // first column
        //    if (e.ColumnIndex == 0 && e.Item.Index < 11)
        //    {
        //        flags = TextFormatFlags.HorizontalCenter;
        //    }

        //    e.DrawText(flags);
        //}

        //// Handle DrawColumnHeader event
        //private void RoomsList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        //{
        //    // Draw the column header normally
        //    e.DrawDefault = true;
        //    e.DrawBackground();
        //    e.DrawText();
        //}

        private void RoomTypeList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RoomsList.Items.Clear();

            list = RoomManger.GetRoomList(RoomTypeList.SelectedNode.Text);

            foreach(Room i in list)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = 0;
                lvi.Text = i.RoomNumber;
                lvi.Tag = i;
                string output = "类型：" + RoomTypeService.GetRoomType(i.RoomTypeID).TypeName + "\r\n状态：" +
                    RoomStatusService.FindStatusByID(i.RoomStatus).RoomStatusName + "\r\n描述：" + i.Description + "\r\n床数：" +
                    i.NumOfBeds.ToString() + "\r\n最大居住人数：" + i.NumOfCust.ToString();
                lvi.ToolTipText = output;
                
                RoomsList.Items.Add(lvi);
            }

            
        }
    }
}
