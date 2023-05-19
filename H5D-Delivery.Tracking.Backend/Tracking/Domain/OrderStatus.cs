namespace H5D_Delivery.Tracking.Backend.Tracking.Domain
{
    public enum OrderStatus
    {
        Active = 0,
        PlannedForDelivery = 1,
        BeingDelivered = 2,
        Delivered = 3,
        FailedToDeliver = 4,
        Canceled = 5,
    }
}
