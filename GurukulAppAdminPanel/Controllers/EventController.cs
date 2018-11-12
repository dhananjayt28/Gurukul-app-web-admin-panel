using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using GurukulAppAdminPanel.Models;
using GurukulAppAdminPanel.App_Start;
using System.Web.Script.Serialization;
using RestClient;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.tool.xml;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;


namespace GurukulAppAdminPanel.Controllers
{
    
    public class EventController : MasterController
    {
        private DataTable _dtable;
        private Dictionary<string, object> errordata, dictionaryObj;

        public EventController() { }
        /***************************************
         * Title :: Event Add View
         * Description :: this module use for event add view
         * Param ::
         * Return :: Event Add View part.
         **************************************/
        [HttpGet]
        public ActionResult Index()
        {
            EventManagement _eventObj = new EventManagement();
            List<SelectListItem> item;
            string _response = string.Empty;
            // Event Type Dropdown Data
            _response = _eventObj.GetEventMasterType();
            if (_response != string.Empty)
            {
                JavaScriptSerializer jsObj = new JavaScriptSerializer();
                var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                bool status = Convert.ToBoolean(data["status"]);
                if (status)
                {
                    ArrayList _EventType = (ArrayList)data["response"];
                    //SelectListItem[] item = new SelectListItem[_EventType.Count + 1];
                    item = new List<SelectListItem>();
                    item.Add(new SelectListItem() { Value = "", Text = "Choose Project Name" });
                    foreach (Dictionary<string, object> _data in _EventType)
                    {
                        string _val = _data["EVENT_ID"].ToString();
                        string _text = _data["EVENT_NAME"].ToString();
                        item.Add(new SelectListItem() { Value = _val, Text = _text });
                    }
                    _eventObj.List = item;
                }
            }

            // State Dropdown Data
            _response = _eventObj.GetEventData();
            if (_response != string.Empty)
            {
                JavaScriptSerializer jsObj = new JavaScriptSerializer();
                var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                bool status = Convert.ToBoolean(data["status"]);
                if (status)
                {
                    ArrayList _EventType = (ArrayList)data["response"];
                    //SelectListItem[] item = new SelectListItem[_EventType.Count + 1];
                    item = new List<SelectListItem>();
                    item.Add(new SelectListItem() { Value = "0", Text = "Choose State" });
                    foreach (Dictionary<string, object> _data in _EventType)
                    {
                        string _val = _data["STATE_ID"].ToString();
                        string _text = _data["STATE_NAME"].ToString();
                        item.Add(new SelectListItem() { Value = _val, Text = _text });
                    }
                    _eventObj.StateList = item;
                }
            }

            // Location Dropdown Data
            item = new List<SelectListItem>();
            item.Add(new SelectListItem() { Value = "0", Text = "Choose Location" });
            item.Add(new SelectListItem() { Value = "1", Text = "Satsang Mumbai" });
            _eventObj.LocationList = item;

            ViewBag.breadcrumbController = "Event";
            ViewBag.breadcrumbAction = "Add New Event";
            ViewBag.Title = "Add New Event" + Constant.PROJECT_NAME;
            return View(_eventObj);
        }

