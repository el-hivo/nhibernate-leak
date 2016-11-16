using System;
using System.Linq;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace NHibernateLeak.Web.Classes
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.IsDefined(typeof(PersistenceEntityAttribute), true) && !type.IsDefined(typeof(DoNotPersistAttribute), false);
        }

        public override bool IsId(Member member)
        {
            return member.Name == member.DeclaringType.Name + "ID";
        }

        public override bool ShouldMap(Member member)
        {
            return base.ShouldMap(member) && !member.MemberInfo.IsDefined(typeof(DoNotPersistAttribute), true);
        }

        public override bool IsComponent(Type type)
        {
            return type.GetCustomAttributes(typeof(ComponentAttribute), true).Length > 0;
        }

        public override string GetDiscriminatorColumn(Type type)
        {
            var discriminatedAttribute = type.GetCustomAttributes(typeof(DiscriminatorColumnAttribute), false).Single() as DiscriminatorColumnAttribute;
            return discriminatedAttribute?.DiscriminatorColumn;
        }
    }
}