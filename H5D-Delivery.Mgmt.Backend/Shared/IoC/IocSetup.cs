using Autofac;
using H5D_Delivery.Mgmt.Backend.Customer.Persistence;
using H5D_Delivery.Mgmt.Backend.Customer.Domain;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryOrderFactory;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryPlanFactory;
using H5D_Delivery.Mgmt.Backend.Order.Domain;
using H5D_Delivery.Mgmt.Backend.Order.Domain.History;
using H5D_Delivery.Mgmt.Backend.Order.Persistence;
using H5D_Delivery.Mgmt.Backend.Order.Persistence.History;
using H5D_Delivery.Mgmt.Backend.Product.Domain;
using H5D_Delivery.Mgmt.Backend.Product.Persistence;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Robot.Persistence.Battery;
using H5D_Delivery.Mgmt.Backend.Stock.Domain;
using H5D_Delivery.Mgmt.Backend.Stock.Persistence;
using H5D_Delivery.Mgmt.Backend.Robot.Comm;
using H5D_Delivery.Mgmt.Backend.Robot.Domain;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Error;
using H5D_Delivery.Mgmt.Backend.Robot.Persistence;
using H5D_Delivery.Mgmt.Backend.Robot.Persistence.Error;

namespace H5D_Delivery.Mgmt.Backend.Shared.IoC
{
    public class IocSetup
    {
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

            containerBuilder.RegisterType<ErrorMessageRepository>().As<IErrorMessageRepository>();
            containerBuilder.RegisterType<ErrorMessageContext>().As<ErrorMessageContext>();
            containerBuilder.RegisterType<ErrorService>().As<ErrorService>();

            containerBuilder.RegisterType<RobotRepository>().As<IRobotRepository>();
            containerBuilder.RegisterType<RobotContext>().As<RobotContext>();
            containerBuilder.RegisterType<RobotService>().As<RobotService>();

            containerBuilder.RegisterType<RobotListener>().SingleInstance();

            containerBuilder.RegisterType<OrderHistoryRepository>().As<IOrderHistoryRepository>();
            containerBuilder.RegisterType<OrderHistoryContext>().As<OrderHistoryContext>();
            containerBuilder.RegisterType<OrderHistoryService>().As<OrderHistoryService>();

            containerBuilder.RegisterType<DeliveryOrderFactoryZbw>().As<DeliveryOrderFactory>();
            containerBuilder.RegisterType<DeliveryPlanFactoryZbw>().As<DeliveryPlanFactory>();
            containerBuilder.RegisterType<WaypointGeneratorZbw>().As<IWaypointGenerator>();
            containerBuilder.RegisterType<RouteOptimizerZbw>().As<IRouteOptimizer>();
            containerBuilder.RegisterType<DeliveryTimerZbw>().As<IDeliveryTimer>();
            containerBuilder.RegisterType<OrderPrioritizerRobotInvoked>().As<IOrderPrioritizer>();

            Container = containerBuilder.Build();
        }

    }
}
