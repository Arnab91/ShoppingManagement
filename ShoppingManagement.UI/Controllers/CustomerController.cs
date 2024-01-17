using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingManagement.Application;
using ShoppingManagement.Domain;
using ShoppingManagement.UI.DTO;

namespace ShoppingManagement.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper) 
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var customers = _customerService.GetCustomers();
            var customer = _mapper.Map<List<CustomerDTO>>(customers);
            return View(customer);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateCustomer(CustomerDTO customer)
        {
            var cust = _mapper.Map<Customer>(customer);
            _customerService.SaveCustomer(cust);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var cust = _customerService.GetCustomerById(id);
            var customer = _mapper.Map<CustomerDTO>(cust);
            return View(customer);
        }
        public IActionResult EditCustomer(CustomerDTO customer)
        {
            var cust = _mapper.Map<Customer>(customer);
            _customerService.UpdateCustomer(cust);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            var cust = _mapper.Map<CustomerDTO>(customer);
            return View(cust);
        }
        public IActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
