using ShoppingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Application
{
    public interface IInventoryService
    {
        List<Inventory> GetInventories();
        Inventory GetInventoryById(int id);
        void SaveInventory(Inventory inventory);
        void UpdateInventory(Inventory inventory);
        void DeleteInventory(int id);
    }
}
