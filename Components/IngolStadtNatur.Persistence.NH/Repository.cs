using IngolStadtNatur.Entities.NH.Common;
using IngolStadtNatur.Persistence.Api;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IngolStadtNatur.Persistence.NH
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ISession _session;

        public Repository()
        {
            _session = SessionFactoryManager.SessionFactory.GetCurrentSession();
        }

        public void Add(T entity)
        {
            _session.Save(entity);
        }

        public T Get(long id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> Query()
        {
            return _session.Query<T>();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expression)
        {
            return Query().Where(expression);
        }

        public void Remove(T entity)
        {
            _session.Delete(entity);
        }

        public void Update(T entity)
        {
            _session.Update(entity);

        }
    }
}