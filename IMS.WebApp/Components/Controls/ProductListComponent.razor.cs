using IMS.CoreBusiness;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class ProductListComponent : ComponentBase
    {
        [Inject] IViewProductsByNameUseCase ViewProductsByNameUseCase { get; set; }
        

        private List<Product>? products;

        [Parameter]
        public string? SearchProductFilter { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            products = (await ViewProductsByNameUseCase.ExecuteAsync(SearchProductFilter ?? string.Empty)).ToList();
        }
    }
}
