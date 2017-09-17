using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Repository
{
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Find an entity by some criterion
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        /// <summary>
        /// Find an entity by some criterion async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        Task<TEntity> FindEntityAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;

        /// <summary>
        /// Find an entity by some criterion and bring relational data
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <param name="relations">Relations</param>
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;
        /// <summary>
        /// Find an entity by some criterion and bring relational data async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <param name="relations"></param>
        Task<TEntity> FindEntityAsync<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;

        /// <summary>
        /// Find an entity by some criterion and bring relational data
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <param name="relations">Relations</param>
        TEntity FindEntity<TEntity, TRelation>(Expression<Func<TEntity, bool>> criterion, Expression<Func<TEntity, TRelation>> relation) where TEntity : class;
        /// <summary>
        /// Find an entity by some criterion and bring relational data async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <param name="relations"></param>
        Task<TEntity> FindEntityAsync<TEntity, TRelation>(Expression<Func<TEntity, bool>> criterion, Expression<Func<TEntity, TRelation>> relation) where TEntity : class;

        /// <summary>
        /// Get all data from a table by some criterion
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        /// <summary>
        /// Get all data from a table by some criterion async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;

        /// <summary>
        /// Get all data from a table by some criterion and related data from relationship
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <param name="relations"></param>
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;
        /// <summary>
        /// Get all data from a table by some criterion and related data from relationship async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <param name="relations"></param>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;

        /// <summary>
        /// Check if an entity existing in database
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        bool CheckExist<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        /// <summary>
        /// Check if an entity existing in database
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        Task<bool> CheckExistAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;

        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="newEntity"></param>
        TEntity Create<TEntity>(TEntity newEntity) where TEntity : class;
        /// <summary>
        /// Create a new entity async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="newEntity"></param>
        Task<TEntity> CreateAsync<TEntity>(TEntity newEntity) where TEntity : class;

        /// <summary>
        /// Modify an existing entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modifiedEntity"></param>
        bool Update<TEntity>(TEntity modifiedEntity) where TEntity : class;
        /// <summary>
        /// Modify an existing entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modifiedEntity"></param>
        Task<bool> UpdateAsync<TEntity>(TEntity modifiedEntity) where TEntity : class;

        /// <summary>
        /// Modify an existing entity based on conditions
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modifiedEntity"></param>
        /// <param name="properties"></param>
        /// <param name="isModified"></param>
        bool Update<TEntity>(TEntity modifiedEntity, List<Expression<Func<TEntity, bool>>> properties, bool isModified) where TEntity : class;
        /// <summary>
        /// Modify an existing entity based on conditions
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modifiedEntity"></param>
        /// <param name="properties"></param>
        /// <param name="isModified"></param>
        Task<bool> UpdateAsync<TEntity>(TEntity modifiedEntity, List<Expression<Func<TEntity, bool>>> properties, bool isModified) where TEntity : class;

        /// <summary>
        /// Delete an existing entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="deletedEntity"></param>
        bool Delete<TEntity>(TEntity deletedEntity) where TEntity : class;
        /// <summary>
        /// Delete an existing entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="deletedEntity"></param>
        Task<bool> DeleteAsync<TEntity>(TEntity deletedEntity) where TEntity : class;

        /// <summary>
        /// Delete an existing entity based on an attribute (change state)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="deletedEntity"></param>
        /// <param name="property"></param>
        bool DeletePartial<TEntity>(TEntity deletedEntity, Expression<Func<TEntity, object>> property) where TEntity : class;
        /// <summary>
        /// Delete an existing entity based on an attribute (change state) async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="deletedEntity"></param>
        /// <param name="property"></param>
        Task<bool> DeletePartialAsync<TEntity>(TEntity deletedEntity, Expression<Func<TEntity, object>> property) where TEntity : class;
    }
}
