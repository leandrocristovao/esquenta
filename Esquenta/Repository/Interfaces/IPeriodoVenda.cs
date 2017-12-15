using Esquenta.Entities;
using System;

namespace Esquenta.Repository.Interfaces
{
    public interface IPeriodoVendaRepository : IBaseRepository<PeriodoVenda>
    {
        bool ChecarPeriodoEmAberto();

        PeriodoVenda GetPeriodoAtual();

        PeriodoVenda GetPeriodoInicial(DateTime periodoInicial);

        void FecharPeriodo(DateTime periodoFinal);
    }
}