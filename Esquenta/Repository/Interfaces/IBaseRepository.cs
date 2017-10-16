using Esquenta.Entities;
using System.Collections.Generic;

namespace Esquenta.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Save(object entity);
        void Teste(Venda entity);
        T Save(T entity);
        T SaveOrUpdate(T entity);
        T Update(T entity);

        void Delete(T entity);

        T Get(int id);

        List<T> List();
    }
}