        /***************************************
         * Title :: Event Add View
         * Description :: this module use for event add view
         * Param ::
         * Return :: Event Add View part.
         **************************************/
        [HttpPost]
        public ActionResult Index(EventManagement _eventObj)
        {
            if (ModelState.IsValid)
            {
                int UserId = Convert.ToInt32(Session["USER_ID"]);
                string _response = _eventObj.AddEventCalender(_eventObj, UserId);
                if (_response != string.Empty)
                {
                    JavaScriptSerializer jsObj = new JavaScriptSerializer();
                    var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                    bool status = Convert.ToBoolean(data["status"]);
                    if (status)
                    {
                        string _url = Constant.BASEURL + "event/event-list";
                        return Redirect(_url);
                    }
                    else
                    {
                        string _url = Constant.BASEURL + "event/event-list";
                        return Redirect(_url);
                    }
                }
                else
                {
                    string _url = Constant.BASEURL + "event/event-list";
                    return Redirect(_url);
                }
                
            }
            else
            {
                List<SelectListItem> item;
                string _response = string.Empty;
                // Event Type Dropdown Data
                _response = _eventObj.GetEventMasterType();
                if (_response != string.Empty)
                {
                    JavaScriptSerializer jsObj = new JavaScriptSerializer();
                    var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                    bool status = Convert.ToBoolean(data["status"]);
                    if (status)
                    {
                        ArrayList _EventType = (ArrayList)data["response"];
                        //SelectListItem[] item = new SelectListItem[_EventType.Count + 1];
                        item = new List<SelectListItem>();
                        item.Add(new SelectListItem() { Value = "", Text = "Choose Project Name" });
                        foreach (Dictionary<string, object> _data in _EventType)
                        {
                            string _val = _data["EVENT_ID"].ToString();
                            string _text = _data["EVENT_NAME"].ToString();
                            item.Add(new SelectListItem() { Value = _val, Text = _text });
                        }
                        _eventObj.List = item;
                    }
                }

                // State Dropdown Data
                _response = _eventObj.GetEventData();
                if (_response != string.Empty)
                {
                    JavaScriptSerializer jsObj = new JavaScriptSerializer();
                    var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                    bool status = Convert.ToBoolean(data["status"]);
                    if (status)
                    {
                        ArrayList _EventType = (ArrayList)data["response"];
                        //SelectListItem[] item = new SelectListItem[_EventType.Count + 1];
                        item = new List<SelectListItem>();
                        item.Add(new SelectListItem() { Value = "0", Text = "Choose State" });
                        foreach (Dictionary<string, object> _data in _EventType)
                        {
                            string _val = _data["STATE_ID"].ToString();
                            string _text = _data["STATE_NAME"].ToString();
                            item.Add(new SelectListItem() { Value = _val, Text = _text });
                        }
                        _eventObj.StateList = item;
                    }
                }

                // Location Dropdown Data
                item = new List<SelectListItem>();
                item.Add(new SelectListItem() { Value = "0", Text = "Choose Location" });
                item.Add(new SelectListItem() { Value = "1", Text = "Satsang Mumbai" });
                _eventObj.LocationList = item;
            }            

            ViewBag.breadcrumbController = "Event";
            ViewBag.breadcrumbAction = "Add New Event";
            ViewBag.Title = "Add New Event" + Constant.PROJECT_NAME;
            return View(_eventObj);
        }
        /***************************************
         * Title :: Event List
         * Description :: this module use for show list which create by admin
         * Param :: eventid = optional
         * Return :: Event list View part.
         **************************************/
        [HttpGet]
        public ActionResult EventList(string eventid = "")
        {
            int _eventid = 0;
            string _response = string.Empty;
            EventManagement _emObj = new EventManagement();
            if (eventid != string.Empty)
            {
                _eventid = Convert.ToInt32(eventid);
            }
            // Dropdown Data
            _response = _emObj.GetEventMasterType();
            if (_response != string.Empty)
            {
                JavaScriptSerializer jsObj = new JavaScriptSerializer();
                var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                bool status = Convert.ToBoolean(data["status"]);
                if (status)
                {
                    ArrayList _EventType = (ArrayList)data["response"];
                    //SelectListItem[] item = new SelectListItem[_EventType.Count + 1];
                    List<SelectListItem> item = new List<SelectListItem>();
                    item.Add(new SelectListItem() { Value = "0", Text = "Choose Event" });
                    foreach (Dictionary<string,object> _data in _EventType)
                    {
                        string _val = _data["EVENT_ID"].ToString();
                        string _text = _data["EVENT_NAME"].ToString();
                        if(_eventid == Convert.ToUInt32(_val))
                        {
                            item.Add(new SelectListItem() { Value = _val, Text = _text, Selected = true });
                        }
                        else
                        {
                            item.Add(new SelectListItem() { Value = _val, Text = _text });
                        }
                    }
                    _emObj.List = item;
                }
            }

            // Event Table Data
            _response = _emObj.GetEventData(_eventid);
            if(_response != string.Empty)
            {
                JavaScriptSerializer jsObj = new JavaScriptSerializer();
                var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                bool status = Convert.ToBoolean(data["status"]);
                if (status)
                {
                    if (_eventid == 1)
                    {
                        _emObj.EventNivrittilist = (ArrayList)data["response"];
                    }
                    else if (_eventid == 2)
                    {
                        _emObj.EventWorkshoplist = (ArrayList)data["response"];
                    }
                    else if (_eventid == 3)
                    {
                        _emObj.EventGitalist = (ArrayList)data["response"];
                    }

                }
            }

            ViewBag.BASEURL = Constant.BASEURL + "event/event-list/";
            ViewBag.eventid = _eventid;
            ViewBag.breadcrumbController = "Event";
            ViewBag.breadcrumbAction = "Event List";
            ViewBag.Title = "Event List" + Constant.PROJECT_NAME;
            return View(_emObj);
        }

