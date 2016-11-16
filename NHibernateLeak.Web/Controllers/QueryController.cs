using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHibernateLeak.Web.Controllers
{
    public class QueryController : Controller
    {

        [HttpGet]
        public ActionResult Get()
        {
            return Json(new {id = 1, text = "hello"}, JsonRequestBehavior.AllowGet);
        }
    }
}