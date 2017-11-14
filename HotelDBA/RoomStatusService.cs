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
    /// 在数据访问层提供对房间状态类型表的访问支持
    /// </summary>
    public class RoomStatusService
    {
        /// <summary>
        /// 获取目前所有的房间状态类型列表
        /// </summary>
        /// <returns></returns>
        public static List<RoomStatus> GetAllStatus()
        {
            List<RoomStatus> list = new List<RoomStatus>();

            string sqlstr = "Select RoomStatusID,RoomStatusName,DeleteAble from RoomStatus";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while(reader.Read())
            {
                RoomStatus node = new RoomStatus();
                node.RoomStatusID = Convert.ToInt32(reader[0]);
                node.RoomStatusName = Convert.ToString(reader[1]);
                node.RoomDeleteAble = Convert.ToInt32(reader[2]) == 1 ? true : false;
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 使用关键词查找符合条件的房间状态类型
        /// </summary>
        /// <param name="name">关键词</param>
        /// <param name="FuzzyMode">模糊查找模式，true为开启，false为关闭</param>
        /// <returns>返回RoomStatus列表</returns>
        public static List<RoomStatus> FindStatusByKeyword(string name,bool FuzzyMode)
        {
            List<RoomStatus> list = new List<RoomStatus>();

            string FindStr = "";

            if (FuzzyMode == true)
            {
                FindStr = " like ";
            }
            else
            {
                FindStr = " = ";
            }

            string sqlstr = "select RoomStatusID,RoomStatusName,DeleteAble from RoomStatus where RoomStatusName" + FindStr + "@searchname";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@searchname",SqlDbType.VarChar)
            };

            if(FuzzyMode==true)
            {
                para[0].Value = "%" + name + "%";
            }
            else
            {
                para[0].Value = name;
            }

            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr, para);

            while(reader.Read())
            {
                RoomStatus node = new RoomStatus();
                node.RoomStatusID = Convert.ToInt32(reader[0]);
                node.RoomStatusName = Convert.ToString(reader[1]);
                node.RoomDeleteAble = Convert.ToInt32(reader[2]) == 1 ? true : false;
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过ID序号查找对应的房间状态类型信息
        /// </summary>
        /// <param name="ID">要查找的ID号</param>
        /// <returns>如果序号返回为-1则表示没有查找到，反之则为查找成功</returns>
        public static RoomStatus FindStatusByID(int ID)
        {
            RoomStatus node = new RoomStatus();
            node.RoomStatusID = -1;

            string str = "select RoomstatusID,RoomStatusName,DeleteAble from RoomStatus where RoomStatusID = @index";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };
            para[0].Value = ID;

            SqlDataReader reader = SqlHelper.ExecuteReader(str, para);

            while(reader.Read())
            {
                node.RoomStatusID = Convert.ToInt32(reader[0]);
                node.RoomStatusName = Convert.ToString(reader[1]);
                node.RoomDeleteAble = Convert.ToInt32(reader[2]) == 1 ? true : false;
            }

            reader.Close();

            return node;
        }

        /// <summary>
        /// 插入新的房间状态类型
        /// </summary>
        /// <param name="statusname">新名称</param>
        /// <returns>返回1为插入成功，-1为出现重复拒绝插入，-100为异常</returns>
        public static int AddNewStatus(string statusname,bool deleteadle)
        {
            string sqlstr = "if not exists (select RoomStatusName from RoomStatus where RoomStatusName= @newname )" +
                " insert into RoomStatus (RoomStatusName,DeleteAble) VALUES (@newname,@delete)";
            SqlParameter[] para=new SqlParameter[]
            {
                new SqlParameter("@newname",SqlDbType.VarChar),
                new SqlParameter("@delete",SqlDbType.Int)
            };

            para[0].Value = statusname;
            para[1].Value = deleteadle == true ? 1 : 0;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 修改当前房间状态类型的名称
        /// </summary>
        /// <param name="newname">新的名称</param>
        /// <param name="StatusID">需要修改的类型对应的ID</param>
        /// <returns>返回1为修改成功，-100为异常</returns>
        public static int ChangeStatusName(string newname,bool deleteable,int StatusID,int type)
        {
            string namestr = "update RoomStatus SET RoomStatusName = @name where RoomStatusID = @ID";
            string boolstr = "update RoomStatus SET DeleteAble = @name where RoomStatusID = @ID";
            string sqlstr = "";
            SqlParameter name = null;

            switch(type)
            {
                case 1:
                    name = new SqlParameter("@name", SqlDbType.VarChar);
                    sqlstr = namestr;
                    name.Value = newname;
                    break;
                case 2:
                    name = new SqlParameter("@name", SqlDbType.Int);
                    sqlstr = boolstr;
                    name.Value = deleteable == true ? 1 : 0;
                    break;
            }
            

            SqlParameter[] para=new SqlParameter[]
            {
                name,
                new SqlParameter("@ID",SqlDbType.Int)
            };
            para[1].Value = StatusID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 删除某个房间状态
        /// </summary>
        /// <param name="statusID">需要删除的状态ID</param>
        /// <returns>如果返回1则删除成功，返回-100为异常</returns>
        public static int DeleteStatusName(int statusID)
        {
            string sqlstr = "delete from RoomStatus where RoomStatusID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = statusID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

    }
}
