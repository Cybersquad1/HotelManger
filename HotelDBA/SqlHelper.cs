using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DBHelper
{
    public class SqlHelper
    {
        private static string connstr = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
        
        /// <summary>
        /// 增删改，返回受影响的行数（适用于update、insert、delete语句，其他语句均会返回-1）
        /// </summary>
        /// <param name="sql">带表变量的查询语句（不带亦可）</param>
        /// <param name="parameters">参数对应的值，可留空</param>
        /// <returns>出现语句错误将会返回-100</returns>
        public static int ExecuteNonQuery(string sql,params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;//将语句进行赋值
                        cmd.Parameters.AddRange(parameters);//代入参数
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException e)
            {
                return -100;
            }
        }

        #region 对ExecuteNonQuery函数使用的示范（需引用System.Data.SqlClient）
        //string cmd = "select COUNT(*) from RoomType where TypePrice=@count";
        //SqlParameter []paras=new SqlParameter[]
        //{
        //    new SqlParameter("@count","80")
        //};
        //MessageBox.Show(Convert.ToString(DBHelper.SqlHelper.ExecuteNonQuery(cmd,paras)));
        #endregion

        /// <summary>
        /// 通过语句查询返回表数据
        /// </summary>
        /// <param name="sql">带表变量的查询语句（不带亦可）</param>
        /// <param name="param">参数对应的值，可留空</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql,params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(param);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet set = new DataSet();
                    adapter.Fill(set);

                    return set.Tables[0];
                }
            }
        }

        #region 对ExecuteDataTable函数使用的示范（需引用System.Data.SqlClient）
        //string sqlcmd = "select TypeName,TypePrice from RoomType where TypePrice > @price";
            //SqlParameter[] paras = new SqlParameter[]
            //{
            //    new SqlParameter("@price",80)
            //};

            //DataTable table = DBHelper.SqlHelper.ExecuteDataTable(sqlcmd, paras);
            //string output = "";

            //foreach(DataRow row in table.Rows)
            //{
            //    output += Convert.ToString(row["TypePrice"]);
            //}

        //MessageBox.Show(output);
        #endregion

        /// <summary>
        /// 查询并返回一个sqlreader对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql,params SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(param);

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        #region 对ExecuteReader函数使用的示范（需引用System.Data.SqlClient）
        //string sql = "select * from RoomType where TypePrice > @price";
            //SqlParameter[] para = new SqlParameter[]{
            //    new SqlParameter("@price",SqlDbType.Int),
            //};
            //para[0].Value = 60;
            //SqlDataReader dr = DBHelper.SqlHelper.ExecuteReader(sql,para);
            //string output = "";
            //while(dr.Read())
            //{
            //    output += dr[0].ToString() + ":" + dr[1].ToString() + "\r\n";
            //}
            //dr.Close();
        //MessageBox.Show(output);
        #endregion

        /// <summary>
        /// 执行查询，返回第一行第一列的内容，其他内容会被忽略
        /// </summary>
        /// <param name="sql">执行语句，可带表变量</param>
        /// <param name="param">表变量对应的实际值</param>
        /// <returns>返回object对象，可以自己进行强制转换</returns>
        public static object ExecuteScalar(string sql,params SqlParameter[] param)
        {
            using (SqlConnection conn=new SqlConnection(connstr))
            {
                conn.Open();

                using (SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(param);

                    return cmd.ExecuteScalar();
                }
            }
        }

        #region 对ExecuteScalar函数使用的示范（需引用System.Data.SqlClient）
        //string sql = "select TypeName,TypePrice from RoomType where TypeID > @price";
            //SqlParameter[] para = new SqlParameter[]{
            //    new SqlParameter("@price",SqlDbType.Int),
            //};
            //para[0].Value = 1;

            //string str = Convert.ToString(DBHelper.SqlHelper.ExecuteScalar(sql, para));

        //MessageBox.Show(str);
        #endregion
    }
}
