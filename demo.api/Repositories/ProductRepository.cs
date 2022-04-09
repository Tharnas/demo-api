using demo.api.Models;

namespace demo.api.Repositories
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> CreateProduct(Product newProduct)
        {
            newProduct.Id = _products.Select(x => x.Id).DefaultIfEmpty(0).Max() + 1;

            _products.Add(newProduct);

            return await Task.FromResult(newProduct);
        }
    }
}
