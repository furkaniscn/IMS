using IMS.CoreBusiness.Validations;
using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(150)]
        public string ProductName { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0")]
        public int ProductQuantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater or equal to 0")]
        public double ProductPrice { get; set; }

        [Product_EnsurePriceIsGreaterThanInventoriesCost]
        public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

        public void AddInventory(Inventory inventory)
        {
            if (!this.ProductInventories.Any(
                x => x.Inventory != null &&
                x.Inventory.InventoryName.Equals(inventory.InventoryName)))
            {
                this.ProductInventories.Add(new ProductInventory
                {
                    Inventory = inventory,
                    InventoryID = inventory.InventoryID,
                    InventoryQuantity = 1,
                    ProductID = this.ProductID,
                    Product = this
                });
            }
        }
        public void RemoveInventory(ProductInventory productInventory)
        {
            this.ProductInventories?.Remove(productInventory);
        }
    }
}
