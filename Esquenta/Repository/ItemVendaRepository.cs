using Esquenta.Entities;
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
    }
}