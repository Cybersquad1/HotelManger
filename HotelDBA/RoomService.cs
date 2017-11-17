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
    public class RoomService
    {
        /// <summary>
        /// 获取房间列表
        /// </summary>
        /// <returns>返回列表</returns>
        public static List<Room> GetRoomList()
        {
            List<Room> list = new List<Room>();

            string sqlstr = "select RoomID,RoomNumber,RoomTypeID,RoomStatus,Description,NumOfBeds,NumOfCust from Room";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while (reader.Read())
            {
                Room node = new Room();
                node.RoomID = Convert.ToInt32(reader[0]);
                node.RoomNumber = reader[1].ToString();
                node.RoomTypeID = Convert.ToInt32(reader[2]);
                node.RoomStatus = Convert.ToInt32(reader[3]);
                node.Description = reader[4].ToString();
                node.NumOfBeds = Convert.ToInt32(reader[5]);
                node.NumOfCust = Convert.ToInt32(reader[6]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        public static List<Room> GetRoomListByType(int RoomTypeID)
        {
            List<Room> list = new List<Room>();

            string sqlstr = "select RoomID,RoomNumber,RoomTypeID,RoomStatus,Description,NumOfBeds,NumOfCust from Room where RoomTypeID = @index";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = RoomTypeID;
            
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr,para);

            while (reader.Read())
            {
                Room node = new Room();
                node.RoomID = Convert.ToInt32(reader[0]);
                node.RoomNumber = reader[1].ToString();
                node.RoomTypeID = Convert.ToInt32(reader[2]);
                node.RoomStatus = Convert.ToInt32(reader[3]);
                node.Description = reader[4].ToString();
                node.NumOfBeds = Convert.ToInt32(reader[5]);
                node.NumOfCust = Convert.ToInt32(reader[6]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过房间ID或者房间号查找房间
        /// </summary>
        /// <param name="ID">需要查找的房间ID</param>
        /// <param name="RoomNumber">需要查找的房间号</param>
        /// <param name="type">1为按ID查找，2为按房间号查找</param>
        /// <returns>如果返回的roomid为-1则为查找失败，其他情况为查找成功</returns>
        public static Room FindRoomByIDorName(int ID, string RoomNumber ,int type)
        {
            Room node = new Room();
            node.RoomID = -1;
            string ChangeStr = "";
            SqlParameter value = null;

            switch (type)
            {
                case 2:
                    ChangeStr = "RoomNumber";
                    value = new SqlParameter("@SearchName", SqlDbType.VarChar);
                    value.Value = RoomNumber;
                    break;
                case 1:
                    ChangeStr = "RoomID";
                    value = new SqlParameter("@SearchName", SqlDbType.Int);
                    value.Value = ID;
                    break;

            }

            string sqlstr = "SELECT RoomID,RoomNumber,RoomTypeID,RoomStatus,Description,NumOfBeds,NumOfCust from Room where " + ChangeStr + "= @SearchName";
            SqlParameter[] para = new SqlParameter[]{
                value
            };

            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr, para);

            while (reader.Read())
            {
                node.RoomID = Convert.ToInt32(reader[0]);
                node.RoomNumber = reader[1].ToString();
                node.RoomTypeID = Convert.ToInt32(reader[2]);
                node.RoomStatus = Convert.ToInt32(reader[3]);
                node.Description = reader[4].ToString();
                node.NumOfBeds = Convert.ToInt32(reader[5]);
                node.NumOfCust = Convert.ToInt32(reader[6]);
            }

            reader.Close();

            return node;
        }

        /// <summary>
        /// 添加新的房间信息
        /// </summary>
        /// <param name="RoomNumber">房间号</param>
        /// <param name="RoomTypeID">房间类型ID</param>
        /// <param name="RoomStatus">房间状态代码</param>
        /// <param name="Description">房间描述</param>
        /// <param name="NumOfBeds">床的数量</param>
        /// <param name="NumOfCust">最大入住人数</param>
        /// <returns>返回1为插入成功，-1为重复拒绝插入</returns>
        public static int AddNewRoom(string RoomNumber, int RoomTypeID, int RoomStatus, string Description, int NumOfBeds, int NumOfCust)
        {
            string sqlstr = "if not exists (select RoomNumber from Room where RoomNumber= @oldid) " +
                "insert into Room (RoomNumber,RoomTypeID,RoomStatus,Description,NumOfBeds,NumOfCust) "+
                "VALUES (@newnumber,@newtypeid,@newstatus,@newdes,@newbeds,@newcust)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@newnumber",SqlDbType.VarChar),
                new SqlParameter("@newtypeid",SqlDbType.Int),
                new SqlParameter("@newstatus",SqlDbType.Int),
                new SqlParameter("@newdes",SqlDbType.VarChar),
                new SqlParameter("@newbeds",SqlDbType.Int),
                new SqlParameter("@newcust",SqlDbType.Int),
                new SqlParameter("@oldid",SqlDbType.VarChar)
            };

            para[0].Value = RoomNumber;
            para[1].Value = RoomTypeID;
            para[2].Value = RoomStatus;
            para[3].Value = Description;
            para[4].Value = NumOfBeds;
            para[5].Value = NumOfCust;
            para[6].Value = RoomNumber;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 修改房间信息
        /// </summary>
        /// <param name="RoomID">需要修改的房间ID</param>
        /// <param name="RoomNumber">房间号</param>
        /// <param name="RoomTypeID">房间类型ID</param>
        /// <param name="RoomStatus">房间状态代码</param>
        /// <param name="Description">房间描述</param>
        /// <param name="NumOfBeds">床的数量</param>
        /// <param name="NumOfCust">最大入住人数</param>
        /// <param name="type">修改类型，从1到6</param>
        /// <returns>如果返回1为修改成功，0为修改失败，-100为异常</returns>
        public static int ChangeRoom(int RoomID, string RoomNumber, int RoomTypeID, int RoomStatus, string Description, int NumOfBeds, int NumOfCust, int type)
        {
            string ChangeStr = "";
            SqlParameter paraid = new SqlParameter("@ID", SqlDbType.Int);
            paraid.Value = RoomID;
            SqlParameter newvalue = null;

            switch (type)
            {
                case 1:
                    ChangeStr = "RoomNumber";
                    newvalue = new SqlParameter("@value", SqlDbType.VarChar);
                    newvalue.Value = RoomNumber;
                    break;
                case 2:
                    ChangeStr = "RoomTypeID";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = RoomTypeID;
                    break;
                case 3:
                    ChangeStr = "RoomStatus";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = RoomStatus;
                    break;
                case 4:
                    ChangeStr = "Description";
                    newvalue = new SqlParameter("@value", SqlDbType.VarChar);
                    newvalue.Value = Description;
                    break;
                case 5:
                    ChangeStr = "NumOfBeds";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = NumOfBeds;
                    break;
                case 6:
                    ChangeStr = "NumOfCust";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = NumOfCust;
                    break;
            }

            string sqlstr = "update Room SET " + ChangeStr + " = @value where RoomID = @ID";

            SqlParameter[] para = new SqlParameter[]
            {
                paraid,newvalue
            };

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 删除房间信息
        /// </summary>
        /// <param name="RoomID">需要删除的房间ID</param>
        /// <returns>返回1为删除成功，0为找不到删除的ID，-100为异常</returns>
        public static int DeleteRoom(int RoomID)
        {
            string sqlstr = "delete from Room where RoomID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = RoomID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }
    }
}
