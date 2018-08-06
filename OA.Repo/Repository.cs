using Microsoft.EntityFrameworkCore;
using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OA.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        protected DbSet<T> dbSet;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public IQueryable<T> AsQueryable()
        {
            return dbSet.AsQueryable();
        }

        public T Get(long id)
        {
            return dbSet.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetMany(Func<T, bool> where)
        {
            return dbSet.Where(where).ToList();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
