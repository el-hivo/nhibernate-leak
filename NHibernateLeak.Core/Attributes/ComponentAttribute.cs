using System;

namespace NHibernateLeak.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class ComponentAttribute : Attribute
    {
        public ComponentAttribute()
        { 
        
        }
    }
}
