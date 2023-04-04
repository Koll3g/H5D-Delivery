using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using H5D_Delivery.Mgmt.Backend.Customer.Domain;
using H5D_Delivery.Mgmt.Backend.Shared;

namespace H5D_Delivery.Mgmt.Backend.UnitTests.Customer
{
    public class CustomerServiceTests
    {
        private readonly CustomerService _customerService;
        
        public CustomerServiceTests()
        {
            var iocSetup = new IocSetup();
            _customerService = new CustomerService(iocSetup.GetFakeContainer());
        }

        [Fact]
        public void IsCustomerValid_ProvidedWithValidCustomer_ReturnsTrue()
        {
            var customer =
                new Backend.Customer.Domain.Customer(new Guid(), "Hans", "Zbw-Strasse 3", "asdf@zbw.ch", "07865746");
        }

    }
}
