using NHibernate;

namespace NHibernateLeak.Web.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class SessionFactoryBuilder : ISessionFactoryBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        public ISessionFactory CreateSchemaSessionFactory(string schemaName)
        {
            return SqlNHibernateSessionFactoryProvider.CreateSessionFactory(schemaName, "ISPolitical.Connection");
        }
    }
}
