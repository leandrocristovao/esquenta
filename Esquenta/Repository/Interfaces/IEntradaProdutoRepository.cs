using Esquenta.Entities;
using System.Collections.Generic;

namespace Esquenta.Repository.Interfaces
{
    public interface IEntradaProdutoRepository : IBaseRepository<EntradaProduto>
    {
        List<EntradaProduto> GetByProduto(Produto produto);
    }
}