using NHibernate;

namespace NHibernateLeak.Web.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRepository : IReadOnlyRepository
    {
        /// <summary>
        /// 
        /// </summary>
        IUnitOfWorkManager CurrentUnitOfWork { get; }

        /// <summary>
        /// 
        /// </summary>
        ISession Session { get; }
    }
}
