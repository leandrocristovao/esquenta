﻿using Esquenta.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace Esquenta.Entities
{
    public class Venda : IBaseEntity
    {
        public Venda()
        {
            ItemVenda = new List<ItemVenda>();
        }

        public virtual int Id { get; protected set; }
        public virtual DateTime DataVenda { get; set; }
        public virtual decimal ValorTotal { get; set; }
        public virtual Comanda Comanda { get; set; }
        public virtual IList<ItemVenda> ItemVenda { get; set; }
    }
}