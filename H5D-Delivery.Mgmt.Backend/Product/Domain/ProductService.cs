using H5D_Delivery.Mgmt.Backend.Product.Exceptions;

namespace H5D_Delivery.Mgmt.Backend.Product.Domain
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product>? GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product? Get(Guid id)
        {
            return _productRepository.Get(id);
        }

        public void Update(Product product)
        {
            if (!IsProductValid(product))
            {
                return;
            }
            _productRepository.Update(product);
        }

        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
        }

        public void Create(Product product)
        {
            if (!IsProductValid(product))
            {
                return;
            }
            _productRepository.Create(product);
        }

        private bool IsProductValid(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
            {
                string errorMessage = "Product Name cannot be empty.";
                throw new ProductNameInvalidException(errorMessage);
            }

            return true;
        }
    }
}
