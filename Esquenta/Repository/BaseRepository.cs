using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Esquenta.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected IBaseRepository<T> _baseElement;
        protected ISession _session;

        public BaseRepository(ISession session)
        {
            _session = session;
        }

        public virtual void Delete(T entity)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(entity);
                tran.Commit();
            }
        }

        public virtual T Get(int id)
        {
            return _session.Get<T>(id);
        }

        public virtual List<T> List()
        {
            return _session.Query<T>().ToList();
        }

        public virtual List<T> List(Expression<Func<T, bool>> filter)
        {
            return _session.Query<T>().Where(filter).ToList();
        }

        public virtual void Save(object entity)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(entity);
                tran.Commit();
            }
        }

        public virtual T SaveOrUpdate(T entity)
        {
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

        public virtual T Save(T entity)
        {
            //using (var tran = _session.BeginTransaction())
            //{
            //    _session.Save(entity);
            //    tran.Commit();
            //    return entity;
            //}
            return this.SaveOrUpdate(entity);
        }

        public virtual T Update(T entity)
        {
            //using (var tran = _session.BeginTransaction())
            //{
            //    _session.Update(entity);
            //    tran.Commit();
            //    return entity;
            //}
            return this.SaveOrUpdate(entity);
        }
    }
}