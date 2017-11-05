using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class Room
    {
        /// <summary>
        /// 房间序号
        /// </summary>
        public int RoomID { get; set; }
        /// <summary>
        /// 房间牌号
        /// </summary>
        public string RoomNumber { get; set; }
        /// <summary>
        /// 房间类型
        /// </summary>
        public int RoomTypeID { get; set; }
        /// <summary>
        /// 房间状态
        /// </summary>
        public int RoomStatus { get; set; }
        /// <summary>
        /// 房间描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 床的个数
        /// </summary>
        public int NumOfBeds { get; set; }
        /// <summary>
        /// 入住人数
        /// </summary>
        public int NumOfCust { get; set; }
    }
}
