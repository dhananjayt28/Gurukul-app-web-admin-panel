using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GurukulAppAdminPanel.Models;
using GurukulAppAdminPanel.App_Start;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;



namespace GurukulAppAdminPanel.Controllers
{
    public class MasterManagementController : Controller
    {
        private Dictionary<string, object> errordata;
        private DataTable _dtable;
        private dynamic response;
        // GET: MasterManagement

        /***************************************
         * Title - View Master
         * Parameter -null
         * Return - Grid view
         * Syntax - null
         ***************************************/
        [HttpGet]
        public ActionResult ViewMaster()
        {
            ViewBag.Title = "Master" + Constant.PROJECT_NAME;
            return View();
        }
        /***************************************
        * Title - Add Category
        * Parameter -null
        * Return - Success Message
        * Syntax - null
        ***************************************/
        [HttpPost]
        public string AddCategory(MasterManagement categoryname)
        {
            string _jsonString = string.Empty;
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    //string _jsonString = string.Empty;
                    MasterManagement _MM = new MasterManagement();
                    List<object> postdata = new List<object>();
                    SortedList<string, object> _postArrData = new SortedList<string, object>();

                    _postArrData.Add("LOV_NAME", categoryname.ADDCATEGORY);
                    postdata.Add(_postArrData);
                    var _postContent = System.Web.Helpers.Json.Encode(postdata);

                    if (_postContent != null)
                    {
                        _dtable = _MM.Add_master_Data(_postContent);
                    }
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




                    //string val = _ACTM.SAVE_DATA_CATEGORY(categoryname.ADDCATEGORY);
                   
                    return _jsonString;
                }
                else
                {
                    errordata = new Dictionary<string, object>();
                    errordata.Add("status", false);
                    errordata.Add("response", ModelError(ModelState));
                    return Data.ObjectToJsonString(errordata);
                }
                // return Constant.UNAUTH_ACCESS;
            }
            else
            {
                return Constant.UNAUTH_ACCESS;
            }



        }

        /***************************************
        * Title - Add Sub Category
        * Parameter -null
        * Return - Success Message
        * Syntax - null
        ***************************************/
        [HttpPost]
        public string AddSubCategory(MasterManagement ob)
        {
            string _jsonString = string.Empty;
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    MasterManagement _MM = new MasterManagement();
                    //string _jsonString = string.Empty;
                   
                    List<object> postdata = new List<object>();
                    SortedList<string, object> _postArrData = new SortedList<string, object>();

                    _postArrData.Add("LOV_NAME", ob.ADDSUBCATEGORY);
                    _postArrData.Add("LOV_ID", ob.CATEGORYID);
                    postdata.Add(_postArrData);
                    var _postContent = System.Web.Helpers.Json.Encode(postdata);

                    if (_postContent != null)
                    {
                        _dtable = _MM.Add_sub_category(_postContent);
                    }
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
                else
                {
                    errordata = new Dictionary<string, object>();
                    errordata.Add("status", false);
                    errordata.Add("response", ModelError(ModelState));
                    return Data.ObjectToJsonString(errordata);
                }
                // return Constant.UNAUTH_ACCESS;
            }
            else
            {
                return Constant.UNAUTH_ACCESS;
            }



        }


        [HttpPost]
        public string GetMasterDataList()
        {
            string _jsonString = string.Empty;

            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_Parent_Master_List();


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);               
            }
            else
            {
                _jsonString = Data.DatatableEmpty();                
            }

            return _jsonString;
        }
       
        public string GetListDataList(string category_name)
        {
            string _jsonString = string.Empty;

            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_Master_List(category_name);


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);               
            }
            else
            {
                _jsonString = Data.DatatableEmpty();               
            }



            return _jsonString;
        }

        public List<string> ModelError(ModelStateDictionary ModelState)
        {
            List<string> modelErrors = new List<string>();
            try
            {
                if (ModelState != null)
                {
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var modelError in modelState.Errors)
                        {
                            modelErrors.Add(modelError.ErrorMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string ExMsg = "\n\n =================================================================== \n"
                             + "Title :: ProfileData method on Master Controller \nMessage :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
            }
            return modelErrors;
        }

    }
}