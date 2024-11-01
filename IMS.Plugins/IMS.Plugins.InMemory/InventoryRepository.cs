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
                new Inventory {InventoryID = 1, InventoryName = "Bike Seat", InventoryQuantity = 10, InventoryPrice = 2},
                new Inventory {InventoryID = 2, InventoryName = "Bike Body", InventoryQuantity = 15, InventoryPrice = 15},
                new Inventory {InventoryID = 3, InventoryName = "Bike Wheels", InventoryQuantity = 20, InventoryPrice = 8},
                new Inventory {InventoryID = 4, InventoryName = "Bike Pedals", InventoryQuantity = 25, InventoryPrice = 1},
            };
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            var maxId = _inventories.Max(x => x.InventoryID);
            inventory.InventoryID = maxId + 1;

            _inventories.Add(inventory);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteInventoryByIdAsync(int inventoryId)
        {
            var inventory = _inventories.FirstOrDefault(x => x.InventoryID == inventoryId);

            if (inventory != null)
            {
                _inventories.Remove(inventory);
                return Task.FromResult(true); 
            }

            return Task.FromResult(false); 
        }


        public Task UpdateInventoryAsync(Inventory inventory)
        {
            //Eğer güncelleme esnasında diğer verilerle aynı isim olacak şekilde güncelleme yapılırsa diye bu kodu ekledim.
            //Normalde database bağlandığında unique key ile bu sorunu çözüyorduk.
            if (_inventories.Any(x => x.InventoryID != inventory.InventoryID &&
            x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;
            //{
            //    throw new InvalidOperationException("An inventory item with this name already exists.");
            //}

            var existingInventory = _inventories.FirstOrDefault(x => x.InventoryID == inventory.InventoryID);
            if (existingInventory != null)
            {
                existingInventory.InventoryName = inventory.InventoryName;
                existingInventory.InventoryQuantity = inventory.InventoryQuantity;
                existingInventory.InventoryPrice = inventory.InventoryPrice;

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
            return await Task.FromResult(_inventories.First(x => x.InventoryID == inventoryId));
        }
    }
}
