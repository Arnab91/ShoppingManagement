using ShoppingManagement.Application;
using ShoppingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingManagement.Infrastructure
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            
        }
        public override bool AddEntity(Inventory entity)
        {
            return base.AddEntity(entity);
        }

        public override bool DeleteEntity(int id)
        {
            return base.DeleteEntity(id);
        }

        public override Inventory Get(int id)
        {
            return base.Get(id);
        }

        public override List<Inventory> GetAll()
        {
            return base.GetAll();
        }

        public override bool UpdateEntity(Inventory entity)
        {
            return base.UpdateEntity(entity);
        }
    }
}
