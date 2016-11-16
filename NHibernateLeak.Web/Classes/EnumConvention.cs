using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace NHibernateLeak.Web.Classes
{
    /// <summary>
    /// This Fluent-NHibernate convention allos to map to ints both Enum and (nullable) Enum?
    /// </summary>
    public class EnumConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            // we accept both regular and nullable enums
			criteria.Expect(x => x.Property.PropertyType.IsEnum || (IsNullableType(x.Property.PropertyType) && Nullable.GetUnderlyingType(x.Property.PropertyType).IsEnum));
        }

        public void Apply(IPropertyInstance instance)
        {
            if (instance.Property.PropertyType.IsEnum)
            {
                // regular enums
                instance.CustomType(instance.Property.PropertyType);
            }
            else
            {
                //nullable enums
                instance.CustomType(Nullable.GetUnderlyingType(instance.Property.PropertyType));
            }
        }

		private bool IsNullableType(Type type)
		{
			return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
		}
    }
}
