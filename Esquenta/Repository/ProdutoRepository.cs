using Esquenta.Models;
using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Linq;
using System.Collections;
using System.Linq;

namespace Esquenta.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ISession _session;

        public ProdutoRepository(ISession session)
        {
            _session = session;
        }

        public void Delete(Produto entity)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(entity);
                tran.Commit();
            }
        }

        public Produto Get(int id)
        {
            return _session.Get<Produto>(id);
        }

        public IEnumerable List()
        {
            return _session.Query<Produto>().ToList();
        }

        public void Save(Produto entity)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                tran.Commit();
            }
        }
    }
}