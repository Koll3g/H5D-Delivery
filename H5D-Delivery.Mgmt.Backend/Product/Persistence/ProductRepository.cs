using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Product.Persistence;
using H5D_Delivery.Mgmt.Backend.Product.Domain;
using H5D_Delivery.Mgmt.Backend.Shared;

namespace H5D_Delivery.Mgmt.Backend.Product.Persistence
{
    public class ProductRepository : RepositoryBase<Domain.Product>, IProductRepository
    {
        public ProductRepository(ProductContext productContext) : base(productContext) { }
    }
}
