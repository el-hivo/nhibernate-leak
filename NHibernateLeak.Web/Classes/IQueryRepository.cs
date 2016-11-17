using System.Collections.Generic;
using NHibernateLeak.Entities;

namespace NHibernateLeak.Web.Classes
{
    public interface IQueryRepository
    {
        IList<Table001> GetTable001ByParameters(FilterParameters filters);

        IList<Table002> GetTable002ByParameters(FilterParameters filters);

        IList<Table003> GetTable003ByParameters(FilterParameters filters);

        IList<Table004> GetTable004ByParameters(FilterParameters filters);
    }
}
