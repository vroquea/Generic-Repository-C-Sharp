using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepository : IDisposable
    {
        TEntity Create<TEntity>(TEntity newEntity) where TEntity : class;
        bool Update<TEntity>(TEntity modifiedEntity) where TEntity : class;
        bool Update<TEntity>(TEntity modifiedEntity, List<Expression<Func<TEntity, bool>>> properties,bool isModified) where TEntity : class;
        bool Delete<TEntity>(TEntity deletedEntity) where TEntity : class;
        bool DeletePartial<TEntity>(TEntity deletedEntity, Expression<Func<TEntity,object>> property) where TEntity : class;
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion, List<Expression<Func<TEntity,TEntity>>> relations) where TEntity : class;
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criterion, params string[] relations) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion, List<Expression<Func<TEntity, TEntity>>> relations) where TEntity : class;
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criterion,params string[] relations) where TEntity : class;
        bool CheckExist<TEntity>(Expression<Func<TEntity, bool>> criterion) where TEntity : class;
    }
}
