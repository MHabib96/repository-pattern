using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RepositoryPattern.Database;
using RepositoryPattern.Repositories.Interfaces;

namespace RepositoryPattern.Repositories.Abstracts
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PlaygroundContext DbContext;

        protected Repository(PlaygroundContext dbContext)
        {
            DbContext = dbContext;
        }

        public T GetById(Guid id) => DbContext.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => DbContext.Set<T>().ToList();

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression) => DbContext.Set<T>().Where(expression);

        public void Add(T entity) => DbContext.Set<T>().Add(entity);

        public void AddRange(IEnumerable<T> entities) => DbContext.Set<T>().AddRange(entities);

        public void Remove(T entity) => DbContext.Set<T>().Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => DbContext.Set<T>().RemoveRange(entities);
    }
}