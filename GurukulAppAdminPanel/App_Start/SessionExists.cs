using System.Web;
using System.Web.Mvc;

namespace GurukulAppAdminPanel.App_Start
{
    public class SessionExists : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if(HttpContext.Current.Session.Count > 0)
            {
                if (HttpContext.Current.Session["USER_ID"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Login/Logout");
                    return;
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Login/Logout");
                return;
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}