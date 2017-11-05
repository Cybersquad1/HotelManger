using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    /// <summary>
    /// 登陆的员工信息
    /// </summary>
    public class OperatorList
    {
        /// <summary>
        /// 操作者ID
        /// </summary>
        public int OperID { get; set; }
        /// <summary>
        /// 操作者姓名
        /// </summary>
        public string OperName { get; set; }
        /// <summary>
        /// 权限等级对应ID
        /// </summary>
        public int AuthDegree { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        public int LogInCount { get; set; }
        /// <summary>
        /// 登陆帐号
        /// </summary>
        public string LoginAccount { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string LogInPassword { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }
    }
}
