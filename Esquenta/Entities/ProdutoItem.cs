using Esquenta.Entities.Interfaces;

namespace Esquenta.Entities
{
    public class ProdutoItem : IBaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual Produto Produto { get; set; }
        public virtual Produto Parent { get; set; }
        public virtual int Quantidade { get; set; }
    }
}