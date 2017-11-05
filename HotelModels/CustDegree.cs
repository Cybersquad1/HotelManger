using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class CustDegree
    {
        /// <summary>
        /// 用户等级对应ID
        /// </summary>
        public int DegreeID { get; set; }
        /// <summary>
        /// 用户等级
        /// </summary>
        public string DegreeName { get; set; }
        /// <summary>
        /// 房费折扣
        /// </summary>
        public double RoomDiscount { get; set; }
        /// <summary>
        /// 押金折扣，值为1或0，代表是否免押金
        /// </summary>
        public int PledgeCashDisCount { get; set; }
        /// <summary>
        /// 满足该等级的最低消费
        /// </summary>
        public int TotalMoneyLimit { get; set; }
        /// <summary>
        /// 是否拥有“免查房”权益
        /// </summary>
        public bool RoomCheck { get; set; }
        /// <summary>
        /// 是否拥有“提供免费早餐”权益
        /// </summary>
        public bool FreeBreakfast { get; set; }
    }
}
