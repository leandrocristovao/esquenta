using Esquenta.Entities;
using Esquenta.Repository.Extensions;
using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Esquenta.Repository
{
    public class ItemVendaRepository : BaseRepository<ItemVenda>, IItemVendaRepository
    {
        public ItemVendaRepository(ISession session) : base(session)
        {
        }

        public List<ItemVenda> GetVendasDia(DateTime dataInicial)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    return _session.Query<ItemVenda>().Where(x => x.DataVenda >= dataInicial).ToList();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public List<ItemVenda> GetConsumo(DateTime periodoInicial, DateTime? periodoFinal)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    var query = _session.Query<ItemVenda>().Where(x => x.DataVenda >= periodoInicial && x.Venda.Comanda.Id == 2);
                    if (periodoFinal != null)
                    {
                        query = query.Where(x => x.DataVenda <= periodoFinal);
                    }

                    return query.ToList();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public List<ItemVenda> GetVendasByProduto(Produto produto)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    var mes = DateTime.Now.FirstDayOfMonth();
                    return _session.Query<ItemVenda>().Where(x => x.Produto == produto && x.DataVenda >= mes).OrderByDescending(x => x.DataVenda).ToList();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }
    }
}