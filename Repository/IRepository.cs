using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository : IDisposable
    {
        TEntity Create<TEntity>(TEntity newEntity) where TEntity : class;
        Task<TEntity> CreateAsync<TEntity>(TEntity newEntity) where TEntity : class;

        bool Update<TEntity>(TEntity modifiedEntity) where TEntity : class;
        Task<bool> UpdateAsync<TEntity>(TEntity modifiedEntity) where TEntity : class;

        bool Update<TEntity>(TEntity modifiedEntity, List<Expression<Func<TEntity, bool>>> properties,bool isModified) where TEntity : class;
        Task<bool> UpdateAsync<TEntity>(TEntity modifiedEntity, List<Expression<Func<TEntity, bool>>> properties, bool isModified) where TEntity : class;

        bool Delete<TEntity>(TEntity deletedEntity) where TEntity : class;
        Task<bool> DeleteAsync<TEntity>(TEntity deletedEntity) where TEntity : class;

        bool DeletePartial<TEntity>(TEntity deletedEntity, Expression<Func<TEntity,object>> property) where TEntity : class;
        Task<bool> DeletePartialAsync<TEntity>(TEntity deletedEntity, Expression<Func<TEntity, object>> property) where TEntity : class;

        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        Task<TEntity> FindEntityAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;

        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;
        Task<TEntity> FindEntityAsync<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;

        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion,params string[] relations) where TEntity : class;
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;

        bool CheckExist<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        Task<bool> CheckExistAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
    }
}
