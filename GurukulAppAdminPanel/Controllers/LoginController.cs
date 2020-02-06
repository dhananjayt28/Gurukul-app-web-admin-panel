using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GurukulAppAdminPanel.App_Start;
using GurukulAppAdminPanel.Models;
using System.Web.Script.Serialization;
using System.Collections;

namespace GurukulAppAdminPanel.Controllers
{
    public class LoginController : Controller
    {
        /***************************************
         * Title :: Login View
         * Description :: this module use for login view
         * Param ::
         * Return ::
         **************************************/
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Admin Login "+Constant.PROJECT_NAME;
            return View();
        }

        /***************************************
         * Title :: Login Action
         * Description :: this module use for login action with userid and password.
         * Param :: Model Data
         * Return ::
         **************************************/
        [HttpPost]
        public ActionResult Index(AuthenticateManagement login)
        {
             if (ModelState.IsValid)
            {//login is working with Admin_Login function of MasterManagement  
                var response = login.LoginAction(login);
                if (response != string.Empty)
                {
                    JavaScriptSerializer jsObj = new JavaScriptSerializer();
                    var data = jsObj.Deserialize<Dictionary<string, object>>(response);
                    //Dictionary<string, object> JSONObj = Data.Deserialize(response.Content.ToString(), typeof(Dictionary<string, object>));
                    bool status = Convert.ToBoolean(data["status"].ToString().ToLower().Trim() == "true");
                    if (status)
                    {
                        string name = string.Empty, email = string.Empty, mobile = string.Empty;
                        int UserId;
                        string Role_code = string.Empty ; 
                        ArrayList UserData = (ArrayList)data["response"];
                        Dictionary<string, object> user = (Dictionary<string, object>)UserData[0];
                        if(user.Count > 0)
                        {
                            UserId = Convert.ToInt32(user["USER_ID"]);
                           // UserId = Convert.ToInt32(user["USERID"]);
                            Role_code = Convert.ToString(user["SYSTEM_ROLE_CODE"]);
                            name = user["FIRST_NAME"].ToString();
                           // name = user["NAME"].ToString();



                            //email = user["EMAIL_ID"].ToString();
                            //mobile = user["MOBILE_NO"].ToString();

                            SortedList<string, object> _sessData = new SortedList<string, object>();
                            Session.Add("USER_ID", UserId);
                            Session.Add("SYSTEM_ROLE_CODE", Role_code);
                            Session.Add("FIRST_NAME", name);
                          //  Session.Add("EMAIL", email);
                            //Session.Add("MOBILE", mobile);
                            //Session.Add("SessData",_sessData);
                            if(Session.Count > 0 && Role_code=="BADM")
                            {
                                string DashboardURL = Constant.DASHBOARD;
                                return Redirect(DashboardURL);
                            }
                        }                        
                    }
                    else
                    {
                        TempData["MSG_LOGIN"] = "Wrong UserName or Password";
                        return View("Index", new AuthenticateManagement());
                    }
                }
            }
            ViewBag.Title = "Admin Login " + Constant.PROJECT_NAME;
            return View("Index", new AuthenticateManagement());
        }

        /***************************************
         * Title :: Logout Action
         * Description :: this module use for login view
         * Param ::
         * Return ::
         **************************************/
        [HttpGet]
        public ActionResult Logout()
        {
            string LoginUrl = Constant.BASEURL;
            if (Session.Count > 0)
            {
                Session.RemoveAll();
            }
            return Redirect(LoginUrl);
        }
    }
}