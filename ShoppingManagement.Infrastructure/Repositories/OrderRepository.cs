using Microsoft.EntityFrameworkCore;
using ShoppingManagement.Application;
using ShoppingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Infrastructure
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public OrderRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override bool AddEntity(Order entity)
        {
            return base.AddEntity(entity);
        }

        public override bool DeleteEntity(int id)
        {
            return base.DeleteEntity(id);
        }

        public override Order Get(int id)
        {
            //return base.Get(id);
            var order = from ord in _dbContext.Orders
                         from cust in _dbContext.Customers
                         from inv in _dbContext.Inventory
                         where ord.ProductId == inv.ProductId
                         && ord.CustomerId == cust.Id
                         && ord.OrderId == id
                         select new Order
                         {
                             OrderId = ord.OrderId,
                             CustomerId = ord.CustomerId,
                             CustomerName = cust.Name,
                             ProductId = ord.ProductId,
                             ProductName = inv.ProductName,
                             Quantity = ord.Quantity
                         };
            return order.FirstOrDefault();
        }

        public override List<Order> GetAll()
        {
            //return base.GetAll();
            var orders = from ord in _dbContext.Orders
                         from cust in _dbContext.Customers
                         from inv in _dbContext.Inventory
                         where ord.ProductId == inv.ProductId
                         && ord.CustomerId == cust.Id
                         select new Order
                         {
                             OrderId = ord.OrderId,
                             CustomerId = ord.CustomerId,
                             CustomerName = cust.Name,
                             ProductId = ord.ProductId,
                             ProductName = inv.ProductName,
                             Quantity = ord.Quantity
                         };
            return orders.ToList();
        }

        public override bool UpdateEntity(Order entity)
        {
            return base.UpdateEntity(entity);
        }
    }
}
