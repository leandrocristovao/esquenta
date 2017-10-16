using Esquenta.Entities;
using Esquenta.Entities.Interfaces;
using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Util;
using System.Collections.Generic;
using System.Linq;

namespace Esquenta.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : IBaseEntity
    {
        protected IBaseRepository<T> _baseElement;
        protected ISession _session;

        public BaseRepository(ISession session)
        {
            _session = session;
        }

        public void Delete(T entity)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(entity);
                tran.Commit();
            }
        }

        public T Get(int id)
        {
            return _session.Get<T>(id);
        }

        public List<T> List()
        {
            return _session.Query<T>().ToList();
        }

        public void Teste(Venda entity)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(entity);
                    entity.ItemVenda.ForEach(item =>
                    {

                        _session.Save(item);
                    });
                    _session.Flush();

                    transaction.Commit();
                }
            }
            else
            {
                _session.SaveOrUpdate(entity);
                _session.Flush();
            }
        }

        public void Save(object entity) {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(entity);
                tran.Commit();
            }
        }
        public T SaveOrUpdate(T entity)
        {
            //using (var tran = _session.BeginTransaction())
            //{
            //    _session.SaveOrUpdate(entity);
            //    tran.Commit();
            //    return entity;
            //}


            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(entity);
                    _session.Flush();

                    transaction.Commit();
                }
            }
            else
            {
                _session.SaveOrUpdate(entity);
                _session.Flush();
            }
            return entity;
        }

        public T Save(T entity)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(entity);
                tran.Commit();
                return entity;
            }
        }

        public T Update(T entity)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Update(entity);
                tran.Commit();
                return entity;
            }
        }
    }
}