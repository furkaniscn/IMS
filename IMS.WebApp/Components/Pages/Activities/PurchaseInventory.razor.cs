using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;
using static IMS.WebApp.Components.Controls.Common.AutoCompleteComponent;

namespace IMS.WebApp.Components.Pages.Activities
{
    public partial class PurchaseInventory : ComponentBase
    {
        [Inject] IViewInventoriesByNameUseCase ViewInventoriesByNameUseCase { get; set; }


        private List<ItemViewModel>? SearchInventory(string name)
        {
            var list = ViewInventoriesByNameUseCase.ExecuteAsync(name).GetAwaiter().GetResult();
            if (list == null) return null;

            return list.Select(x => new ItemViewModel { ID = x.InventoryID, Name = x.InventoryName })?.ToList();
        }
    }
}
