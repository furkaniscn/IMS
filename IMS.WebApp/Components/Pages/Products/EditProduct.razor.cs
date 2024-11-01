using IMS.CoreBusiness;
using IMS.UseCases.Products.Concrete;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Products
{
    public partial class EditProduct : ComponentBase
    {
        [Inject] IViewProductByIdUseCase ViewProductByIdUseCase { get; set; }
        [Inject] IEditProductUseCase EditProductUseCase { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }


        private Product? product;

        [Parameter]
        public int ProductId { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            this.product = await ViewProductByIdUseCase.ExecuteAsync(this.ProductId);
        }

        private async Task Update()
        {
            if (product != null)
            {
                await EditProductUseCase.ExecuteAsync(this.product);
                NavigationManager.NavigateTo("/products");
            }
        }
    }
}
