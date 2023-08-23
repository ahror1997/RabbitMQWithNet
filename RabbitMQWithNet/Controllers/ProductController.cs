using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQWithNet.Models;
using RabbitMQWithNet.Services.ProductService;
using RabbitMQWithNet.Services.RabbitMQService;

namespace RabbitMQWithNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IProductService _productService;

        public ProductController(IRabbitMQService rabbitMQService, IProductService productService)
        {
            _rabbitMQService = rabbitMQService;
            _productService = productService;
        }

        [HttpGet("productlist")]
        public IEnumerable<Product> ProductList()
        {
            var productList = _productService.GetProducts();
            return productList;
        }

        [HttpGet("getproductbyid")]
        public Product GetProductById(int Id)
        {
            return _productService.GetProductById(Id);
        }

        [HttpPost("addproduct")]
        public Product AddProduct(Product product)
        {
            var productData = _productService.AddProduct(product);
            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabbitMQService.SendProductMessage(productData);
            return productData;
        }

        [HttpPut("updateproduct")]
        public Product UpdateProduct(Product product)
        {
            return _productService.UpdateProduct(product);
        }

        [HttpDelete("deleteproduct")]
        public bool DeleteProduct(int Id)
        {
            return _productService.DeleteProduct(Id);
        }
    }
}
