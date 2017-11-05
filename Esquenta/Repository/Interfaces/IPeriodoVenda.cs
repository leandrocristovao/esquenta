using Esquenta.Entities;
using System;

namespace Esquenta.Repository.Interfaces
{
    public interface IPeriodoVendaRepository : IBaseRepository<PeriodoVenda>
    {
        void FecharPeriodo(DateTime periodoFinal);
        PeriodoVenda GetPeriodoInicial(DateTime periodoInicial);
    }
}