using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    /// <summary>
    /// 操作日志
    /// </summary>
    public class OperationLog
    {
        /// <summary>
        /// 日志序号，自增不可修改
        /// </summary>
        public int LogID { get; set; }
        /// <summary>
        /// 操作的区域
        /// </summary>
        public int OperModel { get; set; }
        /// <summary>
        /// 操作事件类型
        /// </summary>
        public int OperEvent { get; set; }
        /// <summary>
        /// 操作员对应ID
        /// </summary>
        public int OperatorID { get; set; }
        /// <summary>
        /// 操作描述                                    
        /// </summary>
        public string OperDescription { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperTime { get; set; }
    }
}
