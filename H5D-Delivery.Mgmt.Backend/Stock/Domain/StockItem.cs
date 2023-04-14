using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Stock.Domain
{
    public class StockItem : DbItem
    {
        public Product.Domain.Product Product { get; set; }
        public Guid ProductId { get; set; }
        public uint Amount { get; set; }
        public StorageLocation StorageLocation { get; set; }

        public StockItem(Guid id, Product.Domain.Product product, uint amount, StorageLocation storageLocation) : base(id)
        {
            Product = product;
            Amount = amount;
            StorageLocation = storageLocation;
            ProductId = product.Id;
        }

        #pragma warning disable CS8618
        public StockItem(Guid id, Guid productId, uint amount, StorageLocation storageLocation) : base(id)
        #pragma warning restore CS8618
        {
            ProductId = productId;
            Amount = amount;
            StorageLocation = storageLocation;
        }
    }
}
