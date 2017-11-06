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
    /// 在数据访问层提供对模块类型表的访问支持
    /// </summary>
    public class ModelTypeService
    {
        /// <summary>
        /// 获取所有模块类型的对象
        /// </summary>
        /// <returns>返回list</returns>
        public static List<ModelType> GetAllEventType()
        {
            List<ModelType> list = new List<ModelType>();

            string sqlstr = "select ModelID,ModelName from ModelType";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while (reader.Read())
            {
                ModelType node = new ModelType();
                node.ModelID = Convert.ToInt32(reader[0]);
                node.ModelName = reader[1].ToString();
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过关键词查找指定模块类型的对象，支持模糊查找
        /// </summary>
        /// <param name="keyword">需要查找的关键词</param>
        /// <param name="FuzzyMode">模糊查找模式开关，true为开启，false为关闭</param>
        /// <returns></returns>
        public static List<ModelType> FindModelTypeListByKeyword(string keyword, bool FuzzyMode)
        {
            List<ModelType> list = new List<ModelType>();

            string FindStr = "";

            if (FuzzyMode == true)
            {
                FindStr = " like ";
            }
            else
            {
                FindStr = " = ";
            }

            string sqlstr = "SELECT ModelID,ModelName from ModelType where ModelName" + FindStr + "@SearchName";
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
                ModelType node = new ModelType();
                node.ModelID = Convert.ToInt32(reader[0]);
                node.ModelName = Convert.ToString(reader[1]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过ID查找指定模块类型的对象
        /// </summary>
        /// <param name="TypeID">需要查找的ID</param>
        /// <returns>如果返回的对象ID为-1则为查找失败，其他情况为查找成功</returns>
        public static ModelType FindModelTypeByID(int TypeID)
        {
            ModelType node = new ModelType();
            node.ModelID = -1;

            string querystr = "SELECT ModelID,ModelName from ModelType where ModelID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };
            para[0].Value = TypeID;

            SqlDataReader reader = SqlHelper.ExecuteReader(querystr, para);

            while (reader.Read())
            {
                node.ModelID = Convert.ToInt32(reader[0]);
                node.ModelName = reader[1].ToString();
            }

            reader.Close();

            return node;
        }


    }
}
