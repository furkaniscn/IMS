using Blazored.Toast.Services;
using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class InventoryListItemComponent : ComponentBase
    {
        [Inject] IDeleteInventoryUseCase DeleteInventoryUseCase { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IToastService ToastService { get; set; }


        [Parameter]
        public Inventory? Inventory { get; set; }

        private async Task DeleteInventory(int inventoryId)
        {
            if (ToastService == null)
            {
                Console.WriteLine("ToastService is null"); 
                return;
            }

            bool isDeleted = await DeleteInventoryUseCase.ExecuteAsync(inventoryId);

            if (isDeleted)
            {
                ToastService.ShowSuccess("Inventory item deleted successfully.");
                NavigationManager.Refresh();
            }
            else
            {
                ToastService.ShowWarning("Inventory item not found.");
            }
        }
    }
}
