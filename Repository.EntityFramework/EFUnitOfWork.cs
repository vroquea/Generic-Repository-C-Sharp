using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Repository.EntityFramework
{
    public class EFUnitOfWork : EFRepository, IRepository, IUnitOfWork, IDisposable
    {
        public EFUnitOfWork(DbContext context, bool autoDetectChangesEnabled = false,
                                          bool proxyCreationEnabled = false) : base(context,autoDetectChangesEnabled, proxyCreationEnabled)
        {
        }

        protected override int TrySaveChanges()
        {
            return 0;
        }
        protected override async Task<int> TrySaveChangesAsync()
        {
            return await Task.Run(()=> 0);
        }
        int IUnitOfWork.Save()
        {
            int Result = 0;

            try
            {
                Result = Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        async Task<int> IUnitOfWork.SaveAsync()
        {
            int Result = 0;

            try
            {
                Result = await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
    }
}
