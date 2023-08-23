using Microsoft.EntityFrameworkCore;
using RabbitMQWithNet.Data;
using RabbitMQWithNet.Models;

namespace RabbitMQWithNet.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dataContext.Products.ToList();
        }

        public Product GetProductById(int Id)
        {
            return _dataContext.Products.FirstOrDefault(p => p.Id == Id);
        }

        public Product AddProduct(Product product)
        {
            var result = _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
            return result.Entity;
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dataContext.Products.Update(product);
            _dataContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int Id)
        {
            var filteredData = _dataContext.Products.FirstOrDefault(p => p.Id == Id);
            var result = _dataContext.Remove(filteredData);
            _dataContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}
