using Autofac;
using H5D_Delivery.Mgmt.Backend.Customer.Persistence;
using H5D_Delivery.Mgmt.Backend.Customer.Domain;
using H5D_Delivery.Mgmt.Backend.Order.Domain;
using H5D_Delivery.Mgmt.Backend.Order.Persistence;
using H5D_Delivery.Mgmt.Backend.Product.Domain;
using H5D_Delivery.Mgmt.Backend.Product.Persistence;
using H5D_Delivery.Mgmt.Backend.Robot.Comm;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Robot.Persistence.Battery;
using H5D_Delivery.Mgmt.Backend.Stock.Domain;
using H5D_Delivery.Mgmt.Backend.Stock.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Shared.IoC
{
    public class IocSetup
    {
        //public IContainer GetContainer()
        //{
        //    var containerBuilder = new ContainerBuilder();

        //    containerBuilder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
        //    containerBuilder.RegisterType<CustomerService>().As<CustomerService>();
        //    containerBuilder.RegisterType<CustomerContext>().As<CustomerContext>();

        //    containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>();
        //    containerBuilder.RegisterType<ProductContext>().As<ProductContext>();
        //    containerBuilder.RegisterType<ProductService>().As<ProductService>();

        //    containerBuilder.RegisterType<StockRepository>().As<IStockRepository>();
        //    containerBuilder.RegisterType<StockContext>().As<StockContext>();
        //    containerBuilder.RegisterType<StockService>().As<StockService>();

        //    containerBuilder.RegisterType<OrderRepository>().As<IOrderRepository>();
        //    containerBuilder.RegisterType<OrderContext>().As<OrderContext>();
        //    containerBuilder.RegisterType<OrderService>().As<OrderService>();

        //    containerBuilder.RegisterType<BatteryChargeListener>().SingleInstance();

        //    var container = containerBuilder.Build();

        //    return container;
        //}

        private static IocSetup _instance;
        private static readonly object _lock = new object();

        public static IocSetup Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new IocSetup();
                        }
                    }
                }
                return _instance;
            }
        }

        public IContainer Container { get; }

        private IocSetup()
        {
            var containerBuilder = new ContainerBuilder();

            // Register your dependencies here
            containerBuilder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            containerBuilder.RegisterType<CustomerService>().As<CustomerService>();
            containerBuilder.RegisterType<CustomerContext>().As<CustomerContext>();

            containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>();
            containerBuilder.RegisterType<ProductContext>().As<ProductContext>();
            containerBuilder.RegisterType<ProductService>().As<ProductService>();

            containerBuilder.RegisterType<StockRepository>().As<IStockRepository>();
            containerBuilder.RegisterType<StockContext>().As<StockContext>();
            containerBuilder.RegisterType<StockService>().As<StockService>();

            containerBuilder.RegisterType<OrderRepository>().As<IOrderRepository>();
            containerBuilder.RegisterType<OrderContext>().As<OrderContext>();
            containerBuilder.RegisterType<OrderService>().As<OrderService>();

            containerBuilder.RegisterType<BatteryChargeRepository>().As<IBatteryChargeRepository>();
            containerBuilder.RegisterType<BatteryChargeContext>().As<BatteryChargeContext>();
            containerBuilder.RegisterType<BatteryService>().As<BatteryService>();
            containerBuilder.RegisterType<BatteryChargeListener>().SingleInstance();

            Container = containerBuilder.Build();
        }

    }
}
