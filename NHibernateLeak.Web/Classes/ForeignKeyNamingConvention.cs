using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace NHibernateLeak.Web.Classes
{
    public class ForeignKeyNamingConvention : ForeignKeyConvention
    {
		protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
                return string.Format("{0}ID", type.Name);

            return string.Format("{0}ID", property.Name);
        }

    }
}
