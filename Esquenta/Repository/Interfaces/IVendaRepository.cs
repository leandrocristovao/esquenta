using Esquenta.Entities;
using System;
using System.Collections.Generic;

namespace Esquenta.Repository.Interfaces
{
    public interface IVendaRepository : IBaseRepository<Venda>
    {
        List<Venda> GetVendasDia(DateTime dataInicial);

        List<Venda> GetVendasDia(DateTime dataInicial, DateTime? dataFinal);

        List<Venda> GetVendasDia(PeriodoVenda periodo);

        List<Venda> GetVendasEmAberto();

        Venda GetVendasEmAberto(Comanda comanda);

        void BaixarVenda(Venda venda);

        void CancelarVenda(Venda venda);
        void EntradaTerminal(Venda venda, string terminal);
    }
}