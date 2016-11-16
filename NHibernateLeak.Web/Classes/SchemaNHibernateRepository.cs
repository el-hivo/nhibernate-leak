using NHibernate;
using Ninject;

namespace NHibernateLeak.Web.Classes
{
    public class SchemaNHibernateRepository : Repository
    {
        public SchemaNHibernateRepository([Named("schema")]ISession session) : base(session)
        {
            UnitOfWorkManager = new SchemaNHibernateUnitOfWorkManager(Session);
        }
    }
}