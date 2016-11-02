using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Repository
{ 
    public class EFRepository : IRepository, IDisposable
    {
        protected DbContext Context;
        public EFRepository(DbContext context, bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false)
        {
            Context = context;
            Context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            Context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }

        public TEntity Create<TEntity>(TEntity newEntity) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                Result = Context.Set<TEntity>().Add(newEntity);
                TrySaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        public async Task<TEntity> CreateAsync<TEntity>(TEntity newEntity) where TEntity : class
        {

            TEntity Result = null;

            try
            {
                Result = Context.Set<TEntity>().Add(newEntity);

                await  TrySaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public bool Delete<TEntity>(TEntity deletedEntity) where TEntity : class
        {
            bool Result = false;

            try
            {
                Context.Set<TEntity>().Attach(deletedEntity);
                Context.Set<TEntity>().Remove(deletedEntity);
                Result = TrySaveChanges() > 0;
            }
            catch
            {
                return false;
            }

            return Result;
        }
        public async Task<bool> DeleteAsync<TEntity>(TEntity deletedEntity) where TEntity : class
        {
            bool Result = false;

            try
            {
                Context.Set<TEntity>().Attach(deletedEntity);
                Context.Set<TEntity>().Remove(deletedEntity);
                Result = await TrySaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }

            return Result;
        }

        public bool DeletePartial<TEntity>(TEntity deletedEntity, Expression<Func<TEntity,object>> property) where TEntity : class
        {
            bool Result = false;

            try
            {
                Context.Set<TEntity>().Attach(deletedEntity);

                Context.Entry<TEntity>(deletedEntity).Property(property).IsModified = true;

                Context.Entry<TEntity>(deletedEntity).State = EntityState.Modified;

                Result = TrySaveChanges() > 0;
            }
            catch
            {
                return false;
            }

            return Result;
        }
        public async Task<bool> DeletePartialAsync<TEntity>(TEntity deletedEntity, Expression<Func<TEntity, object>> property) where TEntity : class
        {
            bool Result = false;

            try
            {
                Context.Set<TEntity>().Attach(deletedEntity);

                Context.Entry<TEntity>(deletedEntity).Property(property).IsModified = true;

                Context.Entry<TEntity>(deletedEntity).State = EntityState.Modified;

                Result = await TrySaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }

            return Result;
        }

        public bool Update<TEntity>(TEntity modifiedEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                Context.Set<TEntity>().Attach(modifiedEntity);
                Context.Entry<TEntity>(modifiedEntity).State = EntityState.Modified;

                Result = TrySaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        public async Task<bool> UpdateAsync<TEntity>(TEntity modifiedEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                Context.Set<TEntity>().Attach(modifiedEntity);
                Context.Entry<TEntity>(modifiedEntity).State = EntityState.Modified;
                Result = await TrySaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public bool Update<TEntity>(TEntity modifiedEntity, List<Expression<Func<TEntity, bool>>> properties, bool isModified) where TEntity : class
        {
            bool Result = false;
            try
            {
                Context.Set<TEntity>().Attach(modifiedEntity);

                foreach (var item in properties)
                {
                    Context.Entry<TEntity>(modifiedEntity).Property(item).IsModified = isModified;
                }
                
                Context.Entry<TEntity>(modifiedEntity).State = EntityState.Modified;

                Result = TrySaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        public async Task<bool> UpdateAsync<TEntity>(TEntity modifiedEntity, List<Expression<Func<TEntity, bool>>> properties, bool isModified) where TEntity : class
        {
            bool Result = false;
            try
            {
                Context.Set<TEntity>().Attach(modifiedEntity);

                foreach (var item in properties)
                {
                    Context.Entry<TEntity>(modifiedEntity).Property(item).IsModified = isModified;
                }

                Context.Entry<TEntity>(modifiedEntity).State = EntityState.Modified;

                Result = await TrySaveChangesAsync()  > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                Result = Context.Set<TEntity>().FirstOrDefault(criterion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;

        }
        public async Task<TEntity> FindEntityAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                Result = await Context.Set<TEntity>().FirstOrDefaultAsync(criterion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;

        }

        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion, List<Expression<Func<TEntity, TEntity>>> relations) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                var query = Context.Set<TEntity>().AsQueryable();

                foreach (var item in relations)
                {
                    query = query.Include(item);
                }

                Result = Context.Set<TEntity>().FirstOrDefault(criterion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        public async Task<TEntity> FindEntityAsync<TEntity>(Expression<Func<TEntity, bool>> criterion, List<Expression<Func<TEntity, TEntity>>> relations) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                var query = Context.Set<TEntity>().AsQueryable();

                foreach (var item in relations)
                {
                    query = query.Include(item);
                }

                Result = await Context.Set<TEntity>().FirstOrDefaultAsync(criterion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                var query = Context.Set<TEntity>().AsQueryable();

                foreach (var item in relations)
                {
                    query = query.Include(item);
                }

                Result = query.FirstOrDefault(criterion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        public async Task<TEntity> FindEntityAsync<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class
        {
            TEntity Result = null;

            try
            {
                var query = Context.Set<TEntity>().AsQueryable();

                foreach (var item in relations)
                {
                    query = query.Include(item);
                }

                Result = await query.FirstOrDefaultAsync(criterion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {
                Result = Context.Set<TEntity>().Where(criterion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {
                Result = await Context.Set<TEntity>().Where(criterion).ToListAsync() ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion, List<Expression<Func<TEntity, TEntity>>> relations) where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {

                var query = Context.Set<TEntity>().AsQueryable().Where(criterion);

                foreach (var item in relations)
                {
                    query = query.Include(item);
                }

                Result = query.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> criterion, List<Expression<Func<TEntity, TEntity>>> relations) where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {

                var query = Context.Set<TEntity>().AsQueryable().Where(criterion);

                foreach (var item in relations)
                {
                    query = query.Include(item);
                }

                Result = await query.ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {

                var query = Context.Set<TEntity>().AsQueryable().Where(criterion);

                foreach (var item in relations)
                {
                    query = query.Include(item);
                }

                Result = query.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class
        {
            List<TEntity> Result = null;

            try
            {

                var query = Context.Set<TEntity>().AsQueryable().Where(criterion);

                foreach (var item in relations)
                {
                    query = query.Include(item);
                }

                Result = await query.ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public bool CheckExist<TEntity>(Expression<Func<TEntity,bool>> criterion) where TEntity : class
        {
            try
            {
                bool result = false;

                var entity = Context.Set<TEntity>().FirstOrDefault(criterion);

                if (entity != null)
                {
                    result = true;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> CheckExistAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class
        {
            try
            {
                bool result = false;

                var entity = await Context.Set<TEntity>().FirstOrDefaultAsync(criterion);

                if (entity != null)
                {
                    result = true;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected virtual int TrySaveChanges()
        {
            return Context.SaveChanges();
        }
        protected virtual async Task<int> TrySaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        
    }
}

