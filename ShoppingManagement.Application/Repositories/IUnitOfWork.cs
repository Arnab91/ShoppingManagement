using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Application
{
    public interface IUnitOfWork : IDisposable
    {
        //IGenericRepository<T> GetRepository<T>() where T : class;
        ICustomerRepository CustomerRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IOrderRepository OrderRepository { get; }
        IDbTransaction BeginTransaction();
    }
}
