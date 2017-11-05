﻿using Esquenta.Entities;
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
            var last = _session.Query<PeriodoVenda>().OrderByDescending(x => x.Id).FirstOrDefault();

            var entity = new PeriodoVenda()
            {
                DataInicial = last.DataFinal ?? DateTime.Now,
                DataFinal = periodoFinal
            };
            _session.SaveOrUpdate(entity);

            entity = new PeriodoVenda()
            {
                DataInicial = periodoFinal,
                DataFinal = null
            };
            _session.SaveOrUpdate(entity);
        }

        public PeriodoVenda GetPeriodoInicial(DateTime periodoInicial)
        {
            var start = periodoInicial.AddSeconds(0).AddMinutes(0).AddHours(0);
            var end = periodoInicial.AddSeconds(59).AddMinutes(59).AddHours(23);

            return _session.Query<PeriodoVenda>().Where(x => x.DataInicial >= start && x.DataInicial <= end).FirstOrDefault();
        }
    }
}