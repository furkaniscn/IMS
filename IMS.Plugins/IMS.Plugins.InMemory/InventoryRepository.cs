using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;
        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory {InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2},
                new Inventory {InventoryId = 2, InventoryName = "Bike Body", Quantity = 15, Price = 15},
                new Inventory {InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 8},
                new Inventory {InventoryId = 4, InventoryName = "Bike Pedals", Quantity = 25, Price = 1},
            };
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            var maxId = _inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;

            _inventories.Add(inventory);
            return Task.CompletedTask;
        }

        public Task DeleteInventoryByIdAsync(int inventoryId)
        {
            var inventory = _inventories.FirstOrDefault(x => x.InventoryId == inventoryId);

            if (inventory != null)
            {
                _inventories.Remove(inventory);
            }

            return Task.CompletedTask;
        }

        public Task EditInventoryAsync(Inventory inventory)
        {
            //Eğer güncelleme esnasında diğer verilerle aynı isim olacak şekilde güncelleme yapılırsa diye bu kodu ekledim.
            //Normalde database bağlandığında unique key ile bu sorunu çözüyorduk.
            if (_inventories.Any(x => x.InventoryId != inventory.InventoryId &&
            x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;
            //{
            //    throw new InvalidOperationException("An inventory item with this name already exists.");
            //}

            var existingInventory = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if (existingInventory != null)
            {
                existingInventory.InventoryName = inventory.InventoryName;
                existingInventory.Quantity = inventory.Quantity;
                existingInventory.Price = inventory.Price;

            }
            else
            {
                throw new InvalidOperationException("Inventory item not found.");
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            return await Task.FromResult(_inventories.First(x => x.InventoryId == inventoryId));
        }
    }
}