        /***************************************
         * Title :: Volunteer Registration Event List
         * Description :: this module use for show list which event registration by volunteer
         * Param :: 
         * Return :: Event list View part.
         **************************************/
        [HttpGet]
        public ActionResult VolunteerEventList(string vstatus = "")
        {
            EventManagement _emObj = new EventManagement();
            string _jsonString = string.Empty;
            string response = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            if (vstatus == "")
            {
                _dtable = _MM.Get_Event_Volunteer_Reg_Data("Waiting For Approval");

            }
            else
            {
                _dtable = _MM.Get_Event_Volunteer_Reg_Data(vstatus);
            }

            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
               
            }
            else
            {
                _jsonString = Data.DatatableEmpty();
                //response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            //_response = _emObj.GetVolunteerEventRegData();
            if (_jsonString != string.Empty)
            {
                JavaScriptSerializer jsObj = new JavaScriptSerializer(); 
                var data = jsObj.Deserialize<Dictionary<string, object>>(_jsonString);
                bool status = Convert.ToBoolean(data["status"]);
                dictionaryObj = new Dictionary<string, object>();
                dictionaryObj = Data.Deserialize(_jsonString, typeof(Dictionary<string, object>));
                if (dictionaryObj.ContainsKey("response"))
                {
                    _emObj.VolunteerEventList = (ArrayList)data["response"];
                }
                else
                {


                }
               
            }
            ViewBag.breadcrumbController = "Approval";
            ViewBag.breadcrumbAction = "Volunteer Event Registration List";
            ViewBag.Title = "Volunteer Event Registration List" + Constant.PROJECT_NAME;
            return View(_emObj);
        }
        /***************************************
         * Title :: Volunteer Registration Event Approve
         * Description :: this module use for evet registration approve through admin
         * Param :: 
         * Return :: Volunteer Event list View part.
         **************************************/
        public ActionResult VolunteerEventApprove(string _statusVal, string _event_reg_id)
        {

            int UserId = Convert.ToInt32(Session["USER_ID"]);
           
            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();

            _postArrData.Add("STATUS", 18);
            _postArrData.Add("MESSAGE", 78);
            _postArrData.Add("USER_ID", UserId);
            _postArrData.Add("EVENT_REG_ID", _event_reg_id);
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.VolunteerRegisterEventAction(_postContent);



            return Redirect(Constant.BASEURL + "event/volunteer-event-reg-list");
        }
        /***************************************
         * Title :: Volunteer Registration Event Rejection
         * Description :: this module use for evet registration rejection through admin
         * Param :: 
         * Return :: Volunteer Event list View part.
         **************************************/
        //[HttpPost]
        //public ActionResult VolunteerEventRejection(EventManagement _eventobj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string _response = string.Empty, _msg = string.Empty, _eventid = string.Empty, _status = string.Empty;
        //        string[] data = Base64.Decode(_eventobj.EventId).Split(new[] { "-" }, StringSplitOptions.None);
        //        _eventid = data[0];
        //        _status = data[1];
        //        _msg = _eventobj.RejectMessage;
        //        int UserId = Convert.ToInt32(Session["USER_ID"]);
        //        _response = _eventobj.RejectionVolunteerEventRegData(_eventid, _status, _msg, UserId);
        //        if(_response != string.Empty)
        //        {
        //            JavaScriptSerializer jsObj = new JavaScriptSerializer();
        //            var responsedata = jsObj.Deserialize<Dictionary<string, object>>(_response);
        //            bool status = Convert.ToBoolean(responsedata["status"]);
        //            if (status)
        //            {
        //                _msg = responsedata["response"].ToString();
        //            }
        //            else
        //            {
        //                _msg = responsedata["response"].ToString();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (ModelState modelState in ViewData.ModelState.Values)
        //        {
        //            foreach (ModelError error in modelState.Errors)
        //            {

