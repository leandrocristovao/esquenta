using Esquenta.Entities;
using FluentNHibernate.Automapping.Alterations;

namespace Esquenta.Mappings
{
    public class ItemVendaMapping : IAutoMappingOverride<ItemVenda>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<ItemVenda> mapping)
        {
            mapping.Table("ItemVenda");
            mapping.Id(x => x.Id, "IDItemVenda").GeneratedBy.Native(x => x.AddParam("sequence", "SWS_ItemVenda_ID"));

            mapping.References<Venda>(x => x.Venda, "IDVenda");
        }
    }
}