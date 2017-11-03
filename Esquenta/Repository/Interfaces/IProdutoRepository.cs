using Esquenta.Entities;

namespace Esquenta.Repository.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Produto GetByCodigoBarra(string codigoBarra);
        Produto GetByNome(string nome);
    }
}