        //            }
        //        }
        //    }
        //    return Redirect(Constant.BASEURL + "event/volunteer-event-reg-list");
        //}
        public ActionResult VolunteerEventRejections(string _statusVal, string _event_reg_id,string message)
        {

            int UserId = Convert.ToInt32(Session["USER_ID"]);

            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();

            _postArrData.Add("STATUS", 19);
            _postArrData.Add("MESSAGE", message);
            _postArrData.Add("USER_ID", UserId);
            _postArrData.Add("EVENT_REG_ID", _event_reg_id);
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.VolunteerEventRejectAction(_postContent);



            return Redirect(Constant.BASEURL + "event/volunteer-event-reg-list");
        }
       

        /***************************************
         * Title :: Event Approve
         * Description :: this module use for event approve to show on Volunteer profile
         * Param :: 
         * Return :: Volunteer Event list View part.
         **************************************/
        public ActionResult EventCalenderApprove(int calenderid)
        {
            if (calenderid > 0)
            {
                string _response = string.Empty, _msg = string.Empty;
                int UserId = Convert.ToInt32(Session["USER_ID"]);
                EventManagement _eventobj = new EventManagement();
                _response = _eventobj.ApproveEventCalender(calenderid, UserId);
                if (_response != string.Empty)
                {
                    JavaScriptSerializer jsObj = new JavaScriptSerializer();
                    var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                    bool status = Convert.ToBoolean(data["status"]);
                    if (status)
                    {
                        _msg = data["response"].ToString();
                    }
                    else
                    {
                        _msg = data["response"].ToString();
                    }
                }
            }
            return Redirect(Constant.BASEURL + "event/event-list/");
        }

