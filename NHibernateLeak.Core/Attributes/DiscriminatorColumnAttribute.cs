using System;

namespace NHibernateLeak.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class DiscriminatorColumnAttribute : Attribute
    {
        public string DiscriminatorColumn { get; set; }

        public DiscriminatorColumnAttribute(string discriminatorColumn)
        {
            DiscriminatorColumn = discriminatorColumn;
        }
    }
}
