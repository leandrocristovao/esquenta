using Esquenta.Entities;
using System;
using System.Collections.Generic;

namespace Esquenta.Repository.Interfaces
{
    public interface IItemVendaRepository : IBaseRepository<ItemVenda>
    {
        List<ItemVenda> GetVendasDia(DateTime dataInicial);

        List<ItemVenda> GetConsumo(DateTime periodoInicial, DateTime? periodoFinal);
    }
}