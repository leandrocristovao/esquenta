using Esquenta.Entities.Interfaces;
using System.Collections.Generic;

namespace Esquenta.Entities
{
    public class Produto : IBaseEntity
    {
        public Produto()
        {
            Itens = new List<ProdutoItem>();
        }
        public virtual int Id { get; protected set; }
        public virtual string CodigoBarras { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual long Quantidade { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual IList<ProdutoItem> Itens { get; set; }
    }
}