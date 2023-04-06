using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared;

namespace H5D_Delivery.Mgmt.Backend.Stock.Domain
{
    public class StockItem : DbItem
    {
        public Product.Domain.Product Product { get; set; }
        public Guid ProductId { get; set; }
        public uint Amount { get; set; }
        public uint StorageLocation { get; set; }

        public StockItem(Guid id, Product.Domain.Product product, uint amount, uint storageLocation) : base(id)
        {
            Product = product;
            ProductId = product.Id;
            Amount = amount;
            StorageLocation = storageLocation;
        }
    }
}
