using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Inventories
{
    public partial class InventoryList : ComponentBase
    {
        private string? inventoryNameToSearch;

        private void HandleSearch(string searchFilter)
        {
            inventoryNameToSearch = searchFilter;
        }
    }
}
