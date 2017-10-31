using Esquenta.Entities.Interfaces;
using System;

namespace Esquenta.Entities
{
    public class ItemVenda : IBaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual DateTime DataVenda { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual decimal ValorTotal { get; set; }
        public virtual long Quantidade { get; set; }
        public virtual Venda Venda { get; set; }
        public virtual Produto Produto { get; set; }
    }
}