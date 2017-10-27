using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Util;

namespace Esquenta.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ISession session) : base(session)
        {
        }

        public override Produto SaveOrUpdate(Produto entity)
        {
            ConnectionService service = ConnectionService.GetInstance();
            var controller = service.GetProdutoItemRepository();

            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    //Todo o item tem um produtoItem
                    if (entity.Itens.Count == 0)
                    {
                        entity.Itens.Add(new ProdutoItem
                        {
                            Produto = entity,
                            Parent = entity,
                            Quantidade = 1
                        });
                    }

                    _session.SaveOrUpdate(entity);
                    //Removo da lista, noovs itens que ja estao no sistema
                    entity.Itens.ForEach(itemVenda =>
                    {
                        //controller.SaveOrUpdate(itemVenda);
                        _session.SaveOrUpdate(itemVenda);
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

            return entity;
        }
    }
}