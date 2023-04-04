using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Customer.Exceptions
{
    public class EmailInvalidException : Exception
    {
        public EmailInvalidException(string message) : base(message) { }
    }
}
