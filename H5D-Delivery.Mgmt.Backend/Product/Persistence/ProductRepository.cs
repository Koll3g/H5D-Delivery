using H5D_Delivery.Mgmt.Backend.Product.Domain;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Product.Persistence
{
    public class ProductRepository : RepositoryBase<Domain.Product>, IProductRepository
    {
        public ProductRepository(ProductContext productContext) : base(productContext) { }
    }
}
