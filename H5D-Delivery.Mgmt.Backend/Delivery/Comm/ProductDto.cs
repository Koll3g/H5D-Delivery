using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Stock.Domain;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Comm
{
    public class ProductDto
    {
        public Guid productId { get; set; }
        public int storageLocation { get; set; }
        public uint quantity { get; set; }

    }
}
