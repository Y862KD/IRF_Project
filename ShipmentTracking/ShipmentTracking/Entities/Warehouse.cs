using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracking.Entities
{
    public class Warehouse
    {
        public int CustomerCode { get; set; }
        public int OrderNumber { get; set; }
        public int PackageNumber { get; set; }
        public string PickUpDate { get; set; }
    }
}
