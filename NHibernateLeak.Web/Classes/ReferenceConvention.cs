using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;

namespace NHibernateLeak.Web.Classes
{
    public class ReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            if (instance.Property.MemberInfo.IsDefined(typeof(CascadeAttribute), false))
            {
                //instance.Cascade.All();
				instance.Cascade.SaveUpdate(); 
            }

			if (instance.Property.MemberInfo.IsDefined(typeof(NotLazyLoadAttribute), false))
            {
                instance.LazyLoad(Laziness.False); 
            }

			if (instance.Property.MemberInfo.IsDefined(typeof(NotSaveUpdateAttribute), false))
			{
				instance.Not.Update();
				instance.Not.Insert();
			}

        }
    }
}
