using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentTracking.Entities
{
    public class Forwarder
    {
        
        public int PackageNumber { get; set; }
        public string DeliveryStatus { get; set; }
        public string DeliveryDate { get; set; }
    }
}
