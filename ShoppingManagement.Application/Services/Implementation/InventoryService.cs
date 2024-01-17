using ShoppingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Application
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGenericRepository<Inventory> _inventoryRepository;
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_inventoryRepository = _unitOfWork.GetRepository<Inventory>();
            _inventoryRepository = _unitOfWork.InventoryRepository;
        }
        public void DeleteInventory(int id)
        {
            _inventoryRepository.DeleteEntity(id);
        }

        public List<Inventory> GetInventories()
        {
            return _inventoryRepository.GetAll();
        }

        public Inventory GetInventoryById(int id)
        {
            return _inventoryRepository.Get(id);
        }

        public void SaveInventory(Inventory inventory)
        {
            _inventoryRepository.AddEntity(inventory);
        }

        public void UpdateInventory(Inventory inventory)
        {
            _inventoryRepository.UpdateEntity(inventory);
        }
    }
}
