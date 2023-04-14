using H5D_Delivery.Mgmt.Backend.Order.Domain;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Order.Persistence
{
    public class OrderRepository : RepositoryBase<Domain.Order>, IOrderRepository
    {
        public OrderRepository(OrderContext orderContext) : base(orderContext) { }
    }
}
