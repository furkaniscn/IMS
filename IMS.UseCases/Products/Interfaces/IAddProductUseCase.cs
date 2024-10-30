using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Concrete
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}