using System;
using System.Web.Mvc;
using NHibernateLeak.Web.Classes;

namespace NHibernateLeak.Web.Controllers
{
    public class QueryController : Controller
    {
        private readonly IQueryRepository _queryRepo;
        private readonly ISessionFactoryBuilder _factory;

        public QueryController(IQueryRepository queryRepository, ISessionFactoryBuilder factory)
        {
            _queryRepo = queryRepository;
            _factory = factory;
        }

        [HttpPost]
        public ActionResult Collect(string tenant)
        {
            _factory.ClearAll();
            GC.Collect();
            return Json(new { id = 1, text = "hello" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Get(string tenant)
        {
            _queryRepo.GetTable001ByParameters(GetRandomFilterParameters());

            _queryRepo.GetTable002ByParameters(GetRandomFilterParameters());

            _queryRepo.GetTable003ByParameters(GetRandomFilterParameters());

            _queryRepo.GetTable004ByParameters(GetRandomFilterParameters());

            return Json(new {id = 1, text = "hello"}, JsonRequestBehavior.AllowGet);
        }

        private FilterParameters GetRandomFilterParameters()
        {
            Random rnd = new Random();

            FilterParameters filters = new FilterParameters
            {
                Column001 = rnd.Next(0, 2) == 0 ? string.Empty : GetRandomString(1),
                Column002 = rnd.Next(0, 2) == 0 ? string.Empty : GetRandomString(2),
                Column003 = rnd.Next(0, 2) == 0 ? string.Empty : GetRandomString(3),
                Column004 = rnd.Next(0, 2) == 0 ? string.Empty : GetRandomString(4),
                Column005 = rnd.Next(0, 2) == 0 ? string.Empty : GetRandomString(5),
                Column006 = rnd.Next(0, 2) == 0 ? string.Empty : GetRandomString(6),
                Column007 = rnd.Next(0, 2) == 0 ? string.Empty : GetRandomString(7),
                Column008 = rnd.Next(0, 2) == 0 ? string.Empty : GetRandomString(8),
                Column009 = rnd.Next(0, 2) == 0 ? string.Empty : GetRandomString(9),
                Column010 = rnd.Next(0, 2) == 0 ? string.Empty : GetRandomString(10)
            };

            return filters;
        }

        private string GetRandomString(int seed)
        {
            Random rnd = new Random(seed);

            return rnd.Next(3000, 329480).ToString();
        }
    }
}