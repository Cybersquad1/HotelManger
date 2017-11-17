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

        /// <summary>
        /// 通过ID查找操作日志对象
        /// </summary>
        /// <param name="TypeID">需要查找的ID</param>
        /// <returns>返回对象，如果ID为-1则为查找失败</returns>
        public static OperationLog FindOperationLogByID(int TypeID)
        {
            OperationLog node = new OperationLog();
            node.LogID = -1;

            string querystr = "SELECT LogID,OperModel,OperEvent,OperatorID,Description,OperTime from OperationLog where LogID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };
            para[0].Value = TypeID;

            SqlDataReader reader = SqlHelper.ExecuteReader(querystr, para);

            while (reader.Read())
            {
                node.LogID = Convert.ToInt32(reader[0]);
                node.OperModel = Convert.ToInt32(reader[1]);
                node.OperEvent = Convert.ToInt32(reader[2]);
                node.OperatorID = Convert.ToInt32(reader[3]);
                node.OperDescription = reader[4].ToString();
                node.OperTime = Convert.ToDateTime(reader[5]);
            }

            reader.Close();

            return node;
        }

        /// <summary>
        /// 添加新的操作日志
        /// </summary>
        /// <param name="ModelID">模块ID</param>
        /// <param name="EventID">事件ID</param>
        /// <param name="OperID">操作员ID</param>
        /// <param name="desc">描述</param>
        /// <param name="time">事件时间</param>
        /// <returns>返回1为插入成功，-100为异常</returns>
        public static int AddNewOperationLog(int ModelID,int EventID,int OperID,string desc,DateTime time)
        {
            string sqlstr = "insert into OperationLog (OperModel,OperEvent,OperatorID,Description,OperTime) VALUES (@newmodel,@newevent,@newoper,@newdesc,@newtime)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@newmodel",SqlDbType.Int),
                new SqlParameter("@newevent",SqlDbType.Int),
                new SqlParameter("@newoper",SqlDbType.Int),
                new SqlParameter("@newdesc",SqlDbType.VarChar),
                new SqlParameter("@newtime",SqlDbType.DateTime)
            };

            para[0].Value = ModelID;
            para[1].Value = EventID;
            para[2].Value = OperID;
            para[3].Value = desc;
            para[4].Value = time;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 修改操作日志信息
        /// </summary>
        /// <param name="ChangeID">需要修改的ID</param>
        /// <param name="ModelID">模块ID</param>
        /// <param name="EventID">事件ID</param>
        /// <param name="OperID">操作员ID</param>
        /// <param name="desc">描述</param>
        /// <param name="time">时间</param>
        /// <param name="type">修改类型，从1到5（自己数）</param>
        /// <returns></returns>
        public static int ChangeOperationLog(int ChangeID, int ModelID, int EventID, int OperID, string desc, DateTime time, int type)
        {
            string ChangeStr = "";
            SqlParameter ChangePara = null;
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);

            switch (type)
            {
                case 1:
                    ChangeStr = "OperModel";
                    ChangePara = new SqlParameter("@name", SqlDbType.Int);
                    ChangePara.Value = ModelID;
                    break;
                case 2:
                    ChangeStr = "OperEvent";
                    ChangePara = new SqlParameter("@name", SqlDbType.Int);
                    ChangePara.Value = EventID;
                    break;
                case 3:
                    ChangeStr = "OperatorID";
                    ChangePara = new SqlParameter("@name", SqlDbType.Int);
                    ChangePara.Value = OperID;
                    break;
                case 4:
                    ChangeStr = "Description";
                    ChangePara = new SqlParameter("@name", SqlDbType.VarChar);
                    ChangePara.Value = desc;
                    break;
                case 5:
                    ChangeStr = "OperTime";
                    ChangePara = new SqlParameter("@name", SqlDbType.DateTime);
                    ChangePara.Value = time;
                    break;
            }

            string sqlstr = "update OperationLog SET " + ChangeStr + " = @name where LogID = @ID";
            SqlParameter[] para = new SqlParameter[]
            {
                ChangePara,ID
            };
            ID.Value = ChangeID;


            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 删除日志对象
        /// </summary>
        /// <param name="LogID">需要删除的ID</param>
        /// <returns>返回1为删除成功，0为找不到ID删除失败</returns>
        public static int DeleteOperationLog(int LogID)
        {
            string sqlstr = "delete from OperationLog where LogID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = LogID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }
    }
}
