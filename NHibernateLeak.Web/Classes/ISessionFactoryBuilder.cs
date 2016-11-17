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
        /// <returns></returns>
        ISessionFactory CreateSchemaSessionFactory();
    }
}