        /***************************************
         * Title :: Add Satsang Chapter
         * Description :: this module use for add santsang chapter.
         * Param :: 
         * Return :: Row affected.
         **************************************/
        [HttpGet]
        public ActionResult AddSatsangChapter()
        {
            string _response;
            JavaScriptSerializer jsObj = new JavaScriptSerializer();
            SatsangManagement _smObj = new SatsangManagement();
            // Dropdown Data
            _response = _smObj.GetCountryListData();
            if (_response != string.Empty)
            {                
                var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                bool status = Convert.ToBoolean(data["status"]);
                if (status)
                {
                    ArrayList _EventType = (ArrayList)data["response"];
                    //SelectListItem[] item = new SelectListItem[_EventType.Count + 1];
                    List<SelectListItem> item = new List<SelectListItem>();
                    item.Add(new SelectListItem() { Value = "", Text = "Choose Country", Selected = true });
                    foreach (Dictionary<string, object> _data in _EventType)
                    {
                        string _val = _data["country_id"].ToString();
                        string _text = _data["country_name"].ToString();
                        item.Add(new SelectListItem() { Value = _val, Text = _text });
                    }
                    _smObj.CountryList = item;
                }
            }

            ViewBag.breadcrumbController = "Chapter";
            ViewBag.breadcrumbAction = "Add Chapter";
            ViewBag.Title = "Add Chapter" + Constant.PROJECT_NAME;
            return View(_smObj);
        }
        /***************************************
         * Title :: Add Satsang Chapter - POST
         * Description :: this module use for add santsang chapter.
         * Param :: 
         * Return :: Row affected.
         **************************************/
        [HttpPost]
        public ActionResult AddSatsangChapter(SatsangManagement _smObj)
        {
            string _response;
            JavaScriptSerializer jsObj = new JavaScriptSerializer();
            //SatsangManagement _smObj = new SatsangManagement();
            if (ModelState.IsValid)
            {
                _response = _smObj.AddChapterData(_smObj);
                var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                bool status = Convert.ToBoolean(data["status"]);
                if (status)
                {
                    return Redirect(Constant.BASEURL + "chapter/chapter-list");
                }
                else
                {
                    return Redirect(Constant.BASEURL + "chapter/chapter-add");
                }
            }
            return Redirect(Constant.BASEURL + "chapter/chapter-add");
        }
        /***************************************
         * Title :: Satsang Chapter List
         * Description :: this module use for santsang chapter list.
         * Param :: 
         * Return :: Table.
         **************************************/
        [HttpGet]
        public ActionResult SatsangChapterList()
        {

            SatsangManagement _emObj = new SatsangManagement();
            string _response = string.Empty;
            _response = _emObj.GetSatsangChapterData();
            if (_response != string.Empty)
            {
                JavaScriptSerializer jsObj = new JavaScriptSerializer();
                var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                bool status = Convert.ToBoolean(data["status"]);
                if (status)
                {
                    _emObj.ChapterList = (ArrayList)data["response"];
                }
            }
            ViewBag.breadcrumbController = "Chapter";
            ViewBag.breadcrumbAction = "Chapter List";
            ViewBag.Title = "Chapter List" + Constant.PROJECT_NAME;
            return View(_emObj);
        }
        public string GetEventCalendar(string event_id)
        {
           Session["event_id_"] = event_id;
            string response = string.Empty;

            RestClient.RestClient _client = new RestClient.RestClient();
            _client.URL = "http://gurukulweb.tangenttechsolutions.com/api/get-event-calendar-breakup-data?event_id="+ event_id;
            _client.Method = HttpMethod.GET;
            _client.Type = ContentType.JSON;
            _client.Execute();
             response = _client.Response();
            if (response == string.Empty)
            {
                response = _client.errordata();
            }
            return response;
        }
        public FileResult GenExcel()
        {
           string  global_event_id = Session["event_id_"].ToString();
            string response = string.Empty;

            RestClient.RestClient _client = new RestClient.RestClient();
            _client.URL = "http://gurukulweb.tangenttechsolutions.com/api/get-event-calendar-breakup-data?event_id="+ global_event_id;
            _client.Method = HttpMethod.GET;
            _client.Type = ContentType.JSON;
            _client.Execute();
            response = _client.Response();
            if (response == string.Empty)
            {
                response = _client.errordata();
            }

            try
            {
                DataTable dt = new DataTable();
                MemoryStream stream = new MemoryStream();
                dt = Data.JsonToDatatable(response, "dataSheet");
                using (XLWorkbook wb = new XLWorkbook())
                {

                    wb.Worksheets.Add(dt);
                    wb.SaveAs(stream);
                    wb.Dispose();
                }

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
            }
            catch (Exception ex)
            {
                return File(new MemoryStream(Encoding.UTF8.GetBytes(ex.Message.ToString())).ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
            }
        }
        public string mmddyyyy(string date)
        {
            char[] chars = date.ToCharArray();
            char temp = chars[0];
            char temp1 = chars[1];
            char temp2 = chars[3];
            char temp3 = chars[4];
            chars[3] = temp;
            chars[4] = temp1;
            chars[0] = temp2;
            chars[1] = temp3;
            string date1 = new string(chars);
            return date1;
        }
        public string GetEvent(string event_id_)
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_Registered_Event_Data(event_id_);


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
        //TopicContent
        public ActionResult AddTopicContent(string enent_reg_id,string subject_id,string topic_id,string content)
        {
            string _jsonString = string.Empty;
            int UserId = Convert.ToInt32(Session["USER_ID"]);
            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();

            _postArrData.Add("EVENT_REG_ID", enent_reg_id);
            _postArrData.Add("SUBJECT_ID", subject_id);
            _postArrData.Add("TOPIC_ID", topic_id);
            _postArrData.Add("USER_ID", UserId);
            _postArrData.Add("CONTENT_SOURCE", content);
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);

            MasterManagement _mm = new MasterManagement();
            _dtable = _mm.TopicContent(_postContent);
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
            string _url = Constant.BASEURL + "event/volunteer-event-reg-list";
            return Redirect(_url);

        }
        //GetReason
        public string GetReason()
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_Master_List("MASTER REASON");


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



    }
}