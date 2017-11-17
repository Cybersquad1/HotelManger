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
    /// 在数据访问层提供对客户表的访问支持
    /// </summary>
    public class CustomerService
    {
        /// <summary>
        /// 获取所有的客户列表
        /// </summary>
        /// <returns>返回list</returns>
        public static List<Customer> GetCustomerList()
        {
            List<Customer> list = new List<Customer>();

            string sqlstr = "select CustomerID,Name,IDNumber,DrgreeID,TotalMoney,CheckInCount,CheckInLogIndex,StatusID from Customer";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while (reader.Read())
            {
                Customer node = new Customer();
                node.CustomerID = Convert.ToInt32(reader[0]);
                node.Name = reader[1].ToString();
                node.IDNumber = reader[2].ToString();
                node.DrgreeID = Convert.ToInt32(reader[3]);
                node.TotalMoney = Convert.ToInt32(reader[4]);
                node.CheckInCount = Convert.ToInt32(reader[5]);
                node.CheckInLogIndex = reader[6] == null ? "" : reader[6].ToString();
                node.StatusID = Convert.ToInt32(reader[7]);

                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过客户姓名查找客户信息，支持模糊查找
        /// </summary>
        /// <param name="keyword">客户姓名</param>
        /// <param name="FuzzyMode">是否开启模糊查找，true为开启，false为关闭</param>
        /// <returns></returns>
        public static List<Customer> FindCustomerListByName(string keyword, bool FuzzyMode)
        {
            List<Customer> list = new List<Customer>();

            string FindStr = "";

            if (FuzzyMode == true)
            {
                FindStr = " like ";
            }
            else
            {
                FindStr = " = ";
            }

            string sqlstr = "SELECT CustomerID,Name,IDNumber,DrgreeID,TotalMoney,CheckInCount,CheckInLogIndex,StatusID from Customer where Name" + FindStr + "@SearchName";
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
                Customer node = new Customer();
                node.CustomerID = Convert.ToInt32(reader[0]);
                node.Name = reader[1].ToString();
                node.IDNumber = reader[2].ToString();
                node.DrgreeID = Convert.ToInt32(reader[3]);
                node.TotalMoney = Convert.ToInt32(reader[4]);
                node.CheckInCount = Convert.ToInt32(reader[5]);
                node.CheckInLogIndex = reader[6] == null ? "" : reader[6].ToString();
                node.StatusID = Convert.ToInt32(reader[7]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过客户ID或者身份证号码查找客户信息
        /// </summary>
        /// <param name="ID">需要查找的客户ID</param>
        /// <param name="IDNumber">需要查找的客户身份证号码</param>
        /// <param name="type">1为按ID查询，2为按身份证号码查询</param>
        /// <returns>如果customerID为-1为查找失败，否则为查找成功</returns>
        public static Customer FindCustomerListByCodeOrID(int ID,string IDNumber,int type)
        {
            Customer node = new Customer();
            node.CustomerID = -1;
            string ChangeStr = "";
            SqlParameter value = null;

            switch (type)
            {
                case 2:
                    ChangeStr = "IDNumber";
                    value = new SqlParameter("@SearchName", SqlDbType.VarChar);
                    value.Value = IDNumber;
                    break;
                case 1:
                    ChangeStr = "CustomerID";
                    value = new SqlParameter("@SearchName", SqlDbType.Int);
                    value.Value = ID;
                    break;

            }

            string sqlstr = "SELECT CustomerID,Name,IDNumber,DrgreeID,TotalMoney,CheckInCount,CheckInLogIndex,StatusID from Customer where " + ChangeStr + "= @SearchName";
            SqlParameter[] para = new SqlParameter[]{
                value
            };

            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr, para);

            while (reader.Read())
            {
                
                node.CustomerID = Convert.ToInt32(reader[0]);
                node.Name = reader[1].ToString();
                node.IDNumber = reader[2].ToString();
                node.DrgreeID = Convert.ToInt32(reader[3]);
                node.TotalMoney = Convert.ToInt32(reader[4]);
                node.CheckInCount = Convert.ToInt32(reader[5]);
                node.CheckInLogIndex = reader[6] == null ? "" : reader[6].ToString();
                node.StatusID = Convert.ToInt32(reader[7]);
            }

            reader.Close();

            return node;
        }

        /// <summary>
        /// 加入新的客户信息
        /// </summary>
        /// <param name="Name">客户姓名</param>
        /// <param name="IDNumber">客户身份证号</param>
        /// <param name="DrgreeID">客户等级，默认为0</param>
        /// <param name="TotalMoney">总消费，默认为0</param>
        /// <param name="CheckInCount">入住次数，默认为0</param>
        /// <param name="CheckInLogIndex">入住日志，默认置空</param>
        /// <param name="StatusID">入住状态</param>
        /// <returns>如果返回1为成功插入，-1为检测到相同身份证号码拒绝插入，-100为异常</returns>
        public static int AddNewCustomer(string Name, string IDNumber, int DrgreeID, int TotalMoney, int CheckInCount, string CheckInLogIndex, int StatusID)
        {
            string sqlstr = "if not exists (select IDNumber from Customer where IDNumber= @oldid or Name= @oldname) " + "insert into Customer (Name,IDNumber,DrgreeID,TotalMoney,CheckInCount,CheckInLogIndex,StatusID) VALUES (@newname,@newidnumber,@newdrgreeid,@totalmoney,@newcheckcount,@newindex,@newstatusid)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@newname",SqlDbType.VarChar),
                new SqlParameter("@newidnumber",SqlDbType.VarChar),
                new SqlParameter("@newdrgreeid",SqlDbType.Int),
                new SqlParameter("@totalmoney",SqlDbType.Int),
                new SqlParameter("@newcheckcount",SqlDbType.Int),
                new SqlParameter("@newindex",SqlDbType.VarChar),
                new SqlParameter("@newstatusid",SqlDbType.Int),
                new SqlParameter("@oldid",SqlDbType.VarChar),
                new SqlParameter("oldname",SqlDbType.VarChar)
            };

            para[0].Value = Name;
            para[1].Value = IDNumber;
            para[2].Value = DrgreeID;
            para[3].Value = TotalMoney;
            para[4].Value = CheckInCount;
            para[5].Value = CheckInLogIndex;
            para[6].Value = StatusID;
            para[7].Value = IDNumber;
            para[8].Value = Name;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="ID">需要修改的用户ID</param>
        /// <param name="Name">姓名</param>
        /// <param name="IDNumber">身份证</param>
        /// <param name="DrgreeID">会员等级</param>
        /// <param name="TotalMoney">总消费</param>
        /// <param name="CheckInCount">入住次数</param>
        /// <param name="CheckInLogIndex">入住日志记录</param>
        /// <param name="StatusID">状态</param>
        /// <param name="type">类型，从1到7</param>
        /// <returns>返回1为修改成功，0为修改失败，-100为异常</returns>
        public static int ChangeCustomer(int ID, string Name, string IDNumber, int DrgreeID, int TotalMoney, int CheckInCount, string CheckInLogIndex, int StatusID, int type)
        {
            string ChangeStr = "";
            SqlParameter paraid = new SqlParameter("@ID", SqlDbType.Int);
            paraid.Value = ID;
            SqlParameter newvalue = null;

            switch (type)
            {
                case 1:
                    ChangeStr = "Name";
                    newvalue = new SqlParameter("@value", SqlDbType.VarChar);
                    newvalue.Value = Name;
                    break;
                case 2:
                    ChangeStr = "IDNumber";
                    newvalue = new SqlParameter("@value", SqlDbType.VarChar);
                    newvalue.Value = IDNumber;
                    break;
                case 3:
                    ChangeStr = "DrgreeID";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = DrgreeID;
                    break;
                case 4:
                    ChangeStr = "TotalMoney";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = TotalMoney;
                    break;
                case 5:
                    ChangeStr = "CheckInCount";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = CheckInCount;
                    break;
                case 6:
                    ChangeStr = "CheckInLogIndex";
                    newvalue = new SqlParameter("@value", SqlDbType.VarChar);
                    newvalue.Value = CheckInLogIndex;
                    break;
                case 7:
                    ChangeStr = "StatusID";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = StatusID;
                    break;
            }

            string sqlstr = "update Customer SET " + ChangeStr + " = @value where CustomerID = @ID";

            SqlParameter[] para = new SqlParameter[]
            {
                paraid,newvalue
            };

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 通过ID删除用户信息
        /// </summary>
        /// <param name="ID">需要删除的用户ID</param>
        /// <returns>返回1为删除成功，0为无法查找对应ID删除失败，-100为异常</returns>
        public static int DeleteCustomer(int ID)
        {
            string sqlstr = "delete from Customer where CustomerID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = ID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }
    }
}
