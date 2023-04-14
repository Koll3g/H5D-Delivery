using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Order.Exceptions
{
    public class TimeFrameInvalidException : Exception
    {
        public TimeFrameInvalidException(string message) : base(message) { }
    }
}
