using Repository.NWEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.NWBusiness
{
    public class BL_Product
    {
        IRepository repo = new BL_Repository();

        public IEnumerable<Product> GetAll()
        {
            return repo.GetAll<Product>(p => true);
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await repo.GetAllAsync<Product>(p => true);
        }

        public Product Create(Product model)
        {
            return repo.Create(model);
        }
        public async Task<Product> CreateAsync(Product model)
        {
            return await repo.CreateAsync(model);
        }

        public async Task<IEnumerable<Product>> GetAllWithRelationAsync()
        {
            return await repo.GetAllAsync<Product>(p => true, "Category");
        }
    }
}
