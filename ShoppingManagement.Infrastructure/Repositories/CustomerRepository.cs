using ShoppingManagement.Application;
using ShoppingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Infrastructure
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            
        }
        public override bool AddEntity(Customer entity)
        {
            return base.AddEntity(entity);
        }

        public override bool DeleteEntity(int id)
        {
            return base.DeleteEntity(id);
        }

        public override Customer Get(int id)
        {
            return base.Get(id);
        }

        public override List<Customer> GetAll()
        {
            return base.GetAll();
        }

        public override bool UpdateEntity(Customer entity)
        {
            return base.UpdateEntity(entity);
        }
    }
}
