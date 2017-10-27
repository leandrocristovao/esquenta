using Esquenta.Entities;

namespace Esquenta.Repository.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Produto Get(string codigoBarra);
    }
}