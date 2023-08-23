using RabbitMQWithNet.Models;

namespace RabbitMQWithNet.Services.ProductService
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProducts();

        public Product GetProductById(int Id);

        public Product AddProduct(Product product);

        public Product UpdateProduct(Product product);

        public bool DeleteProduct(int Id);
    }
}
