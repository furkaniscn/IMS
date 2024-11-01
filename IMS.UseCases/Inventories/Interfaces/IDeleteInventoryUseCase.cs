namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IDeleteInventoryUseCase
    {
        Task<bool> ExecuteAsync(int inventoryId);
    }
}