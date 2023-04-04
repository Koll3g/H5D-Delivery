using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Customer.Exceptions
{
    public class PhoneNumberInvalidException : Exception
    {
        public PhoneNumberInvalidException(string message) : base(message) { }
    }
}
