using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Util;
using System;
using System.Collections.Generic;
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
                    entity.ValorTotal = entity.ItemVenda.Sum(x => x.Valor * x.Quantidade);
                    entity.ValorFinal = entity.ValorTotal - entity.ValorDesconto;
                    entity.QuantidadeItens = entity.ItemVenda.Count();
                    _session.SaveOrUpdate(entity);

                    entity.ItemVenda.ForEach(item =>
                    {
                        item.ValorTotal = item.Valor * item.Quantidade;
                        item.DataVenda = entity.DataVenda;
                        _session.SaveOrUpdate(item);
                    });

                    ConnectionService service = ConnectionService.GetInstance();
                    var controller = service.GetProdutoRepository();
                    //var itensToUpdate = entity.ItemVenda.GroupBy(x => x.Produto.Id).Select(g => new { IDProduto = g.Key, Count = g.Count() }).ToList();
                    //itensToUpdate.ForEach(itemID =>
                    //{
                    //    var item = controller.Get(itemID.IDProduto);
                    //    item.Quantidade -= itemID.Count;
                    //    controller.SaveOrUpdate(item);
                    //});

                    entity.ItemVenda.ForEach(item =>
                    {
                        item.Produto.Itens.ForEach(subIten =>
                        {
                            var update = controller.Get(subIten.Produto.Id);
                            update.Quantidade -= (subIten.Quantidade * item.Quantidade);
                            controller.SaveOrUpdate(update);
                        });
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

        public List<Venda> GetVendasDia(DateTime dataInicial)
        {
            return _session.Query<Venda>().Where(x => x.DataVenda >= dataInicial).ToList();
        }
    }
}