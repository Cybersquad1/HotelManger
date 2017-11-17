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
    /// 在数据访问层提供对权限信息表的访问支持
    /// </summary>
    public class AuthPrivilegeService
    {
        /// <summary>
        /// 获取所有权限信息对象
        /// </summary>
        /// <returns></returns>
        public static List<AuthPrivilege> GetAllPrivilegeType()
        {
            List<AuthPrivilege> list = new List<AuthPrivilege>();

            string sqlstr = "select AuthID,AuthName,AuthDegree,AddNewRoom,ReadRoom,ChangeRoom,DeleteRoom,ReadRoomStatus,ChangeRoomStatus,ReadCheckLog,ChangeCheckLog,DeleteCheckLog,ReadCust,AddNewCust,ChangeCust,DeleteCust,ReadOperLog,DeleteOperLog,AddOperator,ChangeOperator,DeleteOperator,AddNewPrivilege,ChangePrivilege,DeletePrivilege from AuthPrivilege";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while (reader.Read()) 
            {
                AuthPrivilege node = new AuthPrivilege();
                #region 节点赋值
                node.AuthID = Convert.ToInt32(reader[0]);
                node.AuthName = reader[1].ToString();
                node.AuthDegree = Convert.ToInt32(reader[2]);
                node.AddNewRoom = Convert.ToInt32(reader[3]);
                node.ReadRoom = Convert.ToInt32(reader[4]);
                node.ChangeRoom = Convert.ToInt32(reader[5]);
                node.DeleteRoom = Convert.ToInt32(reader[6]);
                node.ReadRoomStatus = Convert.ToInt32(reader[7]);
                node.ChangeRoomStatus = Convert.ToInt32(reader[8]);
                node.ReadCheckLog = Convert.ToInt32(reader[9]);
                node.ChangeCheckLog = Convert.ToInt32(reader[10]);
                node.DeleteCheckLog = Convert.ToInt32(reader[11]);
                node.ReadCust = Convert.ToInt32(reader[12]);
                node.AddNewCust = Convert.ToInt32(reader[13]);
                node.ChangeCust = Convert.ToInt32(reader[14]);
                node.DeleteCust = Convert.ToInt32(reader[15]);
                node.ReadOperLog = Convert.ToInt32(reader[16]);
                node.DeleteOperLog = Convert.ToInt32(reader[17]);
                node.AddOperator = Convert.ToInt32(reader[18]);
                node.ChangeOperator = Convert.ToInt32(reader[19]);
                node.DeleteOperator = Convert.ToInt32(reader[20]);
                node.AddNewPrivilege = Convert.ToInt32(reader[21]);
                node.ChangePrivilege = Convert.ToInt32(reader[22]);
                node.DeletePrivilege = Convert.ToInt32(reader[23]);
                #endregion
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过关键词查找权限信息对象，支持模糊搜索
        /// </summary>
        /// <param name="keyword">需要查找的关键词</param>
        /// <param name="FuzzyMode">模糊搜索模式，true为开启，false为关闭</param>
        /// <returns></returns>
        public static List<AuthPrivilege> FindAuthPrivilegeByKeyword(string keyword, bool FuzzyMode)
        {
            List<AuthPrivilege> list = new List<AuthPrivilege>();

            string FindStr = "";

            if (FuzzyMode == true)
            {
                FindStr = " like ";
            }
            else
            {
                FindStr = " = ";
            }

            string sqlstr = "select AuthID,AuthName,AuthDegree,AddNewRoom,ReadRoom,ChangeRoom,DeleteRoom,ReadRoomStatus,ChangeRoomStatus,ReadCheckLog,ChangeCheckLog,DeleteCheckLog,ReadCust,AddNewCust,ChangeCust,DeleteCust,ReadOperLog,DeleteOperLog,AddOperator,ChangeOperator,DeleteOperator,AddNewPrivilege,ChangePrivilege,DeletePrivilege from AuthPrivilege where AuthName" + FindStr + "@searchname";

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
                AuthPrivilege node = new AuthPrivilege();
                #region 节点赋值
                node.AuthID = Convert.ToInt32(reader[0]);
                node.AuthName = reader[1].ToString();
                node.AuthDegree = Convert.ToInt32(reader[2]);
                node.AddNewRoom = Convert.ToInt32(reader[3]);
                node.ReadRoom = Convert.ToInt32(reader[4]);
                node.ChangeRoom = Convert.ToInt32(reader[5]);
                node.DeleteRoom = Convert.ToInt32(reader[6]);
                node.ReadRoomStatus = Convert.ToInt32(reader[7]);
                node.ChangeRoomStatus = Convert.ToInt32(reader[8]);
                node.ReadCheckLog = Convert.ToInt32(reader[9]);
                node.ChangeCheckLog = Convert.ToInt32(reader[10]);
                node.DeleteCheckLog = Convert.ToInt32(reader[11]);
                node.ReadCust = Convert.ToInt32(reader[12]);
                node.AddNewCust = Convert.ToInt32(reader[13]);
                node.ChangeCust = Convert.ToInt32(reader[14]);
                node.DeleteCust = Convert.ToInt32(reader[15]);
                node.ReadOperLog = Convert.ToInt32(reader[16]);
                node.DeleteOperLog = Convert.ToInt32(reader[17]);
                node.AddOperator = Convert.ToInt32(reader[18]);
                node.ChangeOperator = Convert.ToInt32(reader[19]);
                node.DeleteOperator = Convert.ToInt32(reader[20]);
                node.AddNewPrivilege = Convert.ToInt32(reader[21]);
                node.ChangePrivilege = Convert.ToInt32(reader[22]);
                node.DeletePrivilege = Convert.ToInt32(reader[23]);
                #endregion
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过ID查找用户权限表项目
        /// </summary>
        /// <param name="ID">需要查找的ID</param>
        /// <returns>返回项目对象，如果ID为-1则为查找失败</returns>
        public static AuthPrivilege FindCustDegreeByID(int ID)
        {
            AuthPrivilege node = new AuthPrivilege();
            node.AuthID = -1;

            string str = "select AuthID,AuthName,AuthDegree,AddNewRoom,ReadRoom,ChangeRoom,DeleteRoom,ReadRoomStatus,ChangeRoomStatus,ReadCheckLog,ChangeCheckLog,DeleteCheckLog,ReadCust,AddNewCust,ChangeCust,DeleteCust,ReadOperLog,DeleteOperLog,AddOperator,ChangeOperator,DeleteOperator,AddNewPrivilege,ChangePrivilege,DeletePrivilege from AuthPrivilege where AuthID = @index";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };
            para[0].Value = ID;

            SqlDataReader reader = SqlHelper.ExecuteReader(str, para);

            while (reader.Read())
            {
                #region 节点赋值
                node.AuthID = Convert.ToInt32(reader[0]);
                node.AuthName = reader[1].ToString();
                node.AuthDegree = Convert.ToInt32(reader[2]);
                node.AddNewRoom = Convert.ToInt32(reader[3]);
                node.ReadRoom = Convert.ToInt32(reader[4]);
                node.ChangeRoom = Convert.ToInt32(reader[5]);
                node.DeleteRoom = Convert.ToInt32(reader[6]);
                node.ReadRoomStatus = Convert.ToInt32(reader[7]);
                node.ChangeRoomStatus = Convert.ToInt32(reader[8]);
                node.ReadCheckLog = Convert.ToInt32(reader[9]);
                node.ChangeCheckLog = Convert.ToInt32(reader[10]);
                node.DeleteCheckLog = Convert.ToInt32(reader[11]);
                node.ReadCust = Convert.ToInt32(reader[12]);
                node.AddNewCust = Convert.ToInt32(reader[13]);
                node.ChangeCust = Convert.ToInt32(reader[14]);
                node.DeleteCust = Convert.ToInt32(reader[15]);
                node.ReadOperLog = Convert.ToInt32(reader[16]);
                node.DeleteOperLog = Convert.ToInt32(reader[17]);
                node.AddOperator = Convert.ToInt32(reader[18]);
                node.ChangeOperator = Convert.ToInt32(reader[19]);
                node.DeleteOperator = Convert.ToInt32(reader[20]);
                node.AddNewPrivilege = Convert.ToInt32(reader[21]);
                node.ChangePrivilege = Convert.ToInt32(reader[22]);
                node.DeletePrivilege = Convert.ToInt32(reader[23]);
                #endregion
            }

            reader.Close();

            return node;
        }

        /// <summary>
        /// 添加新的用户权限对象
        /// </summary>
        /// <param name="newname">权限名称</param>
        /// <param name="Degree">权限等级，数字越小等级越高</param>
        /// <param name="addnewroom">添加新房间的权限</param>
        /// <param name="readroom">读取房间信息的权限</param>
        /// <param name="changeroom">修改房间信息的权限</param>
        /// <param name="deleteroom">删除房间的权限</param>
        /// <param name="readroomstatus">读取房间状态的权限</param>
        /// <param name="changeroomstatus">修改房间状态的权限</param>
        /// <param name="readchecklog">读取入住日志的权限</param>
        /// <param name="changechecklog">修改入住日志的权限</param>
        /// <param name="deletechecklog">删除入住日志的权限</param>
        /// <param name="readcust">读取客户资料的权限</param>
        /// <param name="addnewcust">添加新客户的权限</param>
        /// <param name="changecust">修改客户资料的权限</param>
        /// <param name="deletecust">删除客户资料的权限</param>
        /// <param name="readoperlog">读取操作日志的权限</param>
        /// <param name="deleteoperlog">删除操作日志的权限</param>
        /// <param name="addoperator">添加操作者（职工）的权限</param>
        /// <param name="changeoperator">修改操作者（职工）的权限</param>
        /// <param name="deleteoperator">删除操作者（职工）的权限</param>
        /// <param name="addnewpri">添加新权限的权限</param>
        /// <param name="changenewpri">修改权限的权限</param>
        /// <param name="deletepri">删除权限的权限</param>
        /// <returns>返回1为成功添加，返回-1为检测重复添加失败，-100为异常</returns>
        public static int AddNewAuthPrivilege(string newname, int Degree, bool addnewroom, bool readroom, bool changeroom, bool deleteroom, bool readroomstatus, bool changeroomstatus, bool readchecklog, bool changechecklog, bool deletechecklog, bool readcust, bool addnewcust, bool changecust, bool deletecust, bool readoperlog, bool deleteoperlog, bool addoperator, bool changeoperator, bool deleteoperator, bool addnewpri, bool changenewpri, bool deletepri)
        {
            string sqlstr = "if not exists (select AuthName from AuthPrivilege where AuthName= @newname )" +
    " insert into AuthPrivilege (AuthName,AuthDegree,AddNewRoom,ReadRoom,ChangeRoom,DeleteRoom,ReadRoomStatus,ChangeRoomStatus,ReadCheckLog,ChangeCheckLog,DeleteCheckLog,ReadCust,AddNewCust,ChangeCust,DeleteCust,ReadOperLog,DeleteOperLog,AddOperator,ChangeOperator,DeleteOperator,AddNewPrivilege,ChangePrivilege,DeletePrivilege) "+
    "VALUES (@newname,@degree,@addnewroom,@readroom,@changeroom,@deleteroom,@readroomstatus,@changeroomstatus,@readchecklog,@changechecklog,@deletechecklog,@readcust,@addnewcust,@changecust,@deletecust,@readoperlog,@deleteoperlog,@addoperator,@changeoperator,@deleteoperator,@addnewpri,@changenewpri,@deletepri)";
            SqlParameter[] para = new SqlParameter[]
            {
                #region 参数表
                new SqlParameter("@newname",SqlDbType.VarChar),
                new SqlParameter("@degree",SqlDbType.Int),
                new SqlParameter("@addnewroom",SqlDbType.Int),
                new SqlParameter("@readroom",SqlDbType.Int),
                new SqlParameter("@changeroom",SqlDbType.Int),
                new SqlParameter("@deleteroom",SqlDbType.Int),
                new SqlParameter("@readroomstatus",SqlDbType.Int),
                new SqlParameter("@changeroomstatus",SqlDbType.Int),
                new SqlParameter("@readchecklog",SqlDbType.Int),
                new SqlParameter("@changechecklog",SqlDbType.Int),
                new SqlParameter("@deletechecklog",SqlDbType.Int),
                new SqlParameter("@readcust",SqlDbType.Int),
                new SqlParameter("@addnewcust",SqlDbType.Int),
                new SqlParameter("@changecust",SqlDbType.Int),
                new SqlParameter("@deletecust",SqlDbType.Int),
                new SqlParameter("@readoperlog",SqlDbType.Int),
                new SqlParameter("@deleteoperlog",SqlDbType.Int),
                new SqlParameter("@addoperator",SqlDbType.Int),
                new SqlParameter("@changeoperator",SqlDbType.Int),
                new SqlParameter("@deleteoperator",SqlDbType.Int),
                new SqlParameter("@addnewpri",SqlDbType.Int),
                new SqlParameter("@changenewpri",SqlDbType.Int),
                new SqlParameter("@deletepri",SqlDbType.Int),
                #endregion
            };

            #region 参数表赋值
            para[0].Value = newname;
            para[1].Value = Degree;
            para[2].Value = addnewroom == true ? 1 : 0;
            para[3].Value = readroom == true ? 1 : 0;
            para[4].Value = changeroom == true ? 1 : 0;
            para[5].Value = deleteroom == true ? 1 : 0;
            para[6].Value = readroomstatus == true ? 1 : 0;
            para[7].Value = changeroomstatus == true ? 1 : 0;
            para[8].Value = readchecklog == true ? 1 : 0;
            para[9].Value = changechecklog == true ? 1 : 0;
            para[10].Value = deletechecklog == true ? 1 : 0;
            para[11].Value = readcust == true ? 1 : 0;
            para[12].Value = addnewcust == true ? 1 : 0;
            para[13].Value = changecust == true ? 1 : 0;
            para[14].Value = deletecust == true ? 1 : 0;
            para[15].Value = readoperlog == true ? 1 : 0;
            para[16].Value = deleteoperlog == true ? 1 : 0;
            para[17].Value = addoperator == true ? 1 : 0;
            para[18].Value = changeoperator == true ? 1 : 0;
            para[19].Value = deleteoperator == true ? 1 : 0;
            para[20].Value = addnewpri == true ? 1 : 0;
            para[21].Value = changenewpri == true ? 1 : 0;
            para[22].Value = deletepri == true ? 1 : 0;
            #endregion

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 修改用户权限内容，保证修改项传入准确即可，其他项符合变量规则即可
        /// </summary>
        /// <param name="ID">需要修改的ID</param>
        /// <param name="newname">新名称</param>
        /// <param name="Degree">用户权限等级</param>
        /// <param name="addnewroom">添加新房间的权限</param>
        /// <param name="readroom">读取房间信息的权限</param>
        /// <param name="changeroom">修改房间信息的权限</param>
        /// <param name="deleteroom">删除房间的权限</param>
        /// <param name="readroomstatus">读取房间状态的权限</param>
        /// <param name="changeroomstatus">修改房间状态的权限</param>
        /// <param name="readchecklog">读取入住日志的权限</param>
        /// <param name="changechecklog">修改入住日志的权限</param>
        /// <param name="deletechecklog">删除入住日志的权限</param>
        /// <param name="readcust">读取客户资料的权限</param>
        /// <param name="addnewcust">添加新客户的权限</param>
        /// <param name="changecust">修改客户资料的权限</param>
        /// <param name="deletecust">删除客户资料的权限</param>
        /// <param name="readoperlog">读取操作日志的权限</param>
        /// <param name="deleteoperlog">删除操作日志的权限</param>
        /// <param name="addoperator">添加操作者（职工）的权限</param>
        /// <param name="changeoperator">修改操作者（职工）的权限</param>
        /// <param name="deleteoperator">删除操作者（职工）的权限</param>
        /// <param name="addnewpri">添加新权限的权限</param>
        /// <param name="changenewpri">修改权限的权限</param>
        /// <param name="deletepri">删除权限的权限</param>
        /// <param name="type">需要修改的项，从1至23（自己数吧）</param>
        /// <returns>返回1为修改成功，-100为异常</returns>
        public static int ChangeAuthPrivilege(int ID, string newname, int Degree, bool addnewroom, bool readroom, bool changeroom, bool deleteroom, bool readroomstatus, bool changeroomstatus, bool readchecklog, bool changechecklog, bool deletechecklog, bool readcust, bool addnewcust, bool changecust, bool deletecust, bool readoperlog, bool deleteoperlog, bool addoperator, bool changeoperator, bool deleteoperator, bool addnewpri, bool changenewpri, bool deletepri, int type)
        {
            string ColName = "";

            SqlParameter value=null;
            SqlParameter ChangedID=new SqlParameter("@ID",SqlDbType.Int);
            ChangedID.Value=ID;

            switch (type)
            {
                #region switch处理选择
                case 1:
                    ColName = "AuthName";
                    value = new SqlParameter("@newvalue", SqlDbType.VarChar);
                    value.Value = newname;
                    break;
                case 2:
                    ColName = "AuthDegree";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = Degree;
                    break;
                case 3:
                    ColName = "AddNewRoom";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = addnewroom == true ? 1 : 0;
                    break;
                case 4:
                    ColName = "ReadRoom";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = readroom == true ? 1 : 0;
                    break;
                case 5:
                    ColName = "ChangeRoom";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = changeroom == true ? 1 : 0;
                    break;
                case 6:
                    ColName = "DeleteRoom";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = deleteroom == true ? 1 : 0;
                    break;
                case 7:
                    ColName = "ReadRoomStatus";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = readroomstatus == true ? 1 : 0;
                    break;
                case 8:
                    ColName = "ChangeRoomStatus";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = changeroomstatus == true ? 1 : 0;
                    break;
                case 9:
                    ColName = "ReadCheckLog";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = readchecklog == true ? 1 : 0;
                    break;
                case 10:
                    ColName = "ChangeCheckLog";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = changechecklog == true ? 1 : 0;
                    break;
                case 11:
                    ColName = "DeleteCheckLog";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = deletechecklog == true ? 1 : 0;
                    break;
                case 12:
                    ColName = "ReadCust";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = readcust == true ? 1 : 0;
                    break;
                case 13:
                    ColName = "AddNewCust";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = addnewcust == true ? 1 : 0;
                    break;
                case 14:
                    ColName = "ChangeCust";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = changecust == true ? 1 : 0;
                    break;
                case 15:
                    ColName = "DeleteCust";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = deletecust == true ? 1 : 0;
                    break;
                case 16:
                    ColName = "ReadOperLog";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = readoperlog == true ? 1 : 0;
                    break;
                case 17:
                    ColName = "DeleteOperLog";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = deleteoperlog == true ? 1 : 0;
                    break;
                case 18:
                    ColName = "AddOperator";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = addoperator == true ? 1 : 0;
                    break;
                case 19:
                    ColName = "ChangeOperator";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = changeoperator == true ? 1 : 0;
                    break;
                case 20:
                    ColName = "DeleteOperator";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = deleteoperator == true ? 1 : 0;
                    break;
                case 21:
                    ColName = "AddNewPrivilege";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = addnewpri == true ? 1 : 0;
                    break;
                case 22:
                    ColName = "ChangePrivilege";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = changenewpri == true ? 1 : 0;
                    break;
                case 23:
                    ColName = "DeletePrivilege";
                    value = new SqlParameter("@newvalue", SqlDbType.Int);
                    value.Value = deletepri == true ? 1 : 0;
                    break;
                #endregion
            }

            string sqlstr = "update AuthPrivilege SET " + ColName + " = @newvalue where AuthID = @ID";

            SqlParameter[] para=new SqlParameter[]
            {
                value,ChangedID
            };

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 通过ID删除用户权限项目
        /// </summary>
        /// <param name="statusID">需要删除的ID</param>
        /// <returns>返回1为删除成功，0为不存在无法删除，-100为异常</returns>
        public static int DeleteCustStatus(int statusID)
        {
            string sqlstr = "delete from AuthPrivilege where AuthID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = statusID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }
    }
}
