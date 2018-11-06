using GurukulAppAdminPanel.App_Start;
using System.Web.Mvc;

namespace GurukulAppAdminPanel.Controllers
{
    public class HomeController : MasterController
    {
        
        /*******************************
         * Title :: Index
         * Description :: it use for call by default, when this controller action by user.
         * Parameter :: none
         * Return :: return to index view
         *******************************/
        public ActionResult Index()
        {
            
            ViewBag.Title = "Dashboard" + Constant.PROJECT_NAME;
            return View();
        }



        

    }
}