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
    /// 在数据访问层提供对操作员（职员）表的访问支持
    /// </summary>
    public class OperatorListService
    {
        /// <summary>
        /// 获取所有操作员对象（不获取密码）
        /// </summary>
        /// <returns>返回操作员列表</returns>
        public static List<OperatorList> GetAllOperatorList()
        {
            List<OperatorList> list = new List<OperatorList>();

            string sqlstr = "select OperID,OperName,AuthDegree,LogInCount,LoginAccount,Enable from OperatorList";//安全起见不获取密码
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while(reader.Read())
            {
                OperatorList node = new OperatorList();
                node.OperID = Convert.ToInt32(reader[0]);
                node.OperName = reader[1].ToString();
                node.AuthDegree = Convert.ToInt32(reader[2]);
                node.LogInCount = Convert.ToInt32(reader[3]);
                node.LoginAccount = reader[4].ToString();
                node.Enable = Convert.ToInt32(reader[5]) == 1 ? true : false;
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过ID、姓名、登陆账户查找用户信息（不提供密码）【其他非查询参数符合变量规则即可】
        /// </summary>
        /// <param name="OperID">需要查找的ID</param>
        /// <param name="OperName">需要查找的姓名</param>
        /// <param name="LoginAccount">需要查找的账户</param>
        /// <param name="type">查找类型，1为ID，2为姓名，3为账户</param>
        /// <returns>如果OperID返回-1则表示查找失败</returns>
        public static OperatorList FindOperatorByID(int OperID,string OperName,string LoginAccount,int type)
        {
            OperatorList node = new OperatorList();
            node.OperID = -1;
            string ChangeStr = "";
            SqlParameter ChangePara = null;

            switch (type)
            {
                case 1:
                    ChangeStr = "OperID";
                    ChangePara = new SqlParameter("@index", SqlDbType.Int);
                    ChangePara.Value = OperID;
                    break;
                case 2:
                    ChangeStr = "OperName";
                    ChangePara = new SqlParameter("@index", SqlDbType.VarChar);
                    ChangePara.Value = OperName;
                    break;
                case 3:
                    ChangeStr = "LoginAccount";
                    ChangePara = new SqlParameter("@index", SqlDbType.VarChar);
                    ChangePara.Value = LoginAccount;
                    break;
            }

            string sqlstr = "select OperID,OperName,AuthDegree,LogInCount,LoginAccount,Enable from OperatorList where " + ChangeStr + " = @index";

            SqlParameter[] para = new SqlParameter[]
            {
                ChangePara
            };
            

            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr, para);

            while(reader.Read())
            {
                node.OperID = Convert.ToInt32(reader[0]);
                node.OperName = reader[1].ToString();
                node.AuthDegree = Convert.ToInt32(reader[2]);
                node.LogInCount = Convert.ToInt32(reader[3]);
                node.LoginAccount = reader[4].ToString();
                node.Enable = Convert.ToInt32(reader[5]) == 1 ? true : false;
            }

            reader.Close();

            return node;
        }

        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="OperName">用户姓名</param>
        /// <param name="AuthDegree">权限等级</param>
        /// <param name="LogInCount">登录次数</param>
        /// <param name="LoginAccount">登录账户</param>
        /// <param name="LogInPassword">登录密码【请在逻辑层完成加密】</param>
        /// <param name="Enable">是否启用</param>
        /// <returns>返回1为成功添加，-1为检测到重复拒绝添加，-100为异常</returns>
        public static int AddNewOperator(string OperName,int AuthDegree,int LogInCount,string LoginAccount,string LogInPassword,bool Enable)
        {
            string sqlstr = "if not exists (select OperName from OperatorList where OperName= @newname or LoginAccount= @newaccount) " +
                "insert into OperatorList (OperName,AuthDegree,LogInCount,LoginAccount,LogInPassword,Enable) VALUES (@newname,@newdegree,@newcount,@newaccount,@newpassword,@newenable)";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@newname",SqlDbType.VarChar),
                new SqlParameter("@newdegree",SqlDbType.Int),
                new SqlParameter("@newcount",SqlDbType.Int),
                new SqlParameter("@newaccount",SqlDbType.VarChar),
                new SqlParameter("@newpassword",SqlDbType.VarChar),
                new SqlParameter("@newenable",SqlDbType.Int)
            };

            para[0].Value = OperName;
            para[1].Value = AuthDegree;
            para[2].Value = LogInCount;
            para[3].Value = LoginAccount;
            para[4].Value = LogInPassword;
            para[5].Value = Enable == true ? 1 : 0;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 修改操作者信息
        /// </summary>
        /// <param name="ID">修改用户对应的ID</param>
        /// <param name="OperName">操作者姓名</param>
        /// <param name="AuthDegree">认证等级</param>
        /// <param name="LogInCount">登录次数</param>
        /// <param name="LoginAccount">登录账户</param>
        /// <param name="LogInPassword">登录密码</param>
        /// <param name="Enable">是否启用</param>
        /// <param name="type">类型，从1-6选择</param>
        /// <returns>返回1为成功修改，-100为异常</returns>
        public static int ChangeOperator(int ID,string OperName,int AuthDegree,int LogInCount,string LoginAccount,string LogInPassword,bool Enable,int type)
        {
            string ChangeStr = "";
            SqlParameter paraid = new SqlParameter("@ID", SqlDbType.Int);
            paraid.Value = ID;
            SqlParameter newvalue = null;

            switch (type)
            {
                case 1:
                    ChangeStr = "OperName";
                    newvalue = new SqlParameter("@value", SqlDbType.VarChar);
                    newvalue.Value = OperName;
                    break;
                case 2:
                    ChangeStr = "AuthDegree";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = AuthDegree;
                    break;
                case 3:
                    ChangeStr = "LogInCount";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = LogInCount;
                    break;
                case 4:
                    ChangeStr = "LoginAccount";
                    newvalue = new SqlParameter("@value", SqlDbType.VarChar);
                    newvalue.Value = LoginAccount;
                    break;
                case 5:
                    ChangeStr = "LogInPassword";
                    newvalue = new SqlParameter("@value", SqlDbType.VarChar);
                    newvalue.Value = LogInPassword;
                    break;
                case 6:
                    ChangeStr = "Enable";
                    newvalue = new SqlParameter("@value", SqlDbType.Int);
                    newvalue.Value = Enable;
                    break;
            }

            string sqlstr = "update OperatorList SET " + ChangeStr + " = @value where OperID = @ID";

            SqlParameter[] para = new SqlParameter[]
            {
                paraid,newvalue
            };

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="ID">需要删除的用户ID</param>
        /// <returns>返回1为删除成功，0为无法查找到对应ID无法删除，-100为异常</returns>
        public static int DeleteOperator(int ID)
        {
            string sqlstr = "delete from OperatorList where OperID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = ID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 确认用户名密码是否匹配
        /// </summary>
        /// <param name="account">验证的帐号</param>
        /// <param name="password">验证的密码</param>
        /// <returns>返回true为正确，false为错误</returns>
        public static bool VailPassword(string account,string password)
        {
            string sqlstr = "if exists (select * from OperatorList where LoginAccount =@acc and LogInPassword=@psw ) select '1' else select '0'";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@acc",SqlDbType.VarChar),
                new SqlParameter("@psw",SqlDbType.VarChar)
            };
            para[0].Value = account;
            para[1].Value = password;

            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr, para);

            string output = "";

            while(reader.Read())
            {
                output = reader[0].ToString();
            }

            return output == "0" ? false : true;
        }
    }
}
