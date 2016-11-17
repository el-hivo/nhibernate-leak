using System;

namespace NHibernateLeak.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotSaveUpdateAttribute : Attribute
    {
    }
}
