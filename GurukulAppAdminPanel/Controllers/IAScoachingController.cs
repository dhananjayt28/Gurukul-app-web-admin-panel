using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GurukulAppAdminPanel.Models;
using System.Data;
using System.Data.SqlClient;
using GurukulAppAdminPanel.App_Start;

namespace GurukulAppAdminPanel.Controllers
{
    public class IAScoachingController : Controller
    {
        private DataTable _dtable;
        private List<SelectListItem> item;
        // GET: IAScoaching
        public ActionResult Index()
        {
        IasMangement ob = new IasMangement();
            ob.subjectlist = new List<SelectListItem>();
            item = new List<SelectListItem>() {
                new SelectListItem() { Text = "Select Subject", Value = "", Selected = true },
                new SelectListItem() { Text = "New", Value = ""}
               };
           ob.subjectlist = item;
            return View("IAScoaching", ob);
        }
        public string GetSubject()
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_Master_List("MASTER SUBJECT");


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
        public string GetBusinessProfile()
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_Master_List("BUSINESS ROLE");


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
        public string AddIasCoaching(IasMangement ob)
        {
            string _jsonString = string.Empty;


            MasterManagement _MM = new MasterManagement();
           // var data = request.Content.ReadAsStringAsync().Result;
            //string Jsondata = data.ToString();

            _dtable = new DataTable();
            _MM = new MasterManagement();
            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();

            _postArrData.Add("COACHING_DATE", ob.Date);
            _postArrData.Add("SUBJECT_ID", ob.Subject);
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);


            _dtable = _MM.Add_coaching_detail(_postContent);
            
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

        public string GetIasDetails()
        {
            string _jsonString = string.Empty;

            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_Coaching_Detail_List();


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
               // response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                _jsonString = Data.DatatableEmpty();
               // response = this.Request.CreateResponse(HttpStatusCode.OK);
            }


            return _jsonString;
        }
        public string UpdateIasCoaching(IasMangement ob)
        {
            string _jsonString = string.Empty;


            MasterManagement _MM = new MasterManagement();
            // var data = request.Content.ReadAsStringAsync().Result;
            //string Jsondata = data.ToString();

            _dtable = new DataTable();
            _MM = new MasterManagement();
            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();
            _postArrData.Add("RECORD_SYS_ID", ob.Record_id);
            _postArrData.Add("COACHING_DATE", ob.Date);
            _postArrData.Add("SUBJECT_ID", ob.Subject);
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);


            _dtable = _MM.Update_coaching_detail(_postContent);

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
        public string GetRecordDetails(string Record_id = null)
        {
            string _jsonString = string.Empty;

            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_Coaching_Detail(Record_id);


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                // response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                _jsonString = Data.DatatableEmpty();
                // response = this.Request.CreateResponse(HttpStatusCode.OK);
            }


            return _jsonString;
        }
        public string DeleteIAS(string Record_id)
        {
            string _jsonString = string.Empty;

            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.Delete_Coaching_detail_Data(Record_id);


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
               // response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                _jsonString = Data.DatatableEmpty();
                //response = this.Request.CreateResponse(HttpStatusCode.OK);
            }


            return _jsonString;
        }

    }
}