using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Product.Exceptions
{
    public class ProductInvalidException : Exception
    {
        public ProductInvalidException(string message) : base(message) { }
    }
}
