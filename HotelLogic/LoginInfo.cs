using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLogic
{
    public class LoginInfo
    {
        public static string Account = "";
        public static int DegreeLevel = -1;
        public static int OperID = -1;
        public static string Name = "";

        public static void Init()
        {
            Account = "";
            DegreeLevel = -1;
            OperID = -1;
            Name = "";
        }
    }
}
