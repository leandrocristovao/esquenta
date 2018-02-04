using Esquenta.Entities;
using Esquenta.Repository.Extensions;
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
                    entity.ValorFinal = (entity.ValorTotal + entity.ValorAcrescimo) - entity.ValorDesconto;
                    entity.QuantidadeItens = entity.ItemVenda.Count();
                    _session.SaveOrUpdate(entity);

                    entity.ItemVenda.ForEach(item =>
                    {
                        item.ValorTotal = item.Valor * item.Quantidade;
                        _session.SaveOrUpdate(item);
                    });

                    //TODO Leandro: remover daqui
                    //ConnectionService service = ConnectionService.GetInstance();
                    //var controller = service.GetProdutoRepository();
                    //entity.ItemVenda.ForEach(item =>
                    //{
                    //    item.Produto.Itens.ForEach(subIten =>
                    //    {
                    //        var update = controller.Get(subIten.Produto.Id);
                    //        update.Quantidade -= (subIten.Quantidade * item.Quantidade);
                    //        controller.SaveOrUpdate(update);
                    //    });
                    //});

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
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    return _session.Query<Venda>().Where(x => (x.DataVenda >= dataInicial && x.Comanda.Id != 2) || x.EmAberto == true).OrderByDescending(x => x.Id).ToList();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public List<Venda> GetVendasDia(DateTime dataInicial, DateTime? dataFinal)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    var query = _session.Query<Venda>().Where(x => x.Comanda.Id != 2 && (x.DataVenda >= dataInicial || x.EmAberto == true));
                    if (dataFinal != null)
                    {
                        query = query.Where(x => x.DataVenda <= dataFinal);
                    }

                    return query.ToList();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public List<Venda> GetVendasDia(PeriodoVenda periodo)
        {
            return GetVendasDia(periodo.DataInicial, periodo.DataFinal);
        }

        public Venda GetVendasEmAberto(Comanda comanda)
        {
            //var obj = _session.Query<Venda>().Where(x => x.EmAberto == true && x.Comanda == comanda).FirstOrDefault();
            //if (obj != null)
            //{
            //    _session.Refresh(obj);
            //}

            //return obj;
            var connected = _session.IsConnected;
            var opened = _session.IsOpen;
            var sessionFactoryClosed = _session.SessionFactory.IsClosed;
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    var obj = _session.Query<Venda>().Where(x => x.EmAberto == true && x.Comanda == comanda).FirstOrDefault();
                    if (obj != null)
                    {
                        _session.Refresh(obj);
                    }

                    return obj;
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public List<Venda> GetVendasEmAberto()
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    return _session.Query<Venda>().Where(x => x.EmAberto == true).ToList();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public void BaixarVenda(Venda entity)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    ConnectionService service = ConnectionService.GetInstance();
                    var controller = service.GetProdutoRepository();

                    entity.ItemVenda.ForEach(item =>
                    {
                        item.Produto.Itens.ForEach(subIten =>
                        {
                            var update = controller.Get(subIten.Produto.Id);
                            update.Quantidade -= (subIten.Quantidade * item.Quantidade);
                            controller.SaveOrUpdate(update);
                        });
                    });

                    entity.EmAberto = false;
                    entity.Terminal = null;
                    entity.DataVenda = DateTime.Now;
                    _session.Update(entity);

                    _session.Flush();
                    transaction.Commit();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public void CancelarVenda(Venda entity)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    ConnectionService service = ConnectionService.GetInstance();
                    var controller = service.GetProdutoRepository();

                    entity.ItemVenda.ForEach(item =>
                    {
                        item.Produto.Itens.ForEach(subIten =>
                        {
                            var update = controller.Get(subIten.Produto.Id);
                            update.Quantidade += (subIten.Quantidade * item.Quantidade);
                            controller.SaveOrUpdate(update);
                        });
                    });

                    //_session.Update(entity);
                    _session.Delete(entity);
                    _session.Flush();

                    transaction.Commit();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public void EntradaTerminal(Venda entity, string terminal)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    entity.Terminal = terminal;
                    _session.Update(entity);
                    _session.Flush();

                    transaction.Commit();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }

        public List<Venda> GetVendasMes(DateTime dataInicial, Comanda comanda)
        {
            if (!_session.Transaction.IsActive)
            {
                using (var transaction = _session.BeginTransaction())
                {
                    return _session.Query<Venda>().Where(x => x.DataVenda >= dataInicial.FirstDayOfMonth() && x.DataVenda <= dataInicial.LastDayOfMonth()).OrderByDescending(x => x.Id).ToList();
                }
            }
            else
            {
                throw new Exception("Erro ao baixar estoque: Transaction não disponivel");
            }
        }
    }
}