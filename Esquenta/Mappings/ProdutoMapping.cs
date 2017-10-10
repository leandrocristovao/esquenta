using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Esquenta.Models;

namespace Esquenta.Mappings
{
    class ProdutoMapping : IAutoMappingOverride<Produto>
    {
        public void Override(AutoMapping<Produto> mapping)
        {
            //mapping.Table("TAcaoRota");
            //mapping.Id(x => x.IDAcaoRota).GeneratedBy.Native(x => x.AddParam("sequence", "SWS_TAcaoRota_ID"));

            //mapping.Map(x => x.Descricao).UniqueKey("UK_TAcaoRota");
            //mapping.Map(x => x.RouteAction, "AcaoRota").UniqueKey("UK_TAcaoRota"); ;
        }
    }
}
