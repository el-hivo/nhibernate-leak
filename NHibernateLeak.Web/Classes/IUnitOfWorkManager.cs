using System;

namespace NHibernateLeak.Web.Classes
{
    public interface IUnitOfWorkManager
    {
        void CommitEverything();
        IDisposable BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
