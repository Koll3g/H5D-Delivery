using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Tracking.Backend.Tracking.Exceptions;

namespace H5D_Delivery.Tracking.Backend.Tracking.Domain
{
    public class ParcelTrackerService
    {
        public bool IsAuthorized(string name, string orderId)
        {
            return FakeIsAuthorized(name, orderId);
        }

        public IEnumerable<OrderHistory> GetOrderHistory(string name, string orderId)
        {
            return FakeGetOrderHistory(name, orderId);
        }

        private bool FakeIsAuthorized(string name, string orderId)
        {
            return name == "Hans" && orderId == "7c5c7e6e-2635-469c-abeb-f6c137ce6579";
        }


        private IEnumerable<OrderHistory> FakeGetOrderHistory(string name, string orderId)
        {
            if (!IsAuthorized(name, orderId))
            {
                throw new NotAuthorizedException("Name and OrderId do not match or OrderId was not found in Database");
            }

            var history = new List<OrderHistory>();
            var historyItem1 = new OrderHistory(Guid.NewGuid())
            {
                OrderId = new Guid("7c5c7e6e-2635-469c-abeb-f6c137ce6579"),
                DateTime = new DateTime(2023, 05, 19, 12, 0, 0),
                Status = OrderStatus.Active // = Bestellung wurde erfasst

            };
            var historyItem2 = new OrderHistory(Guid.NewGuid())
            {
                OrderId = new Guid("7c5c7e6e-2635-469c-abeb-f6c137ce6579"),
                DateTime = new DateTime(2023, 05, 19, 13, 0, 0),
                Status = OrderStatus.PlannedForDelivery  // = Die Bestellung wurde einem Roboter zugeteilt und wird bald ausgeliefert
            };
            var historyItem3 = new OrderHistory(Guid.NewGuid())
            {
                OrderId = new Guid("7c5c7e6e-2635-469c-abeb-f6c137ce6579"),
                DateTime = new DateTime(2023, 05, 19, 14, 0, 0),
                Status = OrderStatus.BeingDelivered // = ist auf dem Roboter und unterwegs
            };
            var historyItem4 = new OrderHistory(Guid.NewGuid())
            {
                OrderId = new Guid("7c5c7e6e-2635-469c-abeb-f6c137ce6579"),
                DateTime = new DateTime(2023, 05, 19, 15, 0, 0),
                Status = OrderStatus.Delivered  // = Erfolgreich geliefert
            };
            var historyItem5 = new OrderHistory(Guid.NewGuid())
            {
                OrderId = new Guid("7c5c7e6e-2635-469c-abeb-f6c137ce6579"),
                DateTime = new DateTime(2023, 05, 19, 16, 0, 0),
                Status = OrderStatus.FailedToDeliver  // = Konnte nicht zugestellt werden
            };
            var historyItem6 = new OrderHistory(Guid.NewGuid())
            {
                OrderId = new Guid("7c5c7e6e-2635-469c-abeb-f6c137ce6579"),
                DateTime = new DateTime(2023, 05, 19, 17, 0, 0),
                Status = OrderStatus.Canceled // = Bestellung wurde storniert
            };
            history.Add(historyItem1);
            history.Add(historyItem2);
            history.Add(historyItem3);
            history.Add(historyItem4);
            history.Add(historyItem5);
            history.Add(historyItem6);

            return history;
        }
    }
}
