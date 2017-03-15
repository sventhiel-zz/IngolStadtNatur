using IngolStadtNatur.Entities.NH.Common;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IngolStadtNatur.Persistence.Api
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);

        IQueryable<T> Query();

        IQueryable<T> Query(Expression<Func<T, bool>> expression);

        void Remove(T entity);

        void Update(T entity);
    }
}
