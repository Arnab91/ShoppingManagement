using ShoppingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Application
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        Order GetOrderById(int id);
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}
