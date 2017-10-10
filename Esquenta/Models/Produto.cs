namespace Esquenta.Models
{
    public class Produto
    {
        public virtual long Id { get; private set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual long Quantidade { get; set; }
    }
}