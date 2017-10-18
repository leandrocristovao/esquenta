using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Esquenta.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Save(object entity);

        T Save(T entity);

        T SaveOrUpdate(T entity);

        T Update(T entity);

        void Delete(T entity);

        T Get(int id);

        List<T> List();
        List<T> List(Expression<Func<T, bool>> filter);
    }
}