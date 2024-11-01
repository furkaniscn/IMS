using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Concrete;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Inventories
{
    public partial class AddInventory : ComponentBase
    {
        [Inject] IAddInventoryUseCase AddInventoryUseCase { get; set; }
        //Microsoft tarafından oluşturulan bir sınıftır, bunun sayesinde bir işlem sonrası yönlendirme yapabiliyoruz.
        [Inject] NavigationManager NavigationManager { get; set; }


        [SupplyParameterFromForm]//Butona tıklandığında verileri tutabilmek için kullandık.
        private Inventory inventory { get; set; } = new Inventory();

        private async Task Save()
        {
            await AddInventoryUseCase.ExecuteAsync(inventory);

            NavigationManager.NavigateTo("/inventories");
        }
    }
}
