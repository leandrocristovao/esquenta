using Dominio.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Repository
{
    public interface IContatoRepository
    {
        void Salvar(Contato contato);
        void Excluir(Contato contato);
        Contato ObterPor(int id);
        IEnumerable ObterTodos();
    }
}
