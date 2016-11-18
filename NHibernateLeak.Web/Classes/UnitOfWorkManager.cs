using System;
using NHibernate;

namespace NHibernateLeak.Web.Classes
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        protected readonly ISession _session;

        public UnitOfWorkManager(ISession session)
        {
            _session = session;
        }

        public void CommitEverything()
        {
            _session.Flush();
        }

        public IDisposable BeginTransaction()
        {
            return _session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_session.Transaction != null && _session.Transaction.IsActive)
            {
                _session.Transaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (_session.Transaction != null && _session.Transaction.IsActive)
            {
                _session.Transaction.Rollback();
            }
        }
    }
}