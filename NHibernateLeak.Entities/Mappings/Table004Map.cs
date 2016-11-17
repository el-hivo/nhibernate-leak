using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace NHibernateLeak.Entities.Mappings
{
    public class Table004Map : IAutoMappingOverride<Table004>
    {
        public void Override(AutoMapping<Table004> mapping)
        {
            mapping.Table("Table004");
            mapping.Id(x => x.Id, "Id");
        }
    }
}