using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class Customer
    {
        /// <summary>
        /// 用户对应ID
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDNumber { get; set; }
        /// <summary>
        /// 用户等级
        /// </summary>
        public int DrgreeID { get; set; }
        /// <summary>
        /// 总消费
        /// </summary>
        public int TotalMoney { get; set; }
        /// <summary>
        /// 累计入住
        /// </summary>
        public int CheckInCount { get; set; }
        /// <summary>
        /// 入住日志序号列表
        /// </summary>
        public string CheckInLogIndex { get; set; }
        /// <summary>
        /// 顾客状态
        /// </summary>
        public int StatusID { get; set; }
    }
}
