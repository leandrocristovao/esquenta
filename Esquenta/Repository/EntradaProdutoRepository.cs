using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;

namespace Esquenta.Repository
{
    public class EntradaProdutoRepository : BaseRepository<EntradaProduto>, IEntradaProdutoRepository
    {
        public EntradaProdutoRepository(ISession session) : base(session)
        {
        }

        public override EntradaProduto SaveOrUpdate(EntradaProduto entity)
        {
            ConnectionService service = ConnectionService.GetInstance();
            var controller = service.GetProdutoRepository();

            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(entity);

                    var produto = controller.Get(entity.Produto.Id);
                    produto.Quantidade += entity.Quantidade;
                    controller.SaveOrUpdate(produto);

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
    }
}