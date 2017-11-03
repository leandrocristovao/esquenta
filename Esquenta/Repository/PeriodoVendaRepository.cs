using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;

namespace Esquenta.Repository
{
    public class PeriodoVendaRepository : BaseRepository<PeriodoVenda>, IPeriodoVendaRepository
    {
        public PeriodoVendaRepository(ISession session) : base(session)
        {
        }

        public void FecharPeriodo(DateTime periodoFinal)
        {
            var last = _session.Query<PeriodoVenda>().Last();

            var entity = new PeriodoVenda()
            {
                DataInicial = last.DataFinal,
                DataFinal = periodoFinal
            };
            _session.SaveOrUpdate(entity);
        }
    }
}