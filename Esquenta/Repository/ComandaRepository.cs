﻿using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;

namespace Esquenta.Repository
{
    public class ComandaRepository : BaseRepository<Comanda>, IComandaRepository
    {
        public ComandaRepository(ISession session) : base(session)
        {
        }

        public Comanda Get(string codigoBarra)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    return _session.Query<Comanda>().Where(x => x.CodigoBarras.Equals(codigoBarra)).FirstOrDefault();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public Comanda GetByNome(string nome)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    return _session.Query<Comanda>().Where(x => x.Nome.Equals(nome)).FirstOrDefault();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }
    }
}