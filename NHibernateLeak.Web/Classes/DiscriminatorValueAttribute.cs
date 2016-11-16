using System;

namespace NHibernateLeak.Web.Classes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class DiscriminatorValueAttribute : Attribute
    {
        public int DiscrimatorValue { get; set; }

        public DiscriminatorValueAttribute(int discriminatorValue)
        {
            DiscrimatorValue = discriminatorValue;
        }
    }    
}
