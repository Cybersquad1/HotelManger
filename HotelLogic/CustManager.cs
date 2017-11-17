using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDBA;
using HotelModels;

namespace HotelLogic
{
    public class CustManager
    {
        /// <summary>
        /// 通过身份证号获取用户ID
        /// </summary>
        /// <param name="IDNumber">身份证号</param>
        /// <returns>返回用户ID，如果为-1为查找失败</returns>
        public static int GetCustIDByIDNumber(string IDNumber)
        {
            return CustomerService.FindCustomerListByCodeOrID(-1, IDNumber, 2).CustomerID;
        }

        /// <summary>
        /// 当身份证号码存在时验证姓名是否可以对应
        /// </summary>
        /// <param name="IDNumber"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static bool IsNameBelongToIDNumber(string IDNumber,string Name)
        {
            string name = CustomerService.FindCustomerListByCodeOrID(-1, IDNumber, 2).Name;

            return name == Name;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<CustManageModel> GetModelList()
        {
            List<Customer> list = CustomerService.GetCustomerList();
            List<CustManageModel> custlist = new List<CustManageModel>();

            foreach(Customer i in list)
            {
                CustManageModel node = new CustManageModel();
                node.CustID = i.CustomerID;
                node.IDNumber = i.IDNumber;
                node.Name = i.Name;
                node.CustDegree = CustDegreeService.FindCustDegreeByID(i.DrgreeID).DegreeName;
                node.Money = i.TotalMoney;
                node.CheckCount = i.CheckInCount;
                node.CustStatus = CustStatusService.FindCustStatusByID(i.StatusID).StatusName;
                custlist.Add(node);
            }

            return custlist;
        }

        public static List<string> GetDegreeList()
        {
            List<CustDegree> lists = CustDegreeService.GetAllDegreeStatus();
            List<string> output = new List<string>();

            foreach(CustDegree i in lists)
            {
                output.Add(i.DegreeName);
            }

            return output;
        }

        public static List<string> GetStatusList()
        {
            List<CustStatus> lists = CustStatusService.GetAllCustStatus();
            List<string> output = new List<string>();

            foreach(CustStatus i in lists)
            {
                output.Add(i.StatusName);
            }

            return output;
        }

        //姓名
        //用户级别
        //总消费
        //入住次数
        //客户状态
        /// <summary>
        /// 修改顾客资料
        /// </summary>
        /// <param name="IDNumber">需要修改的身份证号码</param>
        /// <param name="Name"></param>
        /// <param name="Degree"></param>
        /// <param name="money"></param>
        /// <param name="checkincount"></param>
        /// <param name="CustStatus"></param>
        /// <param name="type">从1-5</param>
        /// <returns></returns>
        public static int ChangeCustValue(string IDNumber,string Name,string Degree,int money,int checkincount,string CustStatus,int type)
        {
            int id=GetCustIDByIDNumber(IDNumber);
            int statuscode = -10;
            
            switch (type)
            {
                case 1:
                    statuscode = CustomerService.ChangeCustomer(id, Name, "", -1, -1, -1, "", -1, 1);
                    break;
                case 2:
                    int degreeid = CustDegreeService.FindCustDegreeByKeyword(Degree, false)[0].DegreeID;
                    statuscode = CustomerService.ChangeCustomer(id, "", "", degreeid, -1, -1, "", -1, 3);
                    break;
                case 3:
                    statuscode = CustomerService.ChangeCustomer(id, "", "", -1, money, -1, "", -1, 4);
                    break;
                case 4:
                    statuscode = CustomerService.ChangeCustomer(id, "", "", -1, -1, checkincount, "", -1, 5);
                    break;
                case 5:
                    int custstatus = CustStatusService.FindCustStatusByKeyword(CustStatus, false)[0].StatusID;
                    statuscode = CustomerService.ChangeCustomer(id, "", "", -1, -1, -1, "", custstatus, 7);
                    break;
            }

            return statuscode;
        }

        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="Name">姓名</param>
        /// <param name="IDNumber">身份证号</param>
        /// <param name="degree">留空则默认为普通用户</param>
        /// <returns>返回1为添加成功，0为添加失败，-1为重复无法添加</returns>
        public static int AddNewCust(string Name,string IDNumber,string degree)
        {
            int degreeid = degree == "" ? CustDegreeService.FindCustDegreeByKeyword("普通用户", false)[0].DegreeID : CustDegreeService.FindCustDegreeByKeyword(degree, false)[0].DegreeID;

            return CustomerService.AddNewCustomer(Name, IDNumber, degreeid, 0, 0, "", 1);
        }

        public static int DeleteCust(string IDNumber)
        {
            int custid=GetCustIDByIDNumber(IDNumber);

            return CustomerService.DeleteCustomer(custid);
        }

        public static double GetDegreeDisCount(string idnumber)
        {
            int id = CustomerService.FindCustomerListByCodeOrID(-1, idnumber, 2).DrgreeID;

            return CustDegreeService.FindCustDegreeByID(id).RoomDiscount;
        }

        public static bool IsFreeCash(string idnumber)
        {
            int id = CustomerService.FindCustomerListByCodeOrID(-1, idnumber, 2).DrgreeID;

            return CustDegreeService.FindCustDegreeByID(id).PledgeCashDisCount == 1 ? false : true;
        }

        public static int ChangeStatus(string idnumber,int money,int LogIndex)
        {
            int id=GetCustIDByIDNumber(idnumber);
            int totalmoney=CustomerService.FindCustomerListByCodeOrID(id,"",1).TotalMoney;
            int Count=CustomerService.FindCustomerListByCodeOrID(id,"",1).CheckInCount;
            string Logindex=CustomerService.FindCustomerListByCodeOrID(id,"",1).CheckInLogIndex;
            Logindex+=LogIndex.ToString()+",";

            return CustomerService.ChangeCustomer(id, "", "", -1, money + totalmoney, Count + 1, Logindex, 2, 7);
        }

        public static void CheckInChange(string idnumber, int LogIndex)
        {
            int id = GetCustIDByIDNumber(idnumber);
            int Count = CustomerService.FindCustomerListByCodeOrID(id, "", 1).CheckInCount;
            string Logindex = CustomerService.FindCustomerListByCodeOrID(id, "", 1).CheckInLogIndex;
            Logindex += LogIndex.ToString() + ",";

            CustomerService.ChangeCustomer(id, "", "", -1, -1, Count + 1, Logindex, 2, 6);
            CustomerService.ChangeCustomer(id, "", "", -1, -1, Count + 1, Logindex, 2, 5);
        }

        public static void ChangeMoney(string idnumber,int money)
        {
            int id = GetCustIDByIDNumber(idnumber);
            int totalmoney = CustomerService.FindCustomerListByCodeOrID(id, "", 1).TotalMoney;

            CustomerService.ChangeCustomer(id, "", "", -1, totalmoney+money, -1, "", 2, 4);
        }

        public static bool IsFree(string idnumber)
        {
            int id = GetCustIDByIDNumber(idnumber);

            if(CustomerService.FindCustomerListByCodeOrID(id,"",1).StatusID!=1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
