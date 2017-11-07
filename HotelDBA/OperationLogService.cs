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
    /// 在数据访问层提供对操作日志表的访问支持
    /// </summary>
    public class OperationLogService
    {
        /// <summary>
        /// 获取所有操作日志对象
        /// </summary>
        /// <returns>返回对象列表</returns>
        public static List<OperationLog> GetAllOperationLog()
        {
            List<OperationLog> list = new List<OperationLog>();

            string sqlstr = "select LogID,OperModel,OperEvent,OperatorID,Description,OperTime from OperationLog";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while (reader.Read())
            {
                OperationLog node = new OperationLog();
                node.LogID = Convert.ToInt32(reader[0]);
                node.OperModel = Convert.ToInt32(reader[1]);
                node.OperEvent = Convert.ToInt32(reader[2]);
                node.OperatorID = Convert.ToInt32(reader[3]);
                node.OperDescription = reader[4].ToString();
                node.OperTime = Convert.ToDateTime(reader[5]);
                /*shorttime不带秒数,如12:19 
                 * longtime带秒数，如12:19:11 
                 * shortdate为日期简写形式 如2017/11/7 
                 * longdate为日期完整形式 如2017年11月7日*/
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过操作日志描述查找操作日志对象，支持模糊查找
        /// </summary>
        /// <param name="keyword">需要查找的关键词</param>
        /// <param name="FuzzyMode">模糊查找模式，true为开启，false为关闭【推荐开启】</param>
        /// <returns>返回对象列表</returns>
        public static List<OperationLog> FindOperationLogListByKeyword(string keyword, bool FuzzyMode)
        {
            List<OperationLog> list = new List<OperationLog>();

            string FindStr = "";

            if (FuzzyMode == true)
            {
                FindStr = " like ";
            }
            else
            {
                FindStr = " = ";
            }

            string sqlstr = "SELECT LogID,OperModel,OperEvent,OperatorID,Description,OperTime from OperationLog where Description" + FindStr + "@SearchName";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@SearchName",SqlDbType.VarChar)
            };

            if (FuzzyMode == true)
            {
                para[0].Value = "%" + keyword + "%";
            }
            else
            {
                para[0].Value = keyword;
            }

            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr, para);

            while (reader.Read())
            {
                OperationLog node = new OperationLog();
                node.LogID = Convert.ToInt32(reader[0]);
                node.OperModel = Convert.ToInt32(reader[1]);
                node.OperEvent = Convert.ToInt32(reader[2]);
                node.OperatorID = Convert.ToInt32(reader[3]);
                node.OperDescription = reader[4].ToString();
                node.OperTime = Convert.ToDateTime(reader[5]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }
    }
}
