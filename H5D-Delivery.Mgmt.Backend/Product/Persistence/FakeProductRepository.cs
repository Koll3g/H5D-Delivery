using H5D_Delivery.Mgmt.Backend.Product.Domain;

namespace H5D_Delivery.Mgmt.Backend.Product.Persistence
{
    public class FakeProductRepository : IProductRepository
    {
        public List<Domain.Product> ProductList { get; }

        public FakeProductRepository()
        {
            ProductList = FillProductList();
        }

        private static List<Domain.Product> FillProductList()
        {
            return new List<Domain.Product>
            {
                new Domain.Product(new Guid(), "Messer"),
                new Domain.Product(new Guid(), "Gabel"),
                new Domain.Product(new Guid(), "Löffel"),
            };

        }

        public IEnumerable<Domain.Product> GetAll()
        {
            return ProductList;
        }

        public Domain.Product? Get(Guid id)
        {
            var product = ProductList.Find((x) => x.Id.Equals(id));

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} not found");
            }
            return product;
        }

        public void Update(Domain.Product product)
        {
            var index = ProductList.IndexOf(product);

            if (index == -1)
            {
                ProductList[index] = product;
            }
            else
            {
                throw new KeyNotFoundException($"Product with id {product.Id} not found");
            }
        }

        public void Delete(Guid id)
        {
            var product = ProductList.Find((x) => x.Id.Equals(id));
            if (product != null)
            { 
                ProductList.Remove(product);
            }
            else
            {
                throw new KeyNotFoundException($"Product with id {id} not found");
            }
        }

        public void Create(Domain.Product product)
        {
            ProductList.Add(product);
        }
    }
}
