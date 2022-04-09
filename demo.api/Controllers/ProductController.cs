using demo.api.Models;
using demo.api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace demo.api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly ProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet()]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetProducts();
        }

        [HttpPost()]
        public async Task<Product> Create(Product product)
        {
            return await _productRepository.CreateProduct(product);
        }
    }
}