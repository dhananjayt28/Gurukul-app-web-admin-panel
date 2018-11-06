using GurukulAppAdminPanel.App_Start;
using System;
using System.Web.Mvc;

namespace GurukulAppAdminPanel.Controllers
{
    [SessionExists]
    public abstract class MasterController : Controller
    {
        /*********************************************/
        private dynamic _sessData = System.Web.HttpContext.Current.Session;

        /*******************************
         * Title :: Constractor
         * Description :: it use for call a private function, if session clear
         *******************************/
        public MasterController() 
        {
            this._ProfileData();
        }

        /*******************************
         * Title :: admin profile data appear
         * Description :: it use for view admin profile data in project
         * Parameter :: none
         * Return :: redirect
         *******************************/
        private void _ProfileData()
        {
            try
            {
                ViewBag.Name = _sessData["NAME"];
                ViewBag.breadcrumbHome = "Home";
                ViewBag.breadcrumbHomeURL = Constant.DASHBOARD;
            }
            catch(Exception ex)
            {
                string ExMsg = "Title :: ProfileData method on Master Controller \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
            }
        }

        /*******************************
         * Title :: Redirect
         * Description :: it use for redirect to logout
         * Parameter :: none
         * Return :: redirect
         *******************************/
        public ActionResult _Goto()
        {
            return Redirect(Constant.LOGOUT);
            //return RedirectPermanent(Constant.LOGOUT);
        }
    }
}