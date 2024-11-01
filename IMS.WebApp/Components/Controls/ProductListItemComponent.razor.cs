using IMS.CoreBusiness;
using IMS.UseCases.Products.Concrete;
using IMS.UseCases.Products.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls
{
    public partial class ProductListItemComponent : ComponentBase
    {
        [Inject] IDeleteProductUseCase DeleteProductUseCase { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }


        [Parameter]
        public Product? Product { get; set; }

        //Parametre girdiğimiz için yukarıda arrow function kullanıyoruz.(() => kısmı)
        private async Task HandleDelete(int productId)
        {
            await DeleteProductUseCase.ExecuteAsync(productId);
            this.Product = null;//Kullanıcı arayüzünü tekrardan render etmek için bileşen durumunu belirlemek gerekir.
        }
    }
}
