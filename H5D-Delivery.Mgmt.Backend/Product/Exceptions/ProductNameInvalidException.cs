using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Product.Exceptions
{
    public class ProductNameInvalidException : Exception
    {
        public ProductNameInvalidException(string message) : base(message) { }
    }
}
