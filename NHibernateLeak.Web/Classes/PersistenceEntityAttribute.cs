using System;

namespace NHibernateLeak.Web.Classes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class PersistenceEntityAttribute : Attribute
    {
        public PersistenceEntityAttribute()
        {

        }
    }
}