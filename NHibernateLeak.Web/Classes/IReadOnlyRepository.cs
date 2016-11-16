using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NHibernateLeak.Web.Classes
{
    public interface IReadOnlyRepository
    {
        IQueryable<T> GetAll<T>() where T : class;

        T GetById<T>(long id) where T : class;

        object GetById(long id, Type entityType);

        T GetById<T>(int id) where T : class;

        object GetById(int id, Type entityType);

        IList<T> GetAllLite<T>() where T : class;

        DataTable GetSchema(string collectionName, string[] restrictions);
    }
}