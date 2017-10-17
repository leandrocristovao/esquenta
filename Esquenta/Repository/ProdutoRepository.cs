using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;

namespace Esquenta.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ISession session) : base(session)
        {
        }
    }
}