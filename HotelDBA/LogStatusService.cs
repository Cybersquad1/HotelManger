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
    /// 在数据访问层上提供对日志状态类型表的访问支持
    /// </summary>
    public class LogStatusService
    {
        /// <summary>
        /// 获取所有日志状态类型
        /// </summary>
        /// <returns></returns>
        public static List<LogStatus> GetAllLogStatus()
        {
            List<LogStatus> list = new List<LogStatus>();

            string sqlstr = "select StatusID,StatusName from LogStatus";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while (reader.Read())
            {
                LogStatus node = new LogStatus();
                node.StatusID = Convert.ToInt32(reader[0]);
                node.StatusName = Convert.ToString(reader[1]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过关键词查找日志状态类型，支持模糊查找
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="FuzzyMode">模糊查找模式，true为开启，false为关闭</param>
        /// <returns>查询结果</returns>
        public static List<LogStatus> FindLogStatusByKeyword(string keyword,bool FuzzyMode)
        {
            List<LogStatus> list = new List<LogStatus>();

            string FindStr = "";

            if (FuzzyMode == true)
            {
                FindStr = " like ";
            }
            else
            {
                FindStr = " = ";
            }

            string sqlstr = "select StatusID,StatusName from LogStatus where StatusName" + FindStr + "@searchname";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@searchname",SqlDbType.VarChar)
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
                LogStatus node = new LogStatus();
                node.StatusID = Convert.ToInt32(reader[0]);
                node.StatusName = Convert.ToString(reader[1]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过ID查找日志状态类型
        /// </summary>
        /// <param name="ID">需要查找的ID</param>
        /// <returns>如果返回的ID为-1则查找失败</returns>
        public static LogStatus FindLogStatusByID(int ID)
        {
            LogStatus node = new LogStatus();
            node.StatusID = -1;

            string str = "select StatusID,StatusName from LogStatus where StatusID = @index";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };
            para[0].Value = ID;

            SqlDataReader reader = SqlHelper.ExecuteReader(str, para);

            while (reader.Read())
            {
                node.StatusID = Convert.ToInt32(reader[0]);
                node.StatusName = Convert.ToString(reader[1]);
            }

            reader.Close();

            return node;
        }

        /// <summary>
        /// 增加新的日志状态类型
        /// </summary>
        /// <param name="statusname">新增名</param>
        /// <returns>如果返回-1为插入失败，返回1为插入成功</returns>
        public static int AddNewLogStatus(string statusname)
        {
            string sqlstr = "if not exists (select StatusName from LogStatus where StatusName= @newname )" +
    " insert into LogStatus (StatusName) VALUES (@newname)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@newname",SqlDbType.VarChar)
            };

            para[0].Value = statusname;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 修改某个状态的名称
        /// </summary>
        /// <param name="newname">新名称</param>
        /// <param name="ID">对应的ID</param>
        /// <returns></returns>
        public static int ChangeStatusName(string newname,int ID)
        {
            string sqlstr = "update LogStatus SET StatusName = @name where StatusID = @ID";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@name",SqlDbType.VarChar),
                new SqlParameter("@ID",SqlDbType.Int)
            };

            para[0].Value = newname;
            para[1].Value = ID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 删除某个状态
        /// </summary>
        /// <param name="statusID">需要删除的ID</param>
        /// <returns>1为成功删除，0为未找到，-100为异常</returns>
        public static int DeleteStatusName(int statusID)
        {
            string sqlstr = "delete from LogStatus where StatusID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = statusID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }
    }
}
