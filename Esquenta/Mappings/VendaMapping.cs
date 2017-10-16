using Esquenta.Entities;
using FluentNHibernate.Automapping.Alterations;

namespace Esquenta.Mappings
{
    public class VendaMapping : IAutoMappingOverride<Venda>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<Venda> mapping)
        {
            mapping.Table("Venda");
            mapping.Id(x => x.Id, "IDVenda").GeneratedBy.Native(x => x.AddParam("sequence", "SWS_Venda_ID"));

            mapping.References<Comanda>(x => x.Comanda, "Comanda_id");

            mapping.HasMany<ItemVenda>(x => x.ItemVenda).KeyColumn("IDItemVenda").Inverse().Cascade.All();
        }
    }
}