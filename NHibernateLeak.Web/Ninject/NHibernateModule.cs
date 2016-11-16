using System;
using System.Configuration;
using System.Linq;
using NHibernate;
using NHibernateLeak.Web.Classes;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using Ninject.Web.Common;

namespace NHibernateLeak.Web.Ninject
{
    public class NHibernateNinjectModule : NinjectModule
    {
        public override void Load()
        {
            ConnectionStringSettings conn = ConfigurationManager.ConnectionStrings["PDI.Connection1"];

            if (conn == null)
            {
                throw new Exception("The PDI Connection was not configured.");
            }

            Bind<ISessionFactoryBuilder>().To<SessionFactoryBuilder>().InSingletonScope();

            Bind<ISession>().ToMethod(ctx =>
            {
                IParameter parameter = ctx.Parameters.SingleOrDefault(prm => prm.Name == "schemaName");
                string prmValue = parameter?.GetValue(ctx, ctx.Request.Target) as string;
                return ctx.Kernel.Get<ISessionFactoryBuilder>().CreateSchemaSessionFactory(prmValue).OpenSession();
            }).InRequestScope().Named("schema");

            Bind<IUnitOfWorkManager>().To<SchemaNHibernateUnitOfWorkManager>().InRequestScope().Named("schema");
            Bind<IRepository>().To<SchemaNHibernateRepository>().Named("schema");
        }
    }
}