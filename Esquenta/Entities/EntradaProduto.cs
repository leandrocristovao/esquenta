using Esquenta.Entities.Interfaces;
using System;

namespace Esquenta.Entities
{
    public class EntradaProduto : IBaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual Produto Produto { get; set; }
        public virtual int Quantidade { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual DateTime DataEntrada { get; set; }
    }
}