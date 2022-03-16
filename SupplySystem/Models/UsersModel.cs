using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplySystem.Models
{
   public class UsersModel
    {
        public int U_ID { get; set; }
        public string U_NAME { get; set; }
        public string EMAIL { get; set; }
        public string USR_PASSWORD { get; set; }
        public bool INACTIVE { get; set; }
        public int UNIT_NO { get; set; }
        public int AD_U_ID { get; set; }
        public DateTime AD_DATE { get; set; }
        public int UP_U_ID { get; set; }
        public DateTime UP_DATE { get; set; }
        public string AD_TRMNL_NM { get; set; }
        public string UP_TRMNL_NM { get; set; }
    }
}
