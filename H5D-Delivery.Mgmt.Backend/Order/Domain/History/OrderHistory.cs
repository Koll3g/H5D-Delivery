using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Order.Domain.History
{
    public class OrderHistory : DbItem
    {
        public DateTime DateTime { get; set; }
        public OrderStatus Status { get; set; }
        public Guid OrderId { get; set; }
        public string? CustomerName { get; set; }

        public OrderHistory(Guid id) : base(id)
        {
        }
    }
}
