using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Linq;
using System.Linq;

namespace Esquenta.Repository
{
    public class ComandaRepository : BaseRepository<Comanda>, IComandaRepository
    {
        public ComandaRepository(ISession session) : base(session)
        {
        }

        public Comanda Get(string codigoBarra)
        {
            return _session.Query<Comanda>().Where(x => x.CodigoBarras.Equals(codigoBarra)).FirstOrDefault();
        }
    }
}