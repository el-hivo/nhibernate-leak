using System;

namespace NHibernateLeak.Web.Classes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CascadeAttribute : Attribute
    {
    }
}
