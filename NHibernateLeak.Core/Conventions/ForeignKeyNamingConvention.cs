using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace NHibernateLeak.Core.Conventions
{
    public class ForeignKeyNamingConvention : ForeignKeyConvention
    {
		protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
                return string.Format("{0}ID", type.Name);

            return string.Format((string) "{0}ID", (object) property.Name);
        }

    }
}
