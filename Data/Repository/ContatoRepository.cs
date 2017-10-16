using Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Model;
using System.Collections;
using NHibernate;
using NHibernate.Linq;

namespace Data.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ISession _session;

        public ContatoRepository(ISession session)
        {
            _session = session;
        }
        public void Excluir(Contato contato)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(contato);
                tran.Commit();
            }
        }

        public Contato ObterPor(int id)
        {
            return _session.Get<Contato>(id);
        }

        public IEnumerable ObterTodos()
        {
            return _session.Query<Contato>().ToList();
        }

        public void Salvar(Contato contato)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(contato);
                tran.Commit();
            }
        }
    }
}
