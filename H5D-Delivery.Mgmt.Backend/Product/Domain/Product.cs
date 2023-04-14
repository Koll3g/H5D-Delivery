using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Product.Domain
{
    public class Product : DbItem
    {
        public string Name { get; set; }

        public Product(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
