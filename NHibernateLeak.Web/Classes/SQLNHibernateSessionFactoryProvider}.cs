using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernateLeak.Entities;

namespace NHibernateLeak.Web.Classes
{
    public static class SqlNHibernateSessionFactoryProvider
    {
        private static Dictionary<string, ISessionFactory> _sessionFactories = new Dictionary<string, ISessionFactory>();

        public static ISessionFactory CreateSessionFactory(string schema = "", string keyConnection = "MSSQL.Connection")
        {
            IList<Assembly> assembliesToMap = new List<Assembly>();
            assembliesToMap.Add(Assembly.GetAssembly(typeof(Table001)));

            if (ConfigurationManager.ConnectionStrings[keyConnection] == null)
            {
                throw new Exception("The Connection was not configured.");
            }

            lock (_sessionFactories)
            {
                if (!_sessionFactories.ContainsKey(schema))
                {
                    var factory = CreateInstance(assembliesToMap, typeof(Table001),
                                                 Assembly.GetAssembly(typeof(Table001)), schema, keyConnection);
                    _sessionFactories.Add(schema, factory);
                }
            }

            return _sessionFactories[schema];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory CreateInstance(IList<Assembly> assembliesToMap, Type baseClass, Assembly overrideClass, string schema, string keyConnection)
        {
            return
               Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationManager.ConnectionStrings[keyConnection].ConnectionString).DefaultSchema(schema))
                .Mappings(m =>
                {
                    m.AutoMappings.Add(
                        AutoMap.Assemblies(new AutomappingConfiguration(), assembliesToMap)
                            .IncludeBase(baseClass)
                            .Conventions.Add<TableNamingConvention>()
                            .Conventions.Add<HasManyConvention>()
                            .Conventions.Add<SQLPrimaryKeyConvention>()
                            .Conventions.Add<EnumConvention>()
                            .Conventions.Add<ForeignKeyNamingConvention>()
                            .Conventions.Add<SubclassConvention>()
                            .Conventions.Add<ReferenceConvention>()
                            .Conventions.Add<HasManyToManyConvention>()
                            .Conventions.Add<JoinedSubclassConvention>()
                            .Conventions.Add<PropertyConvention>()
                            .UseOverridesFromAssembly(overrideClass)
                    );
                })
                .Mappings(m => m.HbmMappings.AddFromAssembly(overrideClass))
                .ExposeConfiguration(c => c.SetProperty("command_timeout", "1200"))
                .BuildSessionFactory();
        }

        public static void CloseSession(ISession session)
        {
            if (session != null)
            {
                if (session.IsOpen)
                {
                    session.Close();
                }
                session.Dispose();
            }
        }
    }
}