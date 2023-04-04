using Autofac;
using H5D_Delivery.Mgmt.Backend.Customer.Domain;
using H5D_Delivery.Mgmt.Backend.Customer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Shared
{
    public class IocSetup
    {
        public IContainer GetProdContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<FakeCustomerRepository>().As<ICustomerRepository>();
            var container = containerBuilder.Build();
            return container;
        }

        public IContainer GetFakeContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<FakeCustomerRepository>().As<ICustomerRepository>();
            var container = containerBuilder.Build();
            return container;
        }
    }
}
