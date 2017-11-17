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
    /// 在数据访问层提供对入住日志表的访问支持
    /// </summary>
    public class CheckInLogService
    {
        /// <summary>
        /// 获取所有日志
        /// </summary>
        /// <returns>返回日志列表</returns>
        public static List<CheckInLog> GetAllCheckInLog()
        {
            List<CheckInLog> list = new List<CheckInLog>();

            string sqlstr = "select CheckInID,CustomerID,RoomID,CheckInDate,CheckOutDate,FinalOutDate,PledgeCash,RoomPrice,ReceiveMoney,FinalPrice,ReturnMoney,StatusID from CheckInLog";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while (reader.Read())
            {
                CheckInLog node = new CheckInLog();
                node.CheckInID = Convert.ToInt32(reader[0]);
                node.CustomerID = Convert.ToInt32(reader[1]);
                node.RoomID = Convert.ToInt32(reader[2]);
                node.CheckInDate = Convert.ToDateTime(reader[3]);
                node.CheckOutDate = Convert.ToDateTime(reader[4]);
                if(reader[5]!=DBNull.Value)
                {
                    node.FinalOutDate = Convert.ToDateTime(reader[5]);
                }
                node.PledgeCash = Convert.ToInt32(reader[6]);
                node.RoomPrice = Convert.ToInt32(reader[7]);
                node.ReceiveMoney = Convert.ToDouble(reader[8]);
                node.FinalPrice = reader[9] == DBNull.Value ? -1 : Convert.ToDouble(reader[9]);
                node.ReturnMoney = reader[10] == DBNull.Value ? -1 : Convert.ToDouble(reader[10]);
                node.StatusID = Convert.ToInt32(reader[11]);
                list.Add(node);
            }

            reader.Close();
            
            return list;
        }

        /// <summary>
        /// 根据日志ID或者顾客ID查找对应日志
        /// </summary>
        /// <param name="CheckInID">日志ID</param>
        /// <param name="CustomerID">顾客ID</param>
        /// <param name="type">类型</param>
        /// <returns>返回日志列表</returns>
        public static List<CheckInLog> GetCheckInLogByIDorCust(int CheckInID,int CustomerID,int type)
        {
            List<CheckInLog> list = new List<CheckInLog>();
            string FindStr = "";
            SqlParameter value = new SqlParameter("@index", SqlDbType.Int);

            switch (type)
            {
                case 1:
                    FindStr = "CheckInID";
                    value.Value = CheckInID;
                    break;
                case 2:
                    FindStr = "CustomerID";
                    value.Value = CustomerID;
                    break;
            }

            string sqlstr = "select CheckInID,CustomerID,RoomID,CheckInDate,CheckOutDate,FinalOutDate,PledgeCash,RoomPrice,ReceiveMoney,FinalPrice,ReturnMoney,StatusID from CheckInLog where "+FindStr+" = @index";

            SqlParameter[] para = new SqlParameter[]{
                value
            };

            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr, para);

            while(reader.Read())
            {
                CheckInLog node = new CheckInLog();
                node.CheckInID = Convert.ToInt32(reader[0]);
                node.CustomerID = Convert.ToInt32(reader[1]);
                node.RoomID = Convert.ToInt32(reader[2]);
                node.CheckInDate = Convert.ToDateTime(reader[3]);
                node.CheckOutDate = Convert.ToDateTime(reader[4]);
                if (reader[5] != DBNull.Value)
                {
                    node.FinalOutDate = Convert.ToDateTime(reader[5]);
                }
                node.PledgeCash = Convert.ToInt32(reader[6]);
                node.RoomPrice = Convert.ToInt32(reader[7]);
                node.ReceiveMoney = Convert.ToInt32(reader[8]);
                node.FinalPrice = reader[9] == DBNull.Value ? -1 : Convert.ToInt32(reader[9]);
                node.ReturnMoney = reader[10] == DBNull.Value ? -1 : Convert.ToInt32(reader[10]);
                node.StatusID = Convert.ToInt32(reader[11]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 添加新的入住日志【由于入住日志无法一次性完成不提供所有变量的设置】
        /// </summary>
        /// <param name="CustomerID">顾客ID</param>
        /// <param name="RoomID">房间ID</param>
        /// <param name="CheckInDate">入住时间</param>
        /// <param name="CheckOutDate">预计退房时间</param>
        /// <param name="PledgeCash">押金</param>
        /// <param name="RoomPrice">房间价格</param>
        /// <param name="ReceiveMoney">实收</param>
        /// <param name="StatusID">入住状态ID</param>
        /// <returns>返回1为插入成功，-100为异常</returns>
        public static int AddNewCheckInLog(int CustomerID,int RoomID,DateTime CheckInDate,DateTime CheckOutDate,int PledgeCash,int RoomPrice,double ReceiveMoney,int StatusID)
        {
            string sqlstr = "insert into CheckInLog (CustomerID,RoomID,CheckInDate,CheckOutDate,PledgeCash,RoomPrice,ReceiveMoney,StatusID) VALUES "
                +"(@customerid,@roomid,@checkin,@checkout,@cash,@price,@money,@id)";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@customerid",SqlDbType.Int),
                new SqlParameter("@roomid",SqlDbType.Int),
                new SqlParameter("@checkin",SqlDbType.DateTime),
                new SqlParameter("@checkout",SqlDbType.DateTime),
                new SqlParameter("@cash",SqlDbType.Int),
                new SqlParameter("@price",SqlDbType.Int),
                new SqlParameter("@money",SqlDbType.Decimal),
                new SqlParameter("@id",SqlDbType.Int)
            };

            para[6].Scale = 2;
            para[6].Precision = 6;
            para[0].Value = CustomerID;
            para[1].Value = RoomID;
            para[2].Value = CheckInDate;
            para[3].Value = CheckOutDate;
            para[4].Value = PledgeCash;
            para[5].Value = RoomPrice;
            para[6].Value = ReceiveMoney;
            para[7].Value = StatusID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 退房时追加信息
        /// </summary>
        /// <param name="CheckInID">需要追加的日志ID</param>
        /// <param name="FinalOutDate">退房日期</param>
        /// <param name="FinalPrice">最终价</param>
        /// <param name="ReturnMoney">找零</param>
        /// <returns>返回1为添加成功，返回-100为异常</returns>
        public static int AddMoreInfoToLog(int CheckInID, DateTime FinalOutDate, double FinalPrice, double ReturnMoney)
        {
            string sqlstr = "update CheckInLog SET FinalOutDate = @newdate, FinalPrice = @newprice, ReturnMoney = @newmoney where CheckInID = @ID";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@newdate",SqlDbType.DateTime),
                new SqlParameter("@newprice",SqlDbType.Decimal),
                new SqlParameter("@newmoney",SqlDbType.Decimal),
                new SqlParameter("@ID",SqlDbType.Int)
            };

            para[0].Value = FinalOutDate;
            para[1].Precision = 6;
            para[1].Scale = 2;
            para[1].Value = FinalPrice;
            para[2].Precision = 6;
            para[2].Scale = 2;
            para[2].Value = ReturnMoney;
            para[3].Value = CheckInID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 修改入住状态
        /// </summary>
        /// <param name="CheckID">需要修改的ID</param>
        /// <param name="StatusID">入住状态ID</param>
        /// <returns>返回1为成功，-100为异常</returns>
        public static int ChangeStatusID(int CheckID,int StatusID)
        {
            string sqlstr = "update CheckInLog SET StatusID = @newdate where CheckInID = @ID";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@newdate",SqlDbType.Int),
                new SqlParameter("@ID",SqlDbType.Int)
            };

            para[0].Value = StatusID;
            para[1].Value = CheckID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 删除入住日志
        /// </summary>
        /// <param name="checkID">需要删除的入住日志ID</param>
        /// <returns>返回1为删除成功，0为没有查找到对应ID删除失败，-100为异常</returns>
        public static int DeleteCheckInLog(int checkID)
        {
            string sqlstr = "delete from CheckInLog where CheckInID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = checkID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }
    }
}
