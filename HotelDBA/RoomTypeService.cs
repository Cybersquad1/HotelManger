using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using HotelModels;
using DBHelper;
using System.Windows.Forms;

namespace HotelDBA
{
    /// <summary>
    /// 在数据访问层提供对房间类型表的访问支持
    /// </summary>
    public class RoomTypeService
    {
        /// <summary>
        /// 获取所有的房间类型
        /// </summary>
        /// <returns></returns>
        public static List<RoomType> GetAllRoomType()
        {
            List<RoomType> list = new List<RoomType>();

            string sqlstr = "SELECT TypeID,TypeName,TypePrice FROM RoomType";
            SqlDataReader reader = SqlHelper.ExecuteReader(sqlstr);

            while(reader.Read())
            {
                RoomType node = new RoomType();
                node.TypeID = Convert.ToInt32(reader[0]);
                node.TypeName = reader[1].ToString();
                node.TypePrice = Convert.ToInt32(reader[2]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过关键词查找指定房间类型，支持模糊查找
        /// </summary>
        /// <param name="name">关键词</param>
        /// <param name="FuzzyMode">模糊查找模式，true为启用，false为禁用</param>
        /// <returns>返回类型为LIST的查找结果列表</returns>
        public static List<RoomType> GetRoomTypeList(string name,bool FuzzyMode)
        {
            List<RoomType> list = new List<RoomType>();

            string FindStr = "";

            if(FuzzyMode==true)
            {
                FindStr = " like ";
            }
            else
            {
                FindStr = " = ";
            }

            string sqlstr = "SELECT TypeID,TypeName,TypePrice FROM RoomType where TypeName" + FindStr + "@SearchName";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@SearchName",SqlDbType.VarChar)
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

            while (reader.Read())
            {
                RoomType node = new RoomType();
                node.TypeID = Convert.ToInt32(reader[0]);
                node.TypeName = reader[1].ToString();
                node.TypePrice = Convert.ToInt32(reader[2]);
                list.Add(node);
            }

            reader.Close();

            return list;
        }

        /// <summary>
        /// 通过房间类型ID查找房间类型信息
        /// </summary>
        /// <param name="TypeID">需要查找的房间类型ID</param>
        /// <returns>返回的类型信息，如果未查找到，类型信息的TypeID为-1</returns>
        public static RoomType GetRoomType(int TypeID)
        {
            RoomType node = new RoomType();
            node.TypeID = -1;

            string querystr = "SELECT TypeID,TypeName,TypePrice FROM RoomType where TypeID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };
            para[0].Value = TypeID;

            SqlDataReader reader = SqlHelper.ExecuteReader(querystr, para);

            while(reader.Read())
            {
                node.TypeID = Convert.ToInt32(reader[0]);
                node.TypeName = reader[1].ToString();
                node.TypePrice = Convert.ToInt32(reader[2]);
            }

            reader.Close();

            return node;
        }

        /// <summary>
        /// 通过房间类型ID删除指定房间类型【NOTE：需要确认当前没有任何记录引用到此类型】
        /// </summary>
        /// <param name="TypeID"></param>
        /// <returns></returns>
        public static int DeleteTypeFromID(int TypeID)
        {
            string sqlstr = "delete from RoomType where TypeID = @index";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@index",SqlDbType.Int)
            };

            para[0].Value = TypeID;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 提供房间类型的名称和价格插入记录，如果名称有重复则不会插入新记录
        /// </summary>
        /// <param name="Price">房间类型价格</param>
        /// <param name="TypeName">房间类型的名字</param>
        /// <returns>如返回1则为插入成功，返回-1则为检测到重复无法插入</returns>
        public static int InsertRoomType(int Price,string TypeName)
        {
            string sqlstr = "if not exists (select TypeName from RoomType where TypeName= @newname ) "
                + "insert into RoomType (TypeName,TypePrice) VALUES (@newname,@price)";//出现重复值则不插入

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@newname",SqlDbType.VarChar),
                new SqlParameter("@price",SqlDbType.Int)
            };

            para[0].Value = TypeName;
            para[1].Value = Price;

            return SqlHelper.ExecuteNonQuery(sqlstr, para);
        }

        /// <summary>
        /// 可以对房间类型的名称或者价格进行修改
        /// </summary>
        /// <param name="type">1为修改价格，2为修改名称</param>
        /// <param name="price">传入需要修改的价格，如果不需要修改可以留-1</param>
        /// <param name="TypeName">传入需要修改的名称，如果不需要修改可以留空</param>
        /// <param name="ID">需要修改的行的对应ID</param>
        /// <returns>返回1为修改成功，-100为修改失败</returns>
        public static int ChangeRoomType(int type,int price,string TypeName,int ID)
        {
            string PriceStr = "UPDATE RoomType SET TypePrice = @price WHERE TypeID = @index";
            string NameStr = "UPDATE RoomType SET TypeName = @name WHERE TypeID = @index";
            string sqlstr="";
            SqlParameter para1;
            SqlParameter para2 = new SqlParameter("@index", SqlDbType.Int);
            para2.Value = ID;

            if(type==1)//修改价格
            {
                para1 = new SqlParameter("@price", SqlDbType.Int);
                para1.Value = price;
                sqlstr=PriceStr;

            }
            else
            {
                para1 = new SqlParameter("@name", SqlDbType.VarChar);
                para1.Value = TypeName;
                sqlstr=NameStr;
            }

            SqlParameter[] paras=new SqlParameter[]
            {
                para1,para2
            };

            return SqlHelper.ExecuteNonQuery(sqlstr, paras);
            
        }

        //设计一个删除后对现存记录排序的函数【待定】
        //思路：获取目前的所有数据->跑循环->确保记录的ID顺序和目前的下标相符
        //出现不相符：记录下当前记录的信息（价格、名称、ID）和目前的下标->
        //使用dbcc语句重置种子到当前下标->插入记录->修改所有已引用此ID的记录为新ID->删除原记录

        //public static void IndexSort()
        //{
        //    List<RoomType> list = GetAllRoomType();
        //    int count = 1;
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].TypeID == count)
        //        {
        //            count++;
        //        }
        //        else
        //        {
        //            int oldindex = list[i].TypeID;
        //            RoomType oldnode = list[i];
        //            string str = "dbcc checkident (RoomType,reseed,@index)";
        //            SqlParameter[] para=new SqlParameter[]
        //            {
        //                new SqlParameter("@index",SqlDbType.Int)
        //            };
        //            para[0].Value = count;
        //            MessageBox.Show("Old Index:" + Convert.ToString(oldindex) + "Status:" + Convert.ToString(SqlHelper.ExecuteNonQuery(str, para)));

        //            str = "insert into RoomType (TypeName,TypePrice) VALUES (@name,@price)";
        //            SqlParameter[] strpara = new SqlParameter[]
        //            {
        //                new SqlParameter("@name",SqlDbType.VarChar),
        //                new SqlParameter("@price",SqlDbType.Int)
        //            };
        //            strpara[0].Value = oldnode.TypeName;
        //            strpara[1].Value = oldnode.TypePrice;
        //            MessageBox.Show("Insert Status:" + Convert.ToString(SqlHelper.ExecuteNonQuery(str, strpara)));
        //            count++;
        //        }
        //    }
        //}
    }
}
