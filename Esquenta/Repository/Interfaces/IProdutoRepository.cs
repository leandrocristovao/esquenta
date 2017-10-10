using Esquenta.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquenta.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        void Save(Produto entity);
        void Delete(Produto entity);
        Produto Get(int id);
        IEnumerable List();
    }
}
