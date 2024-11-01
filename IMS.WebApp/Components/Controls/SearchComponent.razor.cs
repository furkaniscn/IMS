using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class SearchComponent : ComponentBase
    {
        [SupplyParameterFromForm]
        private string searchFilter { get; set; } = string.Empty;

        [Parameter]
        public EventCallback<string> OnSearch { get; set; }

        private void Search()
        {
            OnSearch.InvokeAsync(searchFilter);
        }
    }
}
