using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingManagement.Application;
using ShoppingManagement.Domain;
using ShoppingManagement.UI.DTO;

namespace ShoppingManagement.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, ICustomerService customerService, IInventoryService inventoryService, IMapper mapper)
        {
            _orderService = orderService;
            _customerService = customerService;
            _inventoryService = inventoryService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var Inventories = _orderService.GetOrders();
            var Order = _mapper.Map<List<OrderDTO>>(Inventories);
            return View(Order);
        }
        public IActionResult Create()
        {
            var customers = _customerService.GetCustomers();
            var products = _inventoryService.GetInventories();
            OrderDTO orderDTO = new OrderDTO();
            orderDTO.Customers = new List<SelectListItem>();
            orderDTO.Products = new List<SelectListItem>();
            foreach (var item in customers)
                orderDTO.Customers.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            foreach (var item in products)
                orderDTO.Products.Add(new SelectListItem() { Text = item.ProductName, Value = item.ProductId.ToString() });
            return View(orderDTO);
        }
        public IActionResult CreateOrder(OrderDTO Order)
        {
            var invent = _mapper.Map<Order>(Order);
            _orderService.SaveOrder(invent);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var invent = _orderService.GetOrderById(id);
            var Order = _mapper.Map<OrderDTO>(invent);

            var customers = _customerService.GetCustomers();
            var products = _inventoryService.GetInventories();
            Order.Customers = new List<SelectListItem>();
            Order.Products = new List<SelectListItem>();
            foreach (var item in customers)
                Order.Customers.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            foreach (var item in products)
                Order.Products.Add(new SelectListItem() { Text = item.ProductName, Value = item.ProductId.ToString() });


            return View(Order);
        }
        public IActionResult EditOrder(OrderDTO Order)
        {
            var invent = _mapper.Map<Order>(Order);
            _orderService.UpdateOrder(invent);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var Order = _orderService.GetOrderById(id);
            var invent = _mapper.Map<OrderDTO>(Order);
            return View(invent);
        }
        public IActionResult Delete(int id)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}
