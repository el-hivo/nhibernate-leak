using System.Web;
using System.Web.Routing;
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
        /// <returns></returns>
        public ISessionFactory CreateSchemaSessionFactory()
        {
            HttpContextWrapper context = new HttpContextWrapper(HttpContext.Current);
            RouteData data = RouteTable.Routes.GetRouteData(context);

            string tenant = data?.Values["tenant"] as string;

            return SqlNHibernateSessionFactoryProvider.CreateSessionFactory("sch" + tenant?.PadLeft(3, '0'), "MemoryLeak.Connection");
        }
    }
}
