using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplySystem.Models
{
    public class SparePartsModel
    {
        public string StorageNumber { get; set; }
        public string PieceName { get; set; }
        public int AD_U_ID { get; set; }
        public DateTime AD_DATE { get; set; }
        public int UP_U_ID { get; set; }
        public DateTime UP_DATE { get; set; }
        public string AD_TRMNL_NM { get; set; }
        public string UP_TRMNL_NM { get; set; }
    }
}
