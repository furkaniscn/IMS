using IMS.CoreBusiness;
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
                new Product {ProductID = 1, ProductName = "Bike", ProductQuantity = 10, ProductPrice =150},
                new Product {ProductID = 2, ProductName = "Car", ProductQuantity = 15, ProductPrice = 25000},
            };
        }

        public Task AddProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            var maxId = _products.Max(x => x.ProductID);
            product.ProductID = maxId + 1;

            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteProductByIdAsync(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductID == productId);

            if (product != null)
            {
                _products.Remove(product);
            }

            return Task.CompletedTask;
        }

        public Task UpdateProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductID != product.ProductID &&
            x.ProductName.ToLower() == product.ProductName.ToLower())) return Task.CompletedTask;

            var existingProduct = _products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductQuantity = product.ProductQuantity;
                existingProduct.ProductPrice = product.ProductPrice;

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

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            var prod = await Task.FromResult(_products.FirstOrDefault(x => x.ProductID == productId));
            var newProd = new Product();

            if (prod != null)
            {
                newProd.ProductID = prod.ProductID;
                newProd.ProductName = prod.ProductName;
                newProd.ProductPrice = prod.ProductPrice;
                newProd.ProductQuantity = prod.ProductQuantity;
                newProd.ProductInventories = new List<ProductInventory>();

                if (prod.ProductInventories != null && prod.ProductInventories.Count > 0)
                {
                    foreach (var prodInv in prod.ProductInventories)
                    {
                        var newProdInv = new ProductInventory
                        {
                            InventoryID = prodInv.InventoryID,
                            ProductID = prodInv.ProductID,
                            Product = prod,
                            Inventory = new Inventory(),
                            InventoryQuantity = prodInv.InventoryQuantity,
                        };
                        if (prodInv.Inventory != null)
                        {
                            newProdInv.Inventory.InventoryID = prodInv.Inventory.InventoryID;
                            newProdInv.Inventory.InventoryName = prodInv.Inventory.InventoryName;
                            newProdInv.Inventory.InventoryPrice = prodInv.Inventory.InventoryPrice;
                            newProdInv.Inventory.InventoryQuantity = prodInv.Inventory.InventoryQuantity;
                        }
                        newProd.ProductInventories.Add(newProdInv);
                    }
                }
            }
            return await Task.FromResult(newProd);
        }
    }
}
