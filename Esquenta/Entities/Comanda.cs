using Esquenta.Entities.Interfaces;

namespace Esquenta.Entities
{
    public class Comanda : IBaseEntity
    {
        public virtual int Id { get; protected set; }
        public virtual bool EmAberto { get; set; }
        public virtual string Nome { get; set; }
        public virtual string CodigoBarras { get; set; }
    }
}