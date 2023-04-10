using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy.Sdk;
using H5D_Delivery.Mgmt.Backend.Customer.Persistence;

namespace H5D_Delivery.Mgmt.Backend.UnitTests.Customer
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public void Create()
        {
            var repo = new CustomerRepository(new CustomerContext());
            var customer = new Backend.Customer.Domain.Customer(new Guid(), "Hans", "Zbw-Strasse 4", "ich@gmail.com", "46574841");
            repo.Create(customer);
        }
    }
}
