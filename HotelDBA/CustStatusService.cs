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
    /// 在数据访问层上提供对顾客状态类型表的访问支持
    /// </summary>
    public class CustStatusService
    {
        /// <summary>
        /// 获取所有顾客状态类型对象
        /// </summary>
        /// <returns></returns>
        public static List<CustStatus> GetAllCustStatus()
        {
            List<CustStatus> list = new List<CustStatus>();

            string sqlstr = "select StatusID,StatusName from CustStatus";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while (reader.Read())
            {
                CustStatus node = new CustStatus();
                node.StatusID = Convert.ToInt32(reader[0]);
                node.StatusName = Convert.ToString(reader[1]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过关键字查找顾客状态类型，支持模糊查找
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="FuzzyMode">模糊查找模式，true为开启，false为关闭</param>
        /// <returns></returns>
        public static List<CustStatus> FindCustStatusByKeyword(string keyword, bool FuzzyMode)
        {
            List<CustStatus> list = new List<CustStatus>();

            string FindStr = "";

            if (FuzzyMode == true)
            {
                FindStr = " like ";
            }
            else
            {
                FindStr = " = ";
            }

            string sqlstr = "select StatusID,StatusName from CustStatus where StatusName" + FindStr + "@searchname";

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
                CustStatus node = new CustStatus();
                node.StatusID = Convert.ToInt32(reader[0]);
                node.StatusName = Convert.ToString(reader[1]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过ID序号查找顾客状态类型
        /// </summary>
        /// <param name="ID">需要查找的ID序号</param>
        /// <returns>如果返回的ID为-1则为查找失败</returns>
        public static CustStatus FindCustStatusByID(int ID)
        {
            CustStatus node = new CustStatus();
            node.StatusID = -1;

            string str = "select StatusID,StatusName from CustStatus where StatusID = @index";
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
        /// 新增顾客状态类型
        /// </summary>
        /// <param name="statusname">新状态类型名称</param>
        /// <returns>返回1为插入成功，-1为重复项无法插入，-100为异常</returns>
        public static int AddNewCustStatus(string statusname)
        {
            string sqlstr = "if not exists (select StatusName from CustStatus where StatusName= @newname )" +
    " insert into CustStatus (StatusName) VALUES (@newname)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@newname",SqlDbType.VarChar)
            };

            para[0].Value = statusname;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 修改顾客状态类型名称
        /// </summary>
        /// <param name="newname">新名称</param>
        /// <param name="ID">欲修改的名称对应ID</param>
        /// <returns>返回1为修改成功，返回0为ID不正确</returns>
        public static int ChangeStatusName(string newname, int ID)
        {
            string sqlstr = "update CustStatus SET StatusName = @name where StatusID = @ID";
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
        /// 删除顾客状态类型名称
        /// </summary>
        /// <param name="statusID">欲删除的名称对应ID</param>
        /// <returns>返回1为修改成功，返回0为ID不正确</returns>
        public static int DeleteStatusName(int statusID)
        {
            string sqlstr = "delete from CustStatus where StatusID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = statusID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }
    }
}
