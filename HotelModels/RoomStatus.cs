using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class RoomStatus
    {
        /// <summary>
        /// 房间状态对应的ID
        /// </summary>
        public int RoomStatusID { get; set; }
        /// <summary>
        /// 房间状态
        /// </summary>
        public string RoomStatusName { get; set; }
        /// <summary>
        /// 对应房间是否可删除
        /// </summary>
        public bool RoomDeleteAble { get; set; }
    }
}
