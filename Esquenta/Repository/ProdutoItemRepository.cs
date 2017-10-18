using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;

namespace Esquenta.Repository
{
    public class ProdutoItemRepository : BaseRepository<ProdutoItem>, IProdutoItemRepository
    {
        public ProdutoItemRepository(ISession session) : base(session)
        {
        }
    }
}