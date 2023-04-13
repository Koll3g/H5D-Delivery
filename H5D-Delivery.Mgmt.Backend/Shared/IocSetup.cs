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
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            containerBuilder.RegisterType<CustomerService>().As<CustomerService>();
            containerBuilder.RegisterType<CustomerContext>().As<CustomerContext>();

            containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>();
            containerBuilder.RegisterType<ProductContext>().As<ProductContext>();
            containerBuilder.RegisterType<ProductService>().As<ProductService>();

            var container = containerBuilder.Build();
            return container;
        }

        public IContainer GetFakeContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<FakeCustomerRepository>().As<ICustomerRepository>();
            containerBuilder.RegisterType<CustomerService>().As<CustomerService>();

            containerBuilder.RegisterType<FakeProductRepository>().As<IProductRepository>();
            containerBuilder.RegisterType<ProductService>().As<ProductService>();

            var container = containerBuilder.Build();
            return container;
        }
    }
}
