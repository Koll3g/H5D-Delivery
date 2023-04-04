using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Customer.Domain
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll(Guid id);

        Customer Get(Guid id);

        void Update(Customer customer);

        void Delete(Guid id);

        void Create(Customer customer);
    }
}
