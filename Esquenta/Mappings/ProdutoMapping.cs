using Esquenta.Entities;
using FluentNHibernate.Automapping.Alterations;

namespace Esquenta.Mappings
{
    public class ProdutoMapping : IAutoMappingOverride<Produto>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<Produto> mapping)
        {
            mapping.Table("Produto");
            mapping.Id(x => x.Id, "IDProduto").GeneratedBy.Native(x => x.AddParam("sequence", "SWS_Produto_ID"));
        }
    }
}