using Autofac;
using H5D_Delivery.Mgmt.Backend.Customer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Customer.Domain;
using H5D_Delivery.Mgmt.Backend.Product.Domain;
using H5D_Delivery.Mgmt.Backend.Product.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Shared
{
    public class IocSetup
    {
        public IContainer GetContainer()
        {
            //After implementation of repo, switch to real repositories
            return GetFakeContainer();
        }

        public IContainer GetFakeContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<FakeCustomerRepository>().As<ICustomerRepository>();
            containerBuilder.RegisterType<FakeProductRepository>().As<IProductRepository>();
            var container = containerBuilder.Build();
            return container;
        }
    }
}
