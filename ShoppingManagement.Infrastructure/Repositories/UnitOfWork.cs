using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShoppingManagement.Application;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;
        //private Dictionary<Type, object> _repositories;
        public ICustomerRepository CustomerRepository {get; private set;}

        public IInventoryRepository InventoryRepository { get; private set; }

        public IOrderRepository OrderRepository { get; private set; }
        public UnitOfWork(ApplicationDBContext dbContext, ICustomerRepository _customerRepository,
                            IInventoryRepository _inventoryRepository, IOrderRepository _orderRepository)
        {
            _dbContext = dbContext;
            CustomerRepository = _customerRepository;
            InventoryRepository = _inventoryRepository;
            OrderRepository = _orderRepository;
            //CustomerRepository = new CustomerRepository(_dbContext);
            //InventoryRepository = new InventoryRepository(_dbContext);
            //OrderRepository = new OrderRepository(_dbContext);
            //_repositories = new Dictionary<Type, object>();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        //public IGenericRepository<T> GetRepository<T>() where T : class
        //{
        //    if (_repositories.ContainsKey(typeof(T)))
        //    {
        //        return (IGenericRepository<T>)_repositories[typeof(T)];
        //    }

        //    var repository = new GenericRepository<T>(_dbContext);
        //    _repositories.Add(typeof(T), repository);
        //    return repository;
        //}
        public IDbTransaction BeginTransaction()
        {
            var transaction = _dbContext.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }
    }
}
