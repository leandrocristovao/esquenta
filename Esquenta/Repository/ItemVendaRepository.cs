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
            return _session.Query<ItemVenda>().Where(x => x.DataVenda >= dataInicial).ToList();
        }

        public List<ItemVenda> GetConsumo(DateTime periodoInicial, DateTime? periodoFinal)
        {
            var query = _session.Query<ItemVenda>().Where(x => x.DataVenda >= periodoInicial && x.Venda.Comanda.Id == 2);
            if (periodoFinal != null)
            {
                query = query.Where(x => x.DataVenda <= periodoFinal);
            }

            return query.ToList();
        }

        public List<ItemVenda> GetVendasByProduto(Produto produto)
        {
            var mes = DateTime.Now.FirstDayOfMonth();
            return _session.Query<ItemVenda>().Where(x => x.Produto == produto && x.DataVenda >= mes).OrderByDescending(x => x.DataVenda).ToList();
        }
    }
}