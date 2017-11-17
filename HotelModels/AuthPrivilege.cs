using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class AuthPrivilege
    {
        /// <summary>
        /// 权限对应ID
        /// </summary>
        public int AuthID { get; set; }
        /// <summary>
        /// 权限名
        /// </summary>
        public string AuthName { get; set; }
        /// <summary>
        /// 权限等级
        /// </summary>
        public int AuthDegree { get; set; }
        /// <summary>
        /// 添加新的房间的权限
        /// </summary>
        public int AddNewRoom { get; set; }
        /// <summary>
        /// 读取房间列表的权限
        /// </summary>
        public int ReadRoom { get; set; }
        /// <summary>
        /// 修改房间信息的权限
        /// </summary>
        public int ChangeRoom { get; set; }
        /// <summary>
        /// 删除房间信息的权限
        /// </summary>
        public int DeleteRoom { get; set; }
        /// <summary>
        /// 读取房间状态的权限
        /// </summary>
        public int ReadRoomStatus { get; set; }
        /// <summary>
        /// 读取入住日志的权限
        /// </summary>
        public int ReadCheckLog { get; set; }
        /// <summary>
        /// 读取客户资料的权限
        /// </summary>
        public int ReadCust { get; set; }
        /// <summary>
        /// 修改房间状态的权限(入房退房等)
        /// </summary>
        public int ChangeRoomStatus { get; set; }
        /// <summary>
        /// 修改入住日志的权限
        /// </summary>
        public int ChangeCheckLog { get; set; }
        /// <summary>
        /// 添加客户资料的权限
        /// </summary>
        public int AddNewCust { get; set; }
        /// <summary>
        /// 修改客户资料的权限
        /// </summary>
        public int ChangeCust { get; set; }
        /// <summary>
        /// 删除客户资料的权限
        /// </summary>
        public int DeleteCust { get; set; }
        /// <summary>
        /// 删除入住日志的权限
        /// </summary>
        public int DeleteCheckLog { get; set; }
        /// <summary>
        /// 读取操作日志的权限
        /// </summary>
        public int ReadOperLog { get; set; }
        /// <summary>
        /// 删除操作日志的权限
        /// </summary>
        public int DeleteOperLog { get; set; }
        /// <summary>
        /// 添加操作者(职工)的权限
        /// </summary>
        public int AddOperator { get; set; }
        /// <summary>
        /// 修改操作者(职工)的权限
        /// </summary>
        public int ChangeOperator { get; set; }
        /// <summary>
        /// 删除操作者(职工)的权限
        /// </summary>
        public int DeleteOperator { get; set; }
        /// <summary>
        /// 添加新权限的权限
        /// </summary>
        public int AddNewPrivilege { get; set; }
        /// <summary>
        /// 修改权限内容的权限
        /// </summary>
        public int ChangePrivilege { get; set; }
        /// <summary>
        /// 删除权限内容的权限
        /// </summary>
        public int DeletePrivilege { get; set; }
    }
}
