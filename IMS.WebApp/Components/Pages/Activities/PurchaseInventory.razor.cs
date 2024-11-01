using IMS.CoreBusiness;
using IMS.UseCases.Activities.Interfaces;
using IMS.UseCases.Inventories.Interfaces;
using IMS.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using static IMS.WebApp.Components.Controls.Common.AutoCompleteComponent;

namespace IMS.WebApp.Components.Pages.Activities
{
    public partial class PurchaseInventory : ComponentBase
    {
        [Inject] IViewInventoriesByNameUseCase ViewInventoriesByNameUseCase { get; set; }
        [Inject] IViewInventoryByIdUseCase ViewInventoryByIdUseCase { get; set; }
        [Inject] IPurchaseInventoryUseCase PurchaseInventoryUseCase { get; set; }


        private PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
        private Inventory? selectedInventory = null;

        private List<ItemViewModel>? SearchInventory(string name)
        {
            var list = ViewInventoriesByNameUseCase.ExecuteAsync(name).GetAwaiter().GetResult();
            if (list == null) return null;

            return list.Select(x => new ItemViewModel { ID = x.InventoryID, Name = x.InventoryName })?.ToList();
        }
        private async Task HandleItemSelected(ItemViewModel item)
        {
            selectedInventory = await ViewInventoryByIdUseCase.ExecuteAsync(item.ID);

            this.purchaseViewModel.InventoryID = item.ID;
            this.purchaseViewModel.InventoryPrice = selectedInventory.InventoryPrice;
        }
        private async Task Purchase()
        {
            await PurchaseInventoryUseCase.ExecuteAsync(
                  this.purchaseViewModel.PONumber,
                  selectedInventory,
                  this.purchaseViewModel.QuantityToPurchase,
                  "Furkan"
                  );

            this.purchaseViewModel = new PurchaseViewModel();
            this.selectedInventory = null;
        }

    }
}
