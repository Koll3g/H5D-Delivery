using H5D_Delivery.Mgmt.Backend.Customer.Domain;
using H5D_Delivery.Mgmt.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Customer.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _customerContext;

        public CustomerRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
            _customerContext.Database.Migrate();
        }

        public IEnumerable<Domain.Customer>? GetAll()
        {
            return _customerContext.Customers;
        }

        public Domain.Customer? Get(Guid id)
        {
            var customer = _customerContext.Customers?.Find(id);
            return customer;
        }

        public void Update(Domain.Customer customer)
        {
            _customerContext.Customers?.Update(customer);
            _customerContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var customer = Get(id);
            if (customer != null) _customerContext.Customers?.Remove(customer);
            _customerContext.SaveChanges();
        }

        public void Create(Domain.Customer customer)
        {
            _customerContext.Customers?.Add(customer);
            _customerContext.SaveChanges();
        }
    }
}
