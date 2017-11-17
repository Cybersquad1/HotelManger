using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelModels;
using HotelDBA;

namespace HotelLogic
{
    public class CheckInLogManager
    {
        public static int AddNewLog(int custid,int roomid,DateTime begin,DateTime end,int cash,int price,double recmoney,int status)
        {
            return CheckInLogService.AddNewCheckInLog(custid, roomid, begin, end, cash, price, recmoney, status);
        }

        public static List<CheckInLog> GetList(int id)
        {
            List<CheckInLog> loglist = CheckInLogService.GetCheckInLogByIDorCust(-1, id, 2);

            return loglist;
        }
    }
}
