using IMS.CoreBusiness;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class ProductInventoriesComponent : ComponentBase
    {
        [Parameter]
        public Product? Product { get; set; }

        private void RemoveInventory(ProductInventory productInventory)
        {
            this.Product?.RemoveInventory(productInventory);
        }

        private void HandleInventorySelected(Inventory inventory)
        {
            this.Product?.AddInventory(inventory);
        }
    }
}
