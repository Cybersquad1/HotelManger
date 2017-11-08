using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class CheckInLog
    {
        /// <summary>
        /// 入住日志序号
        /// </summary>
        public int CheckInID { get; set; }
        /// <summary>
        /// 入住用户ID
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// 房间ID
        /// </summary>
        public int RoomID { get; set; }
        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime CheckInDate { get; set; }
        /// <summary>
        /// 预计退房时间
        /// </summary>
        public DateTime CheckOutDate { get; set; }
        /// <summary>
        /// 实际退房时间
        /// </summary>
        public Nullable<DateTime> FinalOutDate { get; set; }
        /// <summary>
        /// 支付押金
        /// </summary>
        public int PledgeCash { get; set; }
        /// <summary>
        /// 房间价格
        /// </summary>
        public int RoomPrice { get; set; }
        /// <summary>
        /// 最终应收价格
        /// </summary>
        public double FinalPrice { get; set; }
        /// <summary>
        /// 实收价格
        /// </summary>
        public double ReceiveMoney { get; set; }
        /// <summary>
        /// 找零
        /// </summary>
        public double ReturnMoney { get; set; }
        /// <summary>
        /// 目前状态
        /// </summary>
        public int StatusID { get; set; }
    }
}
