using Esquenta.Entities.Interfaces;

namespace Esquenta.Entities
{
    public class Produto: IBaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual string CodigoBarras { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual long Quantidade { get; set; }
        public virtual decimal Valor { get; set; }
    }
}