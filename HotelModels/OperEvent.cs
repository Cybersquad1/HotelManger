using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    /// <summary>
    /// 事件类型表
    /// </summary>
    public class OperEvent
    {
        /// <summary>
        /// 事件类型对应ID
        /// </summary>
        public int EventID { get; set; }
        /// <summary>
        /// 事件类型对应名称
        /// </summary>
        public string EventName { get; set; }
    }
}
