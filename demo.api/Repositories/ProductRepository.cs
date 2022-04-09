using demo.api.Models;

namespace demo.api.Repositories
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Apple", Description = "An apple is an edible fruit produced by an apple tree.", Price = 2.99 },
            new Product { Id = 2, Name = "Orange", Description = "An orange is a fruit of various citrus species in the family Rutaceae.", Price = 3.15 },
        };

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

        public async Task<Product?> UpdateProduct(int productId, Product product)
        {
            var productToUpdate = _products.FirstOrDefault(x => x.Id == productId);

            if (productToUpdate == null)
            {
                return await Task.FromResult<Product?>(null);
            }

            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;

            return await Task.FromResult(productToUpdate);
        }

        public async Task<Product?> GetProduct(int productId)
        {
            return await Task.FromResult(_products.FirstOrDefault(x => x.Id == productId));
        }
    }
}
