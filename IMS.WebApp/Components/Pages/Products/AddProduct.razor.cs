using IMS.CoreBusiness;
using IMS.UseCases.Products.Concrete;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Pages.Products
{
    public partial class AddProduct : ComponentBase
    {
        [Inject] IAddProductUseCase AddProductUseCase { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }


        //[SupplyParameterFromForm]
        // rendermode'u değiştirdiğimizden buna da ihtiyacımız yok zaten bind-Value ile otomatik olarak state of the component ile eşleşir.
        private Product product { get; set; } = new Product();

        private async Task Save()
        {
            await AddProductUseCase.ExecuteAsync(product);

            NavigationManager.NavigateTo("/products");
        }
    }
}
