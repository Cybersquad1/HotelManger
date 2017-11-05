using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class RoomType
    {
        /// <summary>
        /// 房间类型对应的ID
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 房间类型
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 房间单价
        /// </summary>
        public int TypePrice { get; set; }
    }
}
