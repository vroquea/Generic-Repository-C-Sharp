using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        TEntity Create<TEntity>(TEntity newEntity) where TEntity : class;
        /// <summary>
        /// Create a new entity and return a Task
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        Task<TEntity> CreateAsync<TEntity>(TEntity newEntity) where TEntity : class;

        /// <summary>
        /// Modify an existing entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modifiedEntity"></param>
        /// <returns></returns>
        bool Update<TEntity>(TEntity modifiedEntity) where TEntity : class;
        /// <summary>
        /// Modify an existing entity and return a Task
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modifiedEntity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync<TEntity>(TEntity modifiedEntity) where TEntity : class;

        /// <summary>
        /// Modify an existing entity based on conditions
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modifiedEntity"></param>
        /// <param name="properties"></param>
        /// <param name="isModified"></param>
        /// <returns></returns>
        bool Update<TEntity>(TEntity modifiedEntity, List<Expression<Func<TEntity, bool>>> properties,bool isModified) where TEntity : class;
        /// <summary>
        /// Modify an existing entity based on conditions
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modifiedEntity"></param>
        /// <param name="properties"></param>
        /// <param name="isModified"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync<TEntity>(TEntity modifiedEntity, List<Expression<Func<TEntity, bool>>> properties, bool isModified) where TEntity : class;

        /// <summary>
        /// Delete an existing entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="deletedEntity"></param>
        /// <returns></returns>
        bool Delete<TEntity>(TEntity deletedEntity) where TEntity : class;
        /// <summary>
        /// Delete an existing entity and return a Task
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="deletedEntity"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync<TEntity>(TEntity deletedEntity) where TEntity : class;

        /// <summary>
        /// Delete an existing entity based on an attribute (change state)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="deletedEntity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        bool DeletePartial<TEntity>(TEntity deletedEntity, Expression<Func<TEntity,object>> property) where TEntity : class;
        /// <summary>
        /// Delete an existing entity based on an attribute (change state) and return Task
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="deletedEntity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        Task<bool> DeletePartialAsync<TEntity>(TEntity deletedEntity, Expression<Func<TEntity, object>> property) where TEntity : class;

        /// <summary>
        /// Find an entity by some criterion
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <returns></returns>
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        /// <summary>
        /// Find an entity by some criterion and return Task
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <returns></returns>
        Task<TEntity> FindEntityAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;

        /// <summary>
        /// Find an entity by some criterion and bring relational data
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <param name="relations">Relations</param>
        /// <returns></returns>
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;
        /// <summary>
        /// Find an entity by some criteria and bring relational data and return Task
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <param name="relations"></param>
        /// <returns></returns>
        Task<TEntity> FindEntityAsync<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;

        /// <summary>
        /// Get all data from a table by some criterion
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        /// <summary>
        /// Get all data from a table by some criterion and return Task
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;

        /// <summary>
        /// Get all data from a table by some criterion and related data from relationship
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <param name="relations"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion,params string[] relations) where TEntity : class;
        /// <summary>
        /// Get all data from a table by some criterion and related data from relationship and return Task
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <param name="relations"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;

        /// <summary>
        /// Check if an entity existing in a database
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <returns></returns>
        bool CheckExist<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        /// <summary>
        /// Check if an entity existing in a database and return a Task
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criterion"></param>
        /// <returns></returns>
        Task<bool> CheckExistAsync<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
    }
}
