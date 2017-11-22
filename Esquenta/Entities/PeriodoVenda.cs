using Esquenta.Entities.Interfaces;
using System;

namespace Esquenta.Entities
{
    public class PeriodoVenda : IBaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime DataInicial { get; set; }
        public virtual DateTime? DataFinal { get; set; }
        public virtual decimal ValorCaixa { get; set; }
        public virtual decimal ValorEmAberto { get; set; }
    }
}