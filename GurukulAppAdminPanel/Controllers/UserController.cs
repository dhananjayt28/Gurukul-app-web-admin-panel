using GurukulAppAdminPanel.App_Start;
using GurukulAppAdminPanel.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace GurukulAppAdminPanel.Controllers
{
    public class UserController : MasterController
    {
        private DataTable _dtable;
        private Dictionary<string, object> errordata, dictionaryObj;
        /*******************************
         * Title :: Index
         * Description :: it use for call by default, when this controller action by user.
         * Parameter :: none
         * Return :: return to index view
         *******************************/
        public ActionResult Index()
        {
            return View();
        }
        /*******************************
         * Title :: UserList
         * Description :: it use for call according to route, when this controller action by user.
         * Parameter :: none
         * Return :: return to index view
         *******************************/
        public ActionResult UserList(string ustatus="")
        {
            try
            {
                ViewBag.Title = "Volunteer's List" + Constant.PROJECT_NAME;
                ViewBag.breadcrumbController = "User";
                ViewBag.breadcrumbAction = "Users List";
                UserManagement _umObj = new UserManagement();
                MasterManagement _mmObj = new MasterManagement();
                string response = string.Empty;
                if (ustatus == ""|| ustatus == "Select")
                {
                    //response = _umObj.CollectUserData();
                    response = _umObj.CollectUserDataOnLoad(null, "Waiting For Approval", null);
                }
                //else if (ustatus == "Select")
                //{
                //    return View();
                //}
                else
                {
                    response = _umObj.CollectUserDataOnLoad(null, ustatus, null);
                }
                if (response != string.Empty)
                {
                    JavaScriptSerializer jsObj = new JavaScriptSerializer();
                    var data = jsObj.Deserialize<Dictionary<string, object>>(response);
                    dictionaryObj = new Dictionary<string, object>();
                    dictionaryObj = Data.Deserialize(response, typeof(Dictionary<string, object>));
                    bool status = Convert.ToBoolean(data["status"]);
                    if (status)
                    {
                        if (dictionaryObj.ContainsKey("response"))
                        {
                            _umObj.UserData = (ArrayList)data["response"];
                        }
                    }                  
                    
                    else
                    {


                    }

                   
                }
                return View(_umObj);
            }
            catch(Exception ex)
            {
                int a = ex.Data.Count;
                return View();
            }
            
        }
        /*******************************
         * Title :: UserApprove
         * Description :: it use for call according to route, when this controller action by user.
         * Parameter :: user id
         * Return :: redirect to userlist
         *******************************/
        public ActionResult UserApprove(int userid = 0)
        {
            try
            {
                UserManagement _umObj = new UserManagement();
                string _response = _umObj.UserApproveAction(userid);
                if (_response != string.Empty)
                {
                    JavaScriptSerializer jsObj = new JavaScriptSerializer();
                    var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                    bool status = Convert.ToBoolean(data["status"]);
                    if (status)
                    {
                        //_umObj.UserData = (ArrayList)data["response"];
                        return RedirectToAction("", "user/user-list");
                    }
                }
            }
            catch(Exception ex)
            {
                int exception = ex.Data.Count;
            }
            return View();
        }
        /*******************************
         * Title :: UserReject
         * Description :: it use for call according to route, when this controller action by user.
         * Parameter :: user id
         * Return :: redirect to userlist
         *******************************/
        public ActionResult UserReject(int userid = 0)
        {
            try
            {
                UserManagement _umObj = new UserManagement();
                string _response = _umObj.UserRejectAction(userid);
                if (_response != string.Empty)
                {
                    JavaScriptSerializer jsObj = new JavaScriptSerializer();
                    var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                    bool status = Convert.ToBoolean(data["status"]);
                    if (status)
                    {
                        //_umObj.UserData = (ArrayList)data["response"];
                        return RedirectToAction("", "user/user-list");
                    }
                    else
                    {
                        string msg = data["response"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                int exception = ex.Data.Count;
            }
            return View();
        }
        /*******************************
         * Title :: UserReject
         * Description :: it use for call according to route, when this controller action by user.
         * Parameter :: user id
         * Return :: redirect to userlist
         *******************************/
        public ActionResult UserDelete(int userid = 0)
        {
            try
            {
                UserManagement _umObj = new UserManagement();
                string _response = _umObj.UserDeleteAction(userid);
                //string _response = "";
                if (_response != string.Empty)
                {
                    JavaScriptSerializer jsObj = new JavaScriptSerializer();
                    var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                    bool status = Convert.ToBoolean(data["status"]);
                    if (status)
                    {
                        //_umObj.UserData = (ArrayList)data["response"];
                        return RedirectToAction("", "user/user-list");
                    }
                    else
                    {
                        string msg = data["response"].ToString();
                        return RedirectToAction("", "user/user-list");
                    }
                }
            }
            catch (Exception ex)
            {
                int exception = ex.Data.Count;
            }
            return RedirectToAction("", "user/user-list");
        }
        /*******************
         * Name - QrCodeGenerator
         * param- user_id,email
         * Return -
         * Author - Sayan Chatterjee
         * ************************/
        public ActionResult UserReset(string userid)
        {
            string _response = string.Empty;
            try
            {
                UserManagement _umObj = new UserManagement();
                 MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.View_User_Data(userid, null, null);


                if (_dtable.Rows.Count > 0)
                {
                    _response = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    //response = this.Request.CreateResponse(HttpStatusCode.OK);
                }



                // _response = GetUserProfileData(userid);
                //string _response = "";
                if (_response != string.Empty)
                {
                    JavaScriptSerializer jsObj = new JavaScriptSerializer();
                    var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                    bool status = Convert.ToBoolean(data["status"]);                   
                    ArrayList UserData = (ArrayList)data["response"];
                    Dictionary<string, object> user = (Dictionary<string, object>)UserData[0];
                    string email_id = Convert.ToString(user["EMAIL_ID"]);
                    string qrstring = Constant.QR_CODE;
                  
                   
                    List<object> postdata = new List<object>();
                    SortedList<string, object> _postArrData = new SortedList<string, object>();

                    _postArrData.Add("USER_ID", userid);
                    _postArrData.Add("EMAIL_ID", email_id);
                     postdata.Add(_postArrData);
                    var _postContent = System.Web.Helpers.Json.Encode(postdata);
                    string json = _postContent.ToString();
                    json = json.Replace("[", "");
                    json = json.Replace("]", "");
                    qrstring = qrstring + json;
                    TempData["QRCODE"] = qrstring;
                    //return File(qrstring, "application/unknown", "QrCode.png");
                    return Redirect(qrstring);
                }
                else
                {
                    return RedirectToAction("", "user/user-list");
                }
            }
            catch (Exception ex)
            {
                int exception = ex.Data.Count;
                return RedirectToAction("", "user/user-list");
            }
           // return RedirectToAction("", "user/user-list");
        }
        /*******************************
         * Title :: User Profile Data
         * Description :: it use for call according to route, when this controller action by user.
         * Parameter :: user id
         * Return :: redirect to userlist
         *******************************/
        public string GetUserProfileData(string userid)
        {
            string _jsonString = string.Empty;
            if (Request.IsAjaxRequest())
            {
                UserManagement _umObj = new UserManagement();
                //string _response = _umObj.UserProfileDataByUserId(userid);
                
                //if (_response != string.Empty)
                // {
                // return _response;
                // }
                //    else
                //    {
                //        return "Opps..!!! Something went wrong.";
                //    }
                //}
                //else
                //{
                //    return "Access denied...!!!";
                //}
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.View_User_Data(userid, null, null);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    //response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    //response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            return _jsonString;

            }
        public string GetStatus()
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_Master_List("USER_ACCOUNT_STATUS");


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                //response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                _jsonString = Data.DatatableEmpty();
                //response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            return _jsonString;
        }
        public string GetEventStatus()
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_Master_List("MASTER_STATUS");


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                //response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                _jsonString = Data.DatatableEmpty();
                //response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            return _jsonString;
        }

        public string UpdateBusinessProfile(UpdateBusinessProfile ob)
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            //var data = request.Content.ReadAsStringAsync().Result;
            //string Jsondata = data.ToString();
            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();

            _postArrData.Add("ROLE_ID", ob.bp_dd);
            _postArrData.Add("USER_ID", ob.hide_user_id);
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);
            _dtable = new DataTable();
            _MM = new MasterManagement();
            //int status = 0;
            //JavaScriptSerializer JsonArray = new JavaScriptSerializer();
            //Dictionary<string, object> _data = (Dictionary<string, object>)JsonArray.Deserialize(data, typeof(Dictionary<string, object>));
           
                _dtable = _MM.Update_user_profile(_postContent);
            
            if (_dtable.Rows.Count > 0)
            {
                _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                //response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                _jsonString = Data.DatatableEmpty();
                //response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            return _jsonString;

        }

        public ActionResult UserStatusUpdate(int userid = 0,int status=0)
        { string _jsonString = string.Empty;
                MasterManagement _MM = new MasterManagement();
                _dtable = new DataTable();
                _MM = new MasterManagement();
            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();
            _postArrData.Add("USER_ID", userid);
            _postArrData.Add("ACTION", "ACTIVATE");
            //_postArrData.Add("Status", status);
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);
            _dtable = _MM.Update_user_status(_postContent);
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                   // response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                   // response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                        //_umObj.UserData = (ArrayList)data["response"];
                        return RedirectToAction("", "user/user-list");
                    
                
            
        }

        //single record
        public string GetUserIndividualProfileData(string userid)
        {
            string _jsonString = string.Empty;
            if (Request.IsAjaxRequest())
            {
                UserManagement _umObj = new UserManagement();
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.View_User_individual_Data(userid, null, null);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    //response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    //response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            return _jsonString;

        }

    }
}