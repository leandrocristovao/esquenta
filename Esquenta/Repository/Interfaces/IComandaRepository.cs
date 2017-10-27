using Esquenta.Entities;

namespace Esquenta.Repository.Interfaces
{
    public interface IComandaRepository : IBaseRepository<Comanda>
    {
        Comanda Get(string codigoBarra);
    }
}