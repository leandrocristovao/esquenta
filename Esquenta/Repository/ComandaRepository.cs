using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;

namespace Esquenta.Repository
{
    public class ComandaRepository : BaseRepository<Comanda>, IComandaRepository
    {
        public ComandaRepository(ISession session) : base(session)
        {
        }
    }
}