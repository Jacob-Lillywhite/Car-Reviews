using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CarCollection.DataAccess.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Get Object Id
        T Get(int id);

        //Get all objects Ienumberable
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        //Get the first or Default
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        //Add
        void Add(T entity);

        //Remove
        void Remove(int id);

        //Remove the object itself
        void Remove(T entity);

        //Remove (list an object)
        void RemoveRange(IEnumerable<T> entity);

    }
}
