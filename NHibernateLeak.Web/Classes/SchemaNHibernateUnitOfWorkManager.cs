using NHibernate;
using Ninject;

namespace NHibernateLeak.Web.Classes
{
    public class SchemaNHibernateUnitOfWorkManager : UnitOfWorkManager
    {
        public SchemaNHibernateUnitOfWorkManager([Named("schema")]ISession session) : base(session)
        {
        }
    }
}