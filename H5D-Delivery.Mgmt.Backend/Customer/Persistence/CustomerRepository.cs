using H5D_Delivery.Mgmt.Backend.Customer.Domain;
using H5D_Delivery.Mgmt.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Customer.Persistence
{
    public class CustomerRepository : RepositoryBase<Domain.Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext) : base(customerContext) { }
    }
}
