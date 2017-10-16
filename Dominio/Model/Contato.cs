using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Model
{
    public class Contato
    {
        private int _id;
        public virtual int Id { get { return _id; } }
        public virtual string Nome { get; set; }
    }
}
