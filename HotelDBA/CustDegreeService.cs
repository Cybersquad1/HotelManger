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
    /// 在数据访问层提供对用户等级表访问的支持
    /// </summary>
    public class CustDegreeService
    {
        /// <summary>
        /// 获取所有用户等级对象
        /// </summary>
        /// <returns>返回列表对象</returns>
        public static List<CustDegree> GetAllDegreeStatus()
        {
            List<CustDegree> list = new List<CustDegree>();

            string sqlstr = "select DegreeID,DegreeName,RoomDiscount,PledgeCashDisCount,TotalMoneyLimit,RoomCheck,FreeBreakfast from CustDegree";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while (reader.Read())
            {
                CustDegree node = new CustDegree();
                node.DegreeID = Convert.ToInt32(reader[0]);
                node.DegreeName = Convert.ToString(reader[1]);
                node.RoomDiscount = Convert.ToDouble(reader[2]);
                node.PledgeCashDisCount = Convert.ToInt32(reader[3]);
                node.TotalMoneyLimit = Convert.ToInt32(reader[4]);
                node.RoomCheck = Convert.ToString(reader[5]) == "True" ? true : false;
                node.FreeBreakfast = Convert.ToString(reader[6]) == "True" ? true : false;
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过关键词查找用户等级，支持模糊搜索
        /// </summary>
        /// <param name="keyword">需要查找的关键词</param>
        /// <param name="FuzzyMode">模糊搜索模式，true为开启，false为关闭</param>
        /// <returns>返回列表对象</returns>
        public static List<CustDegree> FindCustDegreeByKeyword(string keyword, bool FuzzyMode)
        {
            List<CustDegree> list = new List<CustDegree>();

            string FindStr = "";

            if (FuzzyMode == true)
            {
                FindStr = " like ";
            }
            else
            {
                FindStr = " = ";
            }

            string sqlstr = "select DegreeID,DegreeName,RoomDiscount,PledgeCashDisCount,TotalMoneyLimit,RoomCheck,FreeBreakfast from CustDegree where DegreeName" + FindStr + "@searchname";

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
                CustDegree node = new CustDegree();
                node.DegreeID = Convert.ToInt32(reader[0]);
                node.DegreeName = Convert.ToString(reader[1]);
                node.RoomDiscount = Convert.ToDouble(reader[2]);
                node.PledgeCashDisCount = Convert.ToInt32(reader[3]);
                node.TotalMoneyLimit = Convert.ToInt32(reader[4]);
                node.RoomCheck = Convert.ToString(reader[5]) == "True" ? true : false;
                node.FreeBreakfast = Convert.ToString(reader[6]) == "True" ? true : false;
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过ID查找用户等级对象
        /// </summary>
        /// <param name="ID">需要查找的ID</param>
        /// <returns>用户等级对象</returns>
        public static CustDegree FindCustDegreeByID(int ID)
        {
            CustDegree node = new CustDegree();
            node.DegreeID = -1;

            string str = "select DegreeID,DegreeName,RoomDiscount,PledgeCashDisCount,TotalMoneyLimit,RoomCheck,FreeBreakfast from CustDegree where DegreeID = @index";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };
            para[0].Value = ID;

            SqlDataReader reader = SqlHelper.ExecuteReader(str, para);

            while (reader.Read())
            {
                node.DegreeID = Convert.ToInt32(reader[0]);
                node.DegreeName = Convert.ToString(reader[1]);
                node.RoomDiscount = Convert.ToDouble(reader[2]);
                node.PledgeCashDisCount = Convert.ToInt32(reader[3]);
                node.TotalMoneyLimit = Convert.ToInt32(reader[4]);
                node.RoomCheck = Convert.ToString(reader[5]) == "True" ? true : false;
                node.FreeBreakfast = Convert.ToString(reader[6]) == "True" ? true : false;
            }

            reader.Close();

            return node;
        }

        /// <summary>
        /// 新增会员等级，如果会员等级名称出现重复则不会被添加
        /// </summary>
        /// <param name="statusname">会员等级名称</param>
        /// <param name="disrate">房费折扣</param>
        /// <param name="cash">是否免押金，0为免押金，1为收取押金</param>
        /// <param name="total">最低消费要求</param>
        /// <param name="Check">是否享受“免查房”权益</param>
        /// <param name="Free">是否享受“提供免费早餐”权益</param>
        /// <returns>返回1为添加成功，0为检查出重复拒绝添加，返回-100为异常</returns>
        public static int AddNewCustStatus(string statusname,double disrate,int cash,int total,bool Check,bool Free)
        {
            string sqlstr = "if not exists (select DegreeName from CustDegree where DegreeName= @newname )" +
    " insert into CustDegree (DegreeName,RoomDiscount,PledgeCashDisCount,TotalMoneyLimit,RoomCheck,FreeBreakfast) VALUES (@newname,@discount,@cashdis,@totalmoney,@roomcheck,@freebreak)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@newname",SqlDbType.VarChar),
                new SqlParameter("@discount",SqlDbType.Decimal),
                new SqlParameter("@cashdis",SqlDbType.Int),
                new SqlParameter("@totalmoney",SqlDbType.Int),
                new SqlParameter("@roomcheck",SqlDbType.VarChar),
                new SqlParameter("@freebreak",SqlDbType.VarChar)
            };

            para[0].Value = statusname;
            para[1].Value = disrate;
            para[1].Precision = 3;
            para[1].Scale = 2;
            para[2].Value = cash;
            para[3].Value = total;
            para[4].Value = Check == true ? "True" : "False";
            para[5].Value = Free == true ? "True" : "False";

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 对存在的用户等级的某个项目进行更改，其他不修改的项目传值符合函数要求即可
        /// </summary>
        /// <param name="id">需要修改的内容的所属ID</param>
        /// <param name="newname">会员等级名称</param>
        /// <param name="newroomdis">房费折扣</param>
        /// <param name="newpledis">是否免押金，0为免押金，1为收取押金</param>
        /// <param name="newtotal">最低消费要求</param>
        /// <param name="newcheck">是否享受“免查房”权益</param>
        /// <param name="newfree">是否享受“提供免费早餐”权益</param>
        /// <param name="type">修改类型，1为名称，2为折扣，3为免押金，4为最低消费，5为“免查房”，6为“提供免费早餐”，按需传入即可</param>
        /// <returns>返回1为修改成功，0为修改失败，-100为异常</returns>
        public static int ChangeStatusName(int id,string newname,double newroomdis,int newpledis,int newtotal,bool newcheck,bool newfree,int type)
        {
            string NameStr = "update CustDegree SET DegreeName = @newvalue where DegreeID = @ID";
            string RoomDisStr = "update CustDegree SET RoomDiscount = @newvalue where DegreeID = @ID";
            string PledgeDisStr = "update CustDegree SET PledgeCashDisCount = @newvalue where DegreeID = @ID";
            string TotalStr = "update CustDegree SET TotalMoneyLimit = @newvalue where DegreeID = @ID";
            string CheckStr = "update CustDegree SET RoomCheck = @newvalue where DegreeID = @ID";
            string FreeStr = "update CustDegree SET FreeBreakfast = @newvalue where DegreeID = @ID";
            string SqlStr = "";

            SqlParameter newvalue = null;
            SqlParameter ChangedID = new SqlParameter("@ID", SqlDbType.Int);
            ChangedID.Value = id;

            if(type==1)
            {
                newvalue = new SqlParameter("@newvalue", SqlDbType.VarChar);
                newvalue.Value = newname;
                SqlStr = NameStr;
            }
            else if(type==2)
            {
                newvalue = new SqlParameter("@newvalue", SqlDbType.Decimal);
                newvalue.Precision = 3;
                newvalue.Scale = 2;
                newvalue.Value = newroomdis;
                SqlStr = RoomDisStr;
            }
            else if(type==3)
            {
                newvalue = new SqlParameter("@newvalue", SqlDbType.Int);
                newvalue.Value = newpledis;
                SqlStr = PledgeDisStr;
            }
            else if(type==4)
            {
                newvalue = new SqlParameter("@newvalue", SqlDbType.Int);
                newvalue.Value = newtotal;
                SqlStr = TotalStr;
            }
            else if(type==5)
            {
                newvalue = new SqlParameter("@newvalue", SqlDbType.VarChar);
                newvalue.Value = newcheck == true ? "True" : "False";
                SqlStr = CheckStr;
            }
            else if(type==6)
            {
                newvalue = new SqlParameter("@newvalue", SqlDbType.VarChar);
                newvalue.Value = newfree == true ? "True" : "False";
                SqlStr = FreeStr;
            }
            
            SqlParameter[] para = new SqlParameter[]
            {
                newvalue,ChangedID
            };

            return SqlHelper.ExecuteNonQuery(SqlStr, para);
        }

        /// <summary>
        /// 通过ID删除某个项目
        /// </summary>
        /// <param name="DegreeID">需要删除的ID</param>
        /// <returns>返回1为删除成功，返回0为ID不存在，返回-100为异常</returns>
        public static int DeleteTypeFromID(int DegreeID)
        {
            string sqlstr = "delete from CustDegree where DegreeID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = DegreeID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }
    }
}
