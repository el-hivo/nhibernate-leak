using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace NHibernateLeak.Core.Conventions
{
	public class JoinedSubclassConvention : IJoinedSubclassConvention
	{
		public void Apply(IJoinedSubclassInstance instance)
		{

			string tableName = "QueryBuilder.QB" + instance.EntityType.Name + "s";

			if (instance.EntityType.Name.EndsWith("y"))
			{
				tableName = "QueryBuilder.QB" + instance.EntityType.Name.Remove(instance.EntityType.Name.Length - 1) + "ies";
			}
			if (instance.EntityType.Name == "QueryCriterion")
			{
				tableName = "QueryBuilder.QBQueryCriteria";
			}

			instance.Table(tableName);
			instance.Key.Column(instance.EntityType.Name + "ID");
		}
	}
}
