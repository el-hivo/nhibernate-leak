using System.Linq;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using NHibernateLeak.Core.Attributes;

namespace NHibernateLeak.Core.Conventions
{
    public class SubclassConvention : ISubclassConvention
    {
        public void Apply(ISubclassInstance instance)
        {
            var discriminatorValueAttribute = Enumerable.Single<object>(instance.EntityType.GetCustomAttributes(typeof(DiscriminatorValueAttribute), false)) as DiscriminatorValueAttribute;
            instance.DiscriminatorValue(discriminatorValueAttribute.DiscrimatorValue);
		}
    }
}
