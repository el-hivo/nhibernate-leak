using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace NHibernateLeak.Entities.Mappings
{
    public class Table001Map : IAutoMappingOverride<Table001>
    {
        public void Override(AutoMapping<Table001> mapping)
        {
            mapping.Table("Table001");
            mapping.Id(x => x.Id, "Id");
        }
    }
}
