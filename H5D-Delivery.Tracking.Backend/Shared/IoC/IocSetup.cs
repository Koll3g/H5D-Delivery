using Autofac;
using H5D_Delivery.Tracking.Backend.Tracking.Domain;

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

            Container = containerBuilder.Build();
        }

    }
}
