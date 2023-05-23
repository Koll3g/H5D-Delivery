using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.RoboSim
{
    public class ErrorMessageDto
    {
        public Guid deliveryId { get; set; }
        public int step { get; set; }
        public string type { get; set; }
    }
}
