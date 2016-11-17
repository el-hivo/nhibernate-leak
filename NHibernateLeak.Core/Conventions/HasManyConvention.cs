using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using NHibernateLeak.Core.Attributes;

namespace NHibernateLeak.Core.Conventions
{
    public class HasManyConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Cascade.AllDeleteOrphan();
			instance.Inverse();

			if (instance.Member.IsDefined(typeof(NotLazyLoadAttribute), false))
			{
				instance.Not.LazyLoad();
			}
        }
    }
}
