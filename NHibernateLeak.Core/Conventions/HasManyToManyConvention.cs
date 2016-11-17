using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace NHibernateLeak.Core.Conventions
{
    // implementation taken from Fluent NHibernate class FluentNHibernate.Conventions.ManyToManyTableNameConvention
    public class HasManyToManyConvention : IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {
            if (instance.OtherSide == null)
            {
                // uni-directional
                var tableName = GetUniDirectionalTableName(instance);

                instance.Table(tableName);
            }
            else
            {
                // bi-directional
                if (instance.HasExplicitTable && instance.OtherSide.HasExplicitTable)
                {
                    // TODO: We could check if they're the same here and warn the user if they're not
                    return;
                }

                if (instance.HasExplicitTable && !instance.OtherSide.HasExplicitTable)
                {
                    instance.OtherSide.Table(instance.TableName);
                }
                else if (!instance.HasExplicitTable && instance.OtherSide.HasExplicitTable)
                {
                    instance.Table(instance.OtherSide.TableName);
                }
                else
                {
                    var tableName = GetBiDirectionalTableName(instance.OtherSide, instance);

                    instance.Table(tableName);
                    instance.OtherSide.Table(tableName);
                }

				//instance.Access.ReadOnlyProperty();
				instance.Cascade.DeleteOrphan();
				
				//instance.OtherSide.Access.ReadOnlyProperty();
				instance.OtherSide.Cascade.DeleteOrphan();
				
            }
        }

        protected string GetBiDirectionalTableName(IManyToManyCollectionInspector collection, IManyToManyCollectionInspector otherSide)
        {
         	return string.Format("QueryBuilder.QB{0}{1}s", collection.EntityType.Name, otherSide.EntityType.Name);
        }

        protected string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
			return string.Format("{0}_{1}", collection.EntityType.Name, collection.ChildType.Name);
        }

    }

}
