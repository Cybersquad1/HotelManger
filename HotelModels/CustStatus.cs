using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class CustStatus
    {
        /// <summary>
        /// 状态对应的ID
        /// </summary>
        public int StatusID { get; set; }
        /// <summary>
        /// 顾客状态
        /// </summary>
        public string StatusName { get; set; }
    }
}
