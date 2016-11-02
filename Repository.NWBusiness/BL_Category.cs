using Repository.NWEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.NWBusiness
{
    public class BL_Category
    {
        IRepository repo = new BL_Repository();

        public IEnumerable<Category> GetAll()
        {
            return repo.GetAll<Category>(p => true);
        }
    }
}
