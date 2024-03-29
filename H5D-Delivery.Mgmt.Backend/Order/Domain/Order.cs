﻿using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Order.Domain
{
    public class Order : DbItem
    {
        public Product.Domain.Product Product { get; set; }
        public Guid ProductId { get; set; }

        public Customer.Domain.Customer Customer { get; set; }
        public Guid CustomerId { get; set; }

        public uint Amount { get; set; }

        public DateTime EarliestDeliveryTime { get; set; }
        public DateTime LatestDeliveryTime { get; set; }
        public string AuthorizationKey { get; set; }

        public Priority Priority { get; set; }
        public DeliveryType DeliveryType { get; set; }

        public OrderStatus Status { get; set; }

        public Guid? DeliveryOrderId { get; set; }
        //public DeliveryOrder? DeliveryOrder { get; set; }

        public Order(Guid id, Product.Domain.Product product, Customer.Domain.Customer customer, uint amount, DateTime earliestDeliveryTime, DateTime latestDeliveryTime, Priority priority, DeliveryType deliveryType, OrderStatus status = OrderStatus.Active, string authorizationKey = "") : base(id)
        {
            Product = product;
            ProductId = product.Id;
            Amount = amount;
            Customer = customer;
            CustomerId = customer.Id;
            EarliestDeliveryTime = earliestDeliveryTime;
            LatestDeliveryTime = latestDeliveryTime;
            Priority = priority;
            DeliveryType = deliveryType;
            Status = status;
            AuthorizationKey = authorizationKey;
        }

        #pragma warning disable CS8618
        public Order(Guid id, Guid productId, Guid customerId, uint amount, DateTime earliestDeliveryTime, DateTime latestDeliveryTime, Priority priority, DeliveryType deliveryType, OrderStatus status = OrderStatus.Active, string authorizationKey = "") : base(id)
        #pragma warning restore CS8618
        {
            ProductId = productId;
            Amount = amount;
            CustomerId = customerId;
            EarliestDeliveryTime = earliestDeliveryTime;
            LatestDeliveryTime = latestDeliveryTime;
            Priority = priority;
            DeliveryType = deliveryType;
            Status = status;
            AuthorizationKey = authorizationKey;
        }

        public override string ToString()
        {
            return $"{Amount}x {Product.Name} for {Customer.Name} at {Customer.Address}";
        }
    }
}
