using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Products
{
    public partial class ProductList : ComponentBase
    {
        private string? productNameToSearch;

        private void HandleSearch(string searchFilter)
        {
            productNameToSearch = searchFilter;
        }
    }
}
