using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Concrete
{
    public interface IEditProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}