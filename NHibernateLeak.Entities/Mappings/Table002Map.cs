using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace NHibernateLeak.Entities.Mappings
{
    public class Table002Map : IAutoMappingOverride<Table002>
    {
        public void Override(AutoMapping<Table002> mapping)
        {
            mapping.Table("Table002");
            mapping.Id(x => x.Id, "Id");
        }
    }
}