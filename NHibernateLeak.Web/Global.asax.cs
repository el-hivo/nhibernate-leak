using System.Web.Mvc;
using System.Web.Routing;
using NHibernateLeak.Web.Ninject;
using Ninject;
using Ninject.Web.Common;

namespace NHibernateLeak.Web
{
    public class NHibernateLeakWebApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new NHibernateNinjectModule());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            // ignore aspx added by DLT 
            routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{tenant}/{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            RegisterRoutes(RouteTable.Routes);
            //GlobalFilters.Filters.Add(new TenantFilter());
        }
    }
}