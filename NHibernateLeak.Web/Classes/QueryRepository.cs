using System.Collections.Generic;
using System.Linq;
using NHibernateLeak.Entities;
using Ninject;

namespace NHibernateLeak.Web.Classes
{
    public class QueryRepository : IQueryRepository
    {
        private readonly IRepository _repository;

        public QueryRepository([Named("schema")] IRepository repository)
        {
            _repository = repository;
        }

        public IList<Table001> GetTable001ByParameters(FilterParameters filters)
        {
            var query = _repository.GetAll<Table001>();

            if (!string.IsNullOrWhiteSpace(filters.Column001))
            {
                query = query.Where(q => q.Column_001 == filters.Column001);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column002))
            {
                query = query.Where(q => q.Column_002 == filters.Column002);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column003))
            {
                query = query.Where(q => q.Column_003 == filters.Column003);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column004))
            {
                query = query.Where(q => q.Column_004 == filters.Column004);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column005))
            {
                query = query.Where(q => q.Column_005 == filters.Column005);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column006))
            {
                query = query.Where(q => q.Column_006 == filters.Column006);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column007))
            {
                query = query.Where(q => q.Column_007 == filters.Column007);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column008))
            {
                query = query.Where(q => q.Column_008 == filters.Column008);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column009))
            {
                query = query.Where(q => q.Column_009 == filters.Column009);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column010))
            {
                query = query.Where(q => q.Column_010 == filters.Column010);
            }

            return query.ToList();
        }

        public IList<Table002> GetTable002ByParameters(FilterParameters filters)
        {
            var query = _repository.GetAll<Table002>();

            if (!string.IsNullOrWhiteSpace(filters.Column001))
            {
                query = query.Where(q => q.Column_001 == filters.Column001);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column002))
            {
                query = query.Where(q => q.Column_002 == filters.Column002);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column003))
            {
                query = query.Where(q => q.Column_003 == filters.Column003);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column004))
            {
                query = query.Where(q => q.Column_004 == filters.Column004);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column005))
            {
                query = query.Where(q => q.Column_005 == filters.Column005);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column006))
            {
                query = query.Where(q => q.Column_006 == filters.Column006);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column007))
            {
                query = query.Where(q => q.Column_007 == filters.Column007);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column008))
            {
                query = query.Where(q => q.Column_008 == filters.Column008);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column009))
            {
                query = query.Where(q => q.Column_009 == filters.Column009);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column010))
            {
                query = query.Where(q => q.Column_010 == filters.Column010);
            }

            return query.ToList();
        }

        public IList<Table003> GetTable003ByParameters(FilterParameters filters)
        {
            var query = _repository.GetAll<Table003>();

            if (!string.IsNullOrWhiteSpace(filters.Column001))
            {
                query = query.Where(q => q.Column_001 == filters.Column001);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column002))
            {
                query = query.Where(q => q.Column_002 == filters.Column002);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column003))
            {
                query = query.Where(q => q.Column_003 == filters.Column003);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column004))
            {
                query = query.Where(q => q.Column_004 == filters.Column004);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column005))
            {
                query = query.Where(q => q.Column_005 == filters.Column005);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column006))
            {
                query = query.Where(q => q.Column_006 == filters.Column006);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column007))
            {
                query = query.Where(q => q.Column_007 == filters.Column007);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column008))
            {
                query = query.Where(q => q.Column_008 == filters.Column008);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column009))
            {
                query = query.Where(q => q.Column_009 == filters.Column009);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column010))
            {
                query = query.Where(q => q.Column_010 == filters.Column010);
            }

            return query.ToList();
        }

        public IList<Table004> GetTable004ByParameters(FilterParameters filters)
        {
            var query = _repository.GetAll<Table004>();

            if (!string.IsNullOrWhiteSpace(filters.Column001))
            {
                query = query.Where(q => q.Column_001 == filters.Column001);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column002))
            {
                query = query.Where(q => q.Column_002 == filters.Column002);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column003))
            {
                query = query.Where(q => q.Column_003 == filters.Column003);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column004))
            {
                query = query.Where(q => q.Column_004 == filters.Column004);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column005))
            {
                query = query.Where(q => q.Column_005 == filters.Column005);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column006))
            {
                query = query.Where(q => q.Column_006 == filters.Column006);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column007))
            {
                query = query.Where(q => q.Column_007 == filters.Column007);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column008))
            {
                query = query.Where(q => q.Column_008 == filters.Column008);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column009))
            {
                query = query.Where(q => q.Column_009 == filters.Column009);
            }

            if (!string.IsNullOrWhiteSpace(filters.Column010))
            {
                query = query.Where(q => q.Column_010 == filters.Column010);
            }

            return query.ToList();
        }
    }
}