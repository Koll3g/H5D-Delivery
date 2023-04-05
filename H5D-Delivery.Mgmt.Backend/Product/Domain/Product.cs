using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared;

namespace H5D_Delivery.Mgmt.Backend.Product.Domain
{
    public class Product : DbItem
    {
        public string Name { get; set; }

        public Product(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
