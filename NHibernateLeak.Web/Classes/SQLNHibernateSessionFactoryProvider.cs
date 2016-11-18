using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernateLeak.Core;
using NHibernateLeak.Entities;

namespace NHibernateLeak.Web.Classes
{
    public static class SqlNHibernateSessionFactoryProvider
    {
        private static readonly Dictionary<string, ISessionFactory> SessionFactories = new Dictionary<string, ISessionFactory>();
        private static readonly object Mutex = new object();

        public static ISessionFactory CreateSessionFactory(string schema, string keyConnection)
        {
            if (ConfigurationManager.ConnectionStrings[keyConnection] == null)
            {
                throw new Exception("The Connection was not configured.");
            }

            ISessionFactory factory;

            lock (Mutex)
            {
                if (!SessionFactories.ContainsKey(schema))
                {
                    IList<Assembly> assembliesToMap = new List<Assembly>();
                    assembliesToMap.Add(Assembly.GetAssembly(typeof(Table001)));
                    factory = CreateInstance(assembliesToMap, typeof(Table001), Assembly.GetAssembly(typeof(Table001)), schema, keyConnection);
                    SessionFactories.Add(schema, factory);
                }
                else
                {
                    factory = SessionFactories[schema];
                }
            }

            return factory;
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
                                   .UseOverridesFromAssembly(overrideClass)
                        );
                    })
                    .Mappings(m => m.HbmMappings.AddFromAssembly(overrideClass))
                    .ExposeConfiguration(c => c.SetProperty("command_timeout", "1200"))
                    .BuildSessionFactory();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ClearAllSessionFactories()
        {
            lock (Mutex)
            {
                string[] keys = SessionFactories.Keys.ToArray();

                foreach (string key in keys)
                {
                    SessionFactories[key].Dispose();
                    SessionFactories[key] = null;
                    SessionFactories.Remove(key);
                }

                SessionFactories.Clear();
            }
        }
    }
}