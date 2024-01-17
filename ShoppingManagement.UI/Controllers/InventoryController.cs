using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingManagement.Application;
using ShoppingManagement.Domain;
using ShoppingManagement.UI.DTO;

namespace ShoppingManagement.UI.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;
        public InventoryController(IInventoryService inventoryService, IMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var Inventories = _inventoryService.GetInventories();
            var Inventory = _mapper.Map<List<InventoryDTO>>(Inventories);
            return View(Inventory);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateInventory(InventoryDTO Inventory)
        {
            var invent = _mapper.Map<Inventory>(Inventory);
            _inventoryService.SaveInventory(invent);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var invent = _inventoryService.GetInventoryById(id);
            var Inventory = _mapper.Map<InventoryDTO>(invent);
            return View(Inventory);
        }
        public IActionResult EditInventory(InventoryDTO Inventory)
        {
            var invent = _mapper.Map<Inventory>(Inventory);
            _inventoryService.UpdateInventory(invent);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var Inventory = _inventoryService.GetInventoryById(id);
            var invent = _mapper.Map<InventoryDTO>(Inventory);
            return View(invent);
        }
        public IActionResult Delete(int id)
        {
            _inventoryService.DeleteInventory(id);
            return RedirectToAction("Index");
        }
    }
}
