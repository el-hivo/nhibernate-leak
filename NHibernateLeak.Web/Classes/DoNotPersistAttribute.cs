using System;

namespace NHibernateLeak.Web.Classes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class DoNotPersistAttribute : Attribute
    {
    }
}
