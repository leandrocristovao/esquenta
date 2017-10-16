using Esquenta.Entities;
using FluentNHibernate.Automapping.Alterations;

namespace Esquenta.Mappings
{
    public class ComandaMapping : IAutoMappingOverride<Comanda>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<Comanda> mapping)
        {
            mapping.Table("Comanda");
            mapping.Id(x => x.Id, "IDComanda").GeneratedBy.Native(x => x.AddParam("sequence", "SWS_Comanda_ID"));
        }
    }
}