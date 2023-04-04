using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Customer.Domain
{
    public class Customer : IEqualityComparer<Customer>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(Guid id, string name, string address, string eMail, string phoneNumber)
        {
            Id = id;
            Name = name;
            Address = address;
            EMail = eMail;
            PhoneNumber = phoneNumber;
        }

        public bool Equals(Customer x, Customer y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(Customer obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
