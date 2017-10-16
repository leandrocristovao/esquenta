using Dominio.Model;
using FluentNHibernate.Mapping;

namespace Data.NHibernate
{
    public class ContatoMap : ClassMap<Contato>
    {
        public ContatoMap()
        {
            Id(x => x.Id)
                .GeneratedBy.Identity()
                .UnsavedValue(0)
                .Access.CamelCaseField(Prefix.Underscore);

            Map(x => x.Nome);
        }
    }
}