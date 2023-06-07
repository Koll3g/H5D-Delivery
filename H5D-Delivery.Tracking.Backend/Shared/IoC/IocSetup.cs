using Autofac;
using H5D_Delivery.Tracking.Backend.Tracking.Domain;
using H5D_Delivery.Tracking.Backend.Tracking.Persistence;

namespace H5D_Delivery.Tracking.Backend.Shared.IoC
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
            containerBuilder.RegisterType<ParcelTrackerService>().As<ParcelTrackerService>();
            containerBuilder.RegisterType<OrderHistoryRepository>().As<IOrderHistoryRepository>();
            containerBuilder.RegisterType<OrderHistoryContext>().As<OrderHistoryContext>();

            Container = containerBuilder.Build();
        }

    }
}
