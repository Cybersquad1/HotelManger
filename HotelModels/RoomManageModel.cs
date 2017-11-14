using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    /// <summary>
    /// 为界面显示方便写的节点
    /// </summary>
    public class RoomManageModel
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public int BedNum { get; set; }
        public int MaxCustNum { get; set; }
        public string RoomStatus { get; set; }
        public string Description { get; set; }
    }
}
