using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace NHibernateLeak.Entities.Mappings
{
    public class Table003Map : IAutoMappingOverride<Table003>
    {
        public void Override(AutoMapping<Table003> mapping)
        {
            mapping.Table("Table003");
            mapping.Id(x => x.Id, "Id");
        }
    }
}