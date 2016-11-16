using System;
using NHibernate;

namespace NHibernateLeak.Web.Classes
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        protected readonly ISession mSession;

        public UnitOfWorkManager(ISession session)
        {
            mSession = session;
        }

        public void CommitEverything()
        {
            mSession.Flush();
        }

        public IDisposable BeginTransaction()
        {
            return mSession.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (mSession.Transaction != null && mSession.Transaction.IsActive)
            {
                mSession.Transaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (mSession.Transaction != null && mSession.Transaction.IsActive)
            {
                mSession.Transaction.Rollback();
            }
        }
    }
}