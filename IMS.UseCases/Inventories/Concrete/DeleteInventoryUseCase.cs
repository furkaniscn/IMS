using Blazored.Toast.Services;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories.Concrete
{
    public class DeleteInventoryUseCase : IDeleteInventoryUseCase
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly IToastService ToastService;
        public DeleteInventoryUseCase(IInventoryRepository inventoryRepository, IToastService toastService)
        {
            this.inventoryRepository = inventoryRepository;
            ToastService = toastService;
        }

        public async Task<bool> ExecuteAsync(int inventoryId)
        {
            return await inventoryRepository.DeleteInventoryByIdAsync(inventoryId);
        }

    }
}
