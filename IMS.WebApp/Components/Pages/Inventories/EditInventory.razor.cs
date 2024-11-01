using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Concrete;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Inventories
{
    public partial class EditInventory : ComponentBase
    {
        [Inject] IEditInventoryUseCase EditInventoryUseCase { get; set; }
        [Inject] IViewInventoryByIdUseCase ViewInventoryByIdUseCase { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }


        [Parameter]
        public int InvId { get; set; }

        [SupplyParameterFromForm]
        private Inventory? inventory { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            this.inventory ??= await ViewInventoryByIdUseCase.ExecuteAsync(this.InvId);
        }

        private async Task Update()
        {
            if (inventory != null)
            {
                await EditInventoryUseCase.ExecuteAsync(inventory);
                NavigationManager.NavigateTo("/inventories");
            }
        }
    }
}
