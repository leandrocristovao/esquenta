using Esquenta.Entities;
using System;

namespace Esquenta.Repository.Interfaces
{
    public interface IVendaRepository : IBaseRepository<Venda>
    {
        System.Collections.Generic.List<Venda> GetVendasDia(DateTime dataInicial);

        System.Collections.Generic.List<Venda> GetVendasDia(DateTime dataInicial, DateTime? dataFinal);

        System.Collections.Generic.List<Venda> GetVendasDia(PeriodoVenda periodo);
    }
}