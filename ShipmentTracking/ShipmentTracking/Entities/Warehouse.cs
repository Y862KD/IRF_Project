using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracking.Entities
{
    public class Warehouse
    {
        public int OrderNumber { get; set; }
        public int PackageNumber { get; set; }
        public int PickUpDate { get; set; }
    }
}
