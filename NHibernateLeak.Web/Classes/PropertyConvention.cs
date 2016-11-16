using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace NHibernateLeak.Web.Classes
{
	public class PropertyConvention : IPropertyConvention
	{
		
		public void Apply(IPropertyInstance instance)
		{
			if (instance.Property.MemberInfo.IsDefined(typeof(NotSaveUpdateAttribute), false))
			{
				instance.Not.Update();
				instance.Not.Insert();
			}
		}
	}
}

