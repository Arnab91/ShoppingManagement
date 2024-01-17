using ShoppingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGenericRepository<Customer> _customerRepository;
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_customerRepository = _unitOfWork.GetRepository<Customer>();
            _customerRepository = _unitOfWork.CustomerRepository;
        }
        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteEntity(id);
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.Get(id);
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetAll();
        }

        public void SaveCustomer(Customer customer)
        {
            _customerRepository.AddEntity(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateEntity(customer);
        }
    }
}
