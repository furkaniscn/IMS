using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class InventoryListComponent : ComponentBase
    {
        [Inject] IViewInventoriesByNameUseCase ViewInventoriesByNameUseCase { get; set; }


        private List<Inventory>? inventories;

        [Parameter]
        public string? SearchInventoryFilter { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            inventories = (await ViewInventoriesByNameUseCase.ExecuteAsync(SearchInventoryFilter ?? string.Empty)).ToList();
        }
    }
}
