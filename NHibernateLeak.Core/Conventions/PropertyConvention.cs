using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using NHibernateLeak.Core.Attributes;

namespace NHibernateLeak.Core.Conventions
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

