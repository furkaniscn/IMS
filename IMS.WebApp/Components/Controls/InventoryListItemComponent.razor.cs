using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Concrete;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class InventoryListItemComponent : ComponentBase
    {
        [Inject] IDeleteInventoryUseCase DeleteInventoryUseCase { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }


        [Parameter]
        public Inventory? Inventory { get; set; }

        private async Task DeleteInventory(int inventoryId)
        {
            await DeleteInventoryUseCase.ExecuteAsync(inventoryId);
            NavigationManager.Refresh();
        }
    }
}
