using System;
using System.Configuration;
using NHibernate;
using NHibernateLeak.Web.Classes;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace NHibernateLeak.Web.Ninject
{
    public class NHibernateNinjectModule : NinjectModule
    {
        public override void Load()
        {
            ConnectionStringSettings conn = ConfigurationManager.ConnectionStrings["MemoryLeak.Connection"];

            if (conn == null)
            {
                throw new Exception("The Memory Connection was not configured.");
            }

            Bind<ISessionFactoryBuilder>().To<SessionFactoryBuilder>().InSingletonScope();

            Bind<ISession>().ToMethod(ctx =>
            {
                // ReSharper disable once ConvertToLambdaExpression
                return ctx.Kernel.Get<ISessionFactoryBuilder>().CreateSchemaSessionFactory().OpenSession();
            }).InRequestScope().Named("schema");

            Bind<IUnitOfWorkManager>().To<SchemaNHibernateUnitOfWorkManager>().InRequestScope().Named("schema");
            Bind<IRepository>().To<SchemaNHibernateRepository>().Named("schema");

            Bind<IQueryRepository>().To<QueryRepository>();
        }
    }
}