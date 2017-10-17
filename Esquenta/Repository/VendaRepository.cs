using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Util;
using System.Linq;

namespace Esquenta.Repository
{
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public VendaRepository(ISession session) : base(session)
        {
        }

        public override Venda Save(Venda entity)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(entity);
                    entity.ItemVenda.ForEach(item =>
                    {
                        item.DataVenda = entity.DataVenda;
                        _session.SaveOrUpdate(item);
                    });

                    ConnectionService service = ConnectionService.GetInstance();
                    var controller = service.GetProdutoRepository();
                    var itensToUpdate = entity.ItemVenda.GroupBy(x => x.Produto.Id).Select(g => new { IDProduto = g.Key, Count = g.Count() }).ToList();
                    itensToUpdate.ForEach(itemID =>
                    {
                        var item = controller.Get(itemID.IDProduto);
                        item.Quantidade -= itemID.Count;
                        controller.SaveOrUpdate(item);
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