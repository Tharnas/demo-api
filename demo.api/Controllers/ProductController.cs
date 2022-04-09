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

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> Get(int productId)
        {
            var product = await _productRepository.GetProduct(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost()]
        public async Task<Product> Create(Product product)
        {
            return await _productRepository.CreateProduct(product);
        }

        [HttpPut("{productId}")]
        public async Task<ActionResult<Product>> Update(int productId, Product product)
        {
            var updatedProduct = await _productRepository.UpdateProduct(productId, product);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }
    }
}