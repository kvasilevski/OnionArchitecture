using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OA.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> AsQueryable();
        T Get(long id);
        IEnumerable<T> GetMany(Func<T, bool> where);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
