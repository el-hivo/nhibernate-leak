using System.Linq;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace NHibernateLeak.Web.Classes
{
    public class SubclassConvention : ISubclassConvention
    {
        public void Apply(ISubclassInstance instance)
        {
            var discriminatorValueAttribute = instance.EntityType.GetCustomAttributes(typeof(DiscriminatorValueAttribute), false).Single() as DiscriminatorValueAttribute;
            instance.DiscriminatorValue(discriminatorValueAttribute.DiscrimatorValue);
		}
    }
}
