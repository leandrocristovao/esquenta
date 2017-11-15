using Esquenta.Entities;
using Esquenta.Repository.Extensions;
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

        public bool ChecarPeriodoEmAberto()
        {
            var dataAtual = DateTime.Now;
            var dataInicial = dataAtual.AbsoluteStart();
            var last = _session.Query<PeriodoVenda>().Where(x => x.DataFinal == null).OrderByDescending(x => x.Id).FirstOrDefault();
            if (last == null)
            {
                return false;
            }
            var a = last.DataInicial.ToString("dd/MM/yyyy");
            var b = dataAtual.ToString("dd/MM/yyyy");
            //var dataFechamentoInicial = last.DataInicial.AbsoluteStart();
            //var dataFechamentoFinal = last.DataInicial.AbsoluteEnd();
            return (last.DataInicial.ToString("dd/MM/yyyy").Equals(dataAtual.ToString("dd/MM/yyyy")));
        }

        public void FecharPeriodo(DateTime periodoFinal)
        {
            var last = _session.Query<PeriodoVenda>().OrderByDescending(x => x.Id).FirstOrDefault();
            last.DataFinal = periodoFinal;

            _session.Update(last);

            var entity = new PeriodoVenda()
            {
                DataInicial = periodoFinal,
                DataFinal = null
            };
            _session.Save(entity);
            _session.Flush();
        }

        public PeriodoVenda GetPeriodoInicial(DateTime periodoInicial)
        {
            var start = periodoInicial.AddSeconds(0).AddMinutes(0).AddHours(0);
            var end = periodoInicial.AddSeconds(59).AddMinutes(59).AddHours(23);

            return _session.Query<PeriodoVenda>().Where(x => x.DataInicial >= start && x.DataInicial <= end).FirstOrDefault();
        }
    }
}