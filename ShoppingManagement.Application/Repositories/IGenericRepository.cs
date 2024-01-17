using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Application
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        bool AddEntity(T entity);
        bool UpdateEntity(T entity);
        bool DeleteEntity(int id);
    }
}
