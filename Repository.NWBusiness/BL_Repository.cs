using Repository.NWEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.NWBusiness
{
    public class BL_Repository: Repository.EntityFramework.Repository, IDisposable
    {
        public BL_Repository(bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false)
            :base(new NWContext(),autoDetectChangesEnabled,proxyCreationEnabled)
        {

        }
    }
}
