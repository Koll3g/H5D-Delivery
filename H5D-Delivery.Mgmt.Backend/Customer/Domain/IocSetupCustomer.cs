using Autofac;
using H5D_Delivery.Mgmt.Backend.Customer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Customer.Domain
{
    public static class IocSetupCustomer
    {
        public static IContainer SetupContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<FakeCustomerRepository>().As<ICustomerRepository>();
            var container = containerBuilder.Build();
            return container;
        }
    }
}
