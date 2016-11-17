using System.Web.Mvc;

namespace NHibernateLeak.Web
{
    public class TenantFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            int x = 0;
            x++;
        }
    }
}