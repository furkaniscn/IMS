using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories.Concrete
{
    public class DeleteInventoryUseCase : IDeleteInventoryUseCase
    {
        private readonly IInventoryRepository inventoryRepository;
        public DeleteInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(int inventoryId)
        {
            await inventoryRepository.DeleteInventoryByIdAsync(inventoryId);
        }
    }
}
