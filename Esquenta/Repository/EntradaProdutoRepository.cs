using Esquenta.Entities;
using Esquenta.Repository.Interfaces;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Esquenta.Repository
{
    public class EntradaProdutoRepository : BaseRepository<EntradaProduto>, IEntradaProdutoRepository
    {
        public EntradaProdutoRepository(ISession session) : base(session)
        {
        }

        public List<EntradaProduto> GetByProduto(Produto produto)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    var query = _session.Query<EntradaProduto>().Where(x => x.Produto == produto).OrderByDescending(x => x.DataEntrada);
                    return query.ToList();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public override EntradaProduto SaveOrUpdate(EntradaProduto entity)
        {
            ConnectionService service = ConnectionService.GetInstance();
            var controller = service.GetProdutoRepository();

            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(entity);

                    var produto = controller.Get(entity.Produto.Id);
                    produto.Quantidade += entity.Quantidade;
                    controller.SaveOrUpdate(produto);

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