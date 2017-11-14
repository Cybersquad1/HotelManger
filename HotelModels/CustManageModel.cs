using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelModels
{
    public class CustManageModel
    {
        public int CustID { get; set; }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string CustDegree { get; set; }
        public int Money { get; set; }
        public int CheckCount { get; set; }
        public string CustStatus { get; set; }
    }
}
