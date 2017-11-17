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
    /// 在数据访问层提供对操作事件类型表的访问支持
    /// </summary>
    public class OperEventService
    {
        /// <summary>
        /// 获取所有的操作事件类型对象
        /// </summary>
        /// <returns>返回list</returns>
        public static List<OperEvent> GetAllEventType()
        {
            List<OperEvent> list = new List<OperEvent>();

            string sqlstr = "select EventID,EventName from OperEvent";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while (reader.Read())
            {
                OperEvent node = new OperEvent();
                node.EventID = Convert.ToInt32(reader[0]);
                node.EventName = Convert.ToString(reader[1]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过关键词搜索操作事件类型对象，支持模糊查找
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="FuzzyMode">模糊搜索模式，true为开启，false为关闭</param>
        /// <returns></returns>
        public static List<OperEvent> FindOperEventListByKeyword(string keyword, bool FuzzyMode)
        {
            List<OperEvent> list = new List<OperEvent>();

            string FindStr = "";

            if (FuzzyMode == true)
            {
                FindStr = " like ";
            }
            else
            {
                FindStr = " = ";
            }

            string sqlstr = "SELECT EventID,EventName from OperEvent where EventName" + FindStr + "@SearchName";
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
                OperEvent node = new OperEvent();
                node.EventID = Convert.ToInt32(reader[0]);
                node.EventName = Convert.ToString(reader[1]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过ID搜索对应的操作事件类型对象
        /// </summary>
        /// <param name="TypeID">需要查找的ID</param>
        /// <returns>如果返回的ID为-1为查找失败，其他情况为查找成功</returns>
        public static OperEvent FindOperEventListByID(int TypeID)
        {
            OperEvent node = new OperEvent();
            node.EventID = -1;

            string querystr = "SELECT EventID,EventName from OperEvent where EventID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };
            para[0].Value = TypeID;

            SqlDataReader reader = SqlHelper.ExecuteReader(querystr, para);

            while (reader.Read())
            {
                node.EventID = Convert.ToInt32(reader[0]);
                node.EventName = reader[1].ToString();
            }

            reader.Close();

            return node;
        }

        /// <summary>
        /// 添加新元素，如果存在相同关键词则拒绝添加
        /// </summary>
        /// <param name="eventname">新的名称</param>
        /// <returns>返回1为成功添加，返回-1为检测到重复拒绝添加，-100为异常</returns>
        public static int AddNewOperEvent(string eventname)
        {
            string sqlstr = "if not exists (select EventName from OperEvent where EventName= @newname )" +
    " insert into OperEvent (EventName) VALUES (@newname)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@newname",SqlDbType.VarChar)
            };

            para[0].Value = eventname;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 修改项目的事件名称
        /// </summary>
        /// <param name="newname">新名称</param>
        /// <param name="ID">需要修改的ID</param>
        /// <returns>返回1为修改成功，0为未找到，-100为异常</returns>
        public static int ChangeOperEventName(string newname, int ID)
        {
            string sqlstr = "update OperEvent SET EventName = @name where EventID = @ID";
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
        /// 删除指定的操作事件类型项目
        /// </summary>
        /// <param name="EventID">需要删除的ID</param>
        /// <returns>返回1为成功删除，0为找不到删除的项目，-100为异常</returns>
        public static int DeleteStatusName(int EventID)
        {
            string sqlstr = "delete from OperEvent where EventID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = EventID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }
    }
}
