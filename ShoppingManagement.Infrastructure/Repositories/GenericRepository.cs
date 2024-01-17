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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        private DbSet<T> entities;
        public GenericRepository(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<T>();
        }
        public virtual bool AddEntity(T entity)
        {
            entities.Add(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public virtual bool DeleteEntity(int id)
        {
            var entity = entities.Find(id);
            entities.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public virtual T Get(int id)
        {
            return entities.Find(id);
        }

        public virtual List<T> GetAll()
        {
            return entities.ToList();
        }

        public virtual bool UpdateEntity(T entity)
        {
            entities.Update(entity);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
