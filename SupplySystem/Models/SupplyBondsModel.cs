using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplySystem.Models
{
    public class SupplyBondsModel
    {
        public int OP_ID { get; set; }
        public DateTime OP_DATE { get; set; }
        public string JULIAN_DATE { get; set; }
        public string SERIAL_NO { get; set; }
        public int SEND_TO_SIDE_NO { get; set; }
        public string StorageNumber { get; set; }
        public string REQUEST_FOR { get; set; } = "0";
        public string FIELD_PRIORITY { get; set; } = "0";
        public string INITIAL_SIGNATURE { get; set; } = "0";
        public int REQUIRED_QTY { get; set; }
        public int RECEIVED_QTY { get; set; }
        public int WAITING_ENTRY_QTY { get; set; }
        public string FOLLOW_UP_DATE { get; set; } = "0";
        public string COMPLETION_DATE { get; set; } = "0";
        public int NOTES_SIDE_NO { get; set; }
        public int AD_U_ID { get; set; }
        public DateTime AD_DATE { get; set; }
        public int UP_U_ID { get; set; }
        public DateTime UP_DATE { get; set; }
        public string AD_TRMNL_NM { get; set; }
        public string UP_TRMNL_NM { get; set; }
    }
}