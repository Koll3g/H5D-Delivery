using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Customer.Exceptions
{
    public class AddressInvalidException : Exception
    {
        public AddressInvalidException(string message) : base(message){ }
    }
}
