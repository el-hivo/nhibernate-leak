using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace NHibernateLeak.Web.Classes
{
    public class Repository : IRepository
    {
        protected IUnitOfWorkManager UnitOfWorkManager;
        public ISession Session { get; set; }

        public Repository(ISession session)
        {
            Session = session;
        }

        public IUnitOfWorkManager CurrentUnitOfWork => UnitOfWorkManager;

        public IQueryable<T> GetAll<T>() where T : class
        {
            return Session.Query<T>();
        }

        public T GetById<T>(long id) where T : class
        {
            throw new NotImplementedException();
        }

        public object GetById(long id, Type entityType)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public object GetById(int id, Type entityType)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAllLite<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public DataTable GetSchema(string collectionName, string[] restrictions)
        {
            throw new NotImplementedException();
        }
    }
}