using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace NHibernateLeak.Web.Classes
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
