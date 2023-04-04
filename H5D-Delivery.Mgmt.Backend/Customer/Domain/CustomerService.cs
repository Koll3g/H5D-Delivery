using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Customer.Domain
{
    internal class CustomerService
    {
        private readonly IContainer _iocContainer;

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IContainer iocContainer)
        {
            _iocContainer = iocContainer;
            _customerRepository = _iocContainer.Resolve<ICustomerRepository>();
        }
    }
}
