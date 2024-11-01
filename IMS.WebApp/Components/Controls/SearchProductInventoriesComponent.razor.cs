using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls;

public partial class SearchProductInventoriesComponent : ComponentBase
{
    [Inject] IViewInventoriesByNameUseCase? ViewInventoriesByNameUseCase { get; set; }


    [Parameter] public EventCallback<Inventory> OnInventorySelected { get; set; }

    //State Variable-
    //private string searchFilter = string.Empty;
    private string _searchFilter;
    private string searchFilter
    {
        get => _searchFilter;
        set
        {
            _searchFilter = value;
            HandleSearch();
        }
    }
    private List<Inventory> inventories = new List<Inventory>();

    private async Task HandleSearch()
    {
        await Task.Delay(1000);//Gerçek db simülasyonu için 1 dakika delay verdik.
        inventories = (await ViewInventoriesByNameUseCase.ExecuteAsync(this.searchFilter)).ToList();

        //State'in(inventories) değiştiğini söylüyoruz.
        //Bunu yapmazsak html daha önce render olduğu için değişikliği algılamaz.(async durumlarda geçerli)
        StateHasChanged();
    }

    private async Task HandleSelectInventory(Inventory inventory)
    {
        await OnInventorySelected.InvokeAsync(inventory);
        inventories.Clear();
    }
}
