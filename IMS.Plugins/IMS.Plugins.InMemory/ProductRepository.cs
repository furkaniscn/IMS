﻿using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product {ProductId = 1, ProductName = "Bike", Quantity = 10, Price =150},
                new Product {ProductId = 2, ProductName = "Car", Quantity = 15, Price = 25000},
            };
        }

        public Task AddProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;

            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteProductByIdAsync(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);

            if (product != null)
            {
                _products.Remove(product);
            }

            return Task.CompletedTask;
        }

        public Task EditProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductId != product.ProductId &&
            x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var existingProduct = _products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Price = product.Price;

            }
            else
            {
                throw new InvalidOperationException("Product item not found.");
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_products);

            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await Task.FromResult(_products.First(x => x.ProductId == productId));
        }
    }
}
