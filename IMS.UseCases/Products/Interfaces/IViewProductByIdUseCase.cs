using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Concrete
{
    public interface IViewProductByIdUseCase
    {
        Task<Product> ExecuteAsync(int productId);
    }
}