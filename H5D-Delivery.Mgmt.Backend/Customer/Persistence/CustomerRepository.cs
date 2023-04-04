using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Customer.Domain;

namespace H5D_Delivery.Mgmt.Backend.Customer.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Domain.Customer> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Domain.Customer? Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Create(Domain.Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
