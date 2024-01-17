using ShoppingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Application
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGenericRepository<Order> _orderRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IInventoryRepository _inventoryRepository;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_orderRepository = _unitOfWork.GetRepository<Order>();
            _orderRepository = _unitOfWork.OrderRepository;
            _inventoryRepository = _unitOfWork.InventoryRepository;
        }
        public void DeleteOrder(int id)
        {
            using(var transaction = _unitOfWork.BeginTransaction()) 
            {
                try
                {
                    var order = _orderRepository.Get(id);
                    _orderRepository.DeleteEntity(id);
                    var product = _inventoryRepository.Get(order.ProductId);
                    product.Quantity += order.Quantity;
                    _inventoryRepository.UpdateEntity(product);
                    transaction.Commit();
                }
                catch(Exception) 
                {
                    transaction.Rollback();
                }
            }
            
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.Get(id);
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetAll();
        }

        public void SaveOrder(Order order)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    _orderRepository.AddEntity(order);
                    var product = _inventoryRepository.Get(order.ProductId);
                    product.Quantity -= order.Quantity;
                    _inventoryRepository.UpdateEntity(product);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void UpdateOrder(Order order)
        {
            using(var transaction = _unitOfWork.BeginTransaction()) 
            {
                try
                {
                    var previousorder = _orderRepository.Get(order.OrderId);
                    _orderRepository.UpdateEntity(order);
                    var product = _inventoryRepository.Get(order.ProductId);
                    if(previousorder.Quantity > order.Quantity)
                    {
                        int removed_quantity = previousorder.Quantity - order.Quantity;
                        product.Quantity += removed_quantity;
                    }
                    else if(previousorder.Quantity < order.Quantity)
                    {
                        int added_quantity = order.Quantity - previousorder.Quantity;
                        product.Quantity -= added_quantity;
                    }
                    _inventoryRepository.UpdateEntity(product);
                    transaction.Commit();
                }
                catch(Exception) 
                {
                    transaction.Rollback();
                }
            }
            
        }
    }
}
