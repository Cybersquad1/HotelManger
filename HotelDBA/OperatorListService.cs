using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelModels;
using DBHelper;
using System.Data.SqlClient;
using System.Data;

namespace HotelDBA
{
    /// <summary>
    /// 在数据访问层提供对操作员（职员）表的访问支持
    /// </summary>
    public class OperatorListService
    {
        public static List<OperatorList> GetAllOperatorList()
        {
            List<OperatorList> list = new List<OperatorList>();

            string sqlstr = "select OperName,AuthDegree,LogInCount,LoginAccount,Enable from OperationLog";
        }
    }
}
