using NHibernate;

namespace NHibernateLeak.Web.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISessionFactoryBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        ISessionFactory CreateSchemaSessionFactory(string schemaName);
    }
}
