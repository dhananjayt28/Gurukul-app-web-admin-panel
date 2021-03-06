﻿using System;
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
using System.Security.AccessControl;
//using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

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
            //View_Master_List("EVENT MASTER")
            MasterManagement _mmobj = new MasterManagement();
            DataTable dt = new DataTable();
            dt = _mmobj.View_Master_List("EVENT_MASTER");
            string response = string.Empty;
            _response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);



           // _response = _eventObj.GetEventMasterType();
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
                    //item.Add(new SelectListItem() { Value = "", Text = "Choose Project Name" });
                    foreach (Dictionary<string, object> _data in _EventType)
                    {
                        //string _val = _data["EVENT_ID"].ToString();
                        //string _text = _data["EVENT_NAME"].ToString();
                        string _val = _data["LOV_ID"].ToString();
                        string _text = _data["LOV_NAME"].ToString();
                        item.Add(new SelectListItem() { Value = _val, Text = _text });
                    }
                    _eventObj.List = item;
                }
            }

            // State Dropdown Data
            // _response = _eventObj.GetEventData();
            //View_Master_List("EVENT MASTER")

            dt = _mmobj.View_Master_List("MASTER_STATE");
          
            _response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);
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
                    item.Add(new SelectListItem() { Value = "0", Text = "Select State" });
                    foreach (Dictionary<string, object> _data in _EventType)
                    {
                        string _val = _data["LOV_ID"].ToString();
                        string _text = _data["LOV_NAME"].ToString();
                        item.Add(new SelectListItem() { Value = _val, Text = _text });
                    }
                    _eventObj.StateList = item;
                }
            }

            // Location Dropdown Data
            item = new List<SelectListItem>();
            item.Add(new SelectListItem() { Value = "0", Text = "Select Location" });
            //item.Add(new SelectListItem() { Value = "1", Text = "Satsang Mumbai" });
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
        public dynamic Index(EventManagement _eventObj)
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
                        TempData["MSG"] = "";
                        //return Redirect(_url);
                        return _response;
                    }
                    else
                    {
                        string _url = Constant.BASEURL + "event/event-list";
                        TempData["MSG"] = "";
                        //return Redirect(_url);
                        return _response;
                    }
                }
                else
                {
                    string _url = Constant.BASEURL + "event/event-add";
                    // return Redirect(_url);
                    //return RedirectToAction("EventList");
                    return _response;
                }
                
            }
            else
            {
                List<SelectListItem> item;
                string _response = string.Empty;
                // Event Type Dropdown Data
                //View_Master_List("EVENT MASTER")
                MasterManagement _mmobj = new MasterManagement();
                DataTable dt = new DataTable();
                dt = _mmobj.View_Master_List("EVENT_MASTER");
                string response = string.Empty;
                _response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);



                //_response = _eventObj.GetEventMasterType();
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
                            //string _val = _data["EVENT_ID"].ToString();
                            //string _text = _data["EVENT_NAME"].ToString();
                            string _val = _data["LOV_ID"].ToString();
                            string _text = _data["LOV_NAME"].ToString();
                            item.Add(new SelectListItem() { Value = _val, Text = _text });
                        }
                        _eventObj.List = item;
                    }
                }

                // State Dropdown Data
                dt = _mmobj.View_Master_List("MASTER_STATE");

                _response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);
                //_response = _eventObj.GetEventData();
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
                            string _val = _data["LOV_ID"].ToString();
                            string _text = _data["LOV_NAME"].ToString();
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
            //View_Master_List("EVENT MASTER")
            MasterManagement _mmobj = new MasterManagement();
            DataTable dt = new DataTable();
            dt= _mmobj.View_Master_List("EVENT_MASTER");
            string response = string.Empty;
            _response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);
            //response = _emObj.GetEventMasterType();
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
                    //item.Add(new SelectListItem() { Value = "0", Text = "Choose Event" });
                    foreach (Dictionary<string,object> _data in _EventType)
                    {
                        //string _val = _data["EVENT_ID"].ToString();
                        //string _text = _data["EVENT_NAME"].ToString();
                        string _val = _data["LOV_ID"].ToString();
                        string _text = _data["LOV_NAME"].ToString();
                        if (_eventid == Convert.ToUInt32(_val))
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
                    if (data.ContainsKey("response"))
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
        public ActionResult VolunteerEventList(string vstatus = "",string etype ="")
        {
            EventManagement _emObj = new EventManagement();
            string _jsonString = string.Empty;
            string response = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            if (vstatus == "")
            {
                _dtable = _MM.Get_Event_Volunteer_Reg_Data("Waiting For Approval","");

            }
            else if (etype == "Select")
            {
                _dtable = _MM.Get_Event_Volunteer_Reg_Data(vstatus, "");

            }
            else
            {
                _dtable = _MM.Get_Event_Volunteer_Reg_Data(vstatus,etype);
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
        public ActionResult VolunteerEventApprove(string _statusVal, string _event_reg_id,string msg_id="")
        {

            int UserId = Convert.ToInt32(Session["USER_ID"]);
           
            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();

            _postArrData.Add("STATUS", _statusVal);
            _postArrData.Add("MESSAGE", msg_id);
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

            _postArrData.Add("STATUS", _statusVal);
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
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
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


                List<object> postdata = new List<object>();
                SortedList<string, object> _postArrData = new SortedList<string, object>();

                _postArrData.Add("CHAPTER_NAME", _smObj.chaptername);
                _postArrData.Add("CHAPTER_DESC", _smObj.chaperdescription);
                if (_smObj.countryid == "0")
                {
                    _postArrData.Add("COUNTRY_NAME", _smObj.country);
                    _postArrData.Add("COUNTRY_ID", _smObj.countryid);
                }
                else
                {
                    _postArrData.Add("COUNTRY_ID", _smObj.countryid);
                }
                if (_smObj.stateid == "0")
                {
                    _postArrData.Add("CITY_NAME", _smObj.state);
                    _postArrData.Add("CITY_ID", _smObj.stateid);
                }
                else
                {
                    _postArrData.Add("CITY_ID", _smObj.stateid);
                }
               
                postdata.Add(_postArrData);
                var _postContent = System.Web.Helpers.Json.Encode(postdata);
                MasterManagement _mmobj = new MasterManagement();
                DataTable dt = new DataTable();
                dt= _mmobj.AddChapterData(_postContent);
                _response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);

                //_response = _smObj.AddChapterData(_smObj);
                var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                bool status = Convert.ToBoolean(data["status"]);
                if (status)
                {
                    TempData["CHP_MSG"] = "Chapter Added Successfully";
                    return Redirect(Constant.BASEURL + "chapter/chapter-list");
                }
                else
                {
                    TempData["CHP_MSG"] = "Oops! Something went wrong...";
                    return Redirect(Constant.BASEURL + "chapter/chapter-add");
                }
            }
            TempData["CHP_MSG"] = "Please Fill All the Fields";
            return Redirect(Constant.BASEURL + "chapter/chapter-add");
        }
        /***************************************
         * Title :: Satsang Chapter List
         * Description :: this module use for santsang chapter list.
         * Param :: 
         * Return :: Table.
         **************************************/
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
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
            EventManagement _EM = new EventManagement();
            _dtable = new DataTable();
            _dtable = _EM.Get_event_date(event_id);
            if (_dtable.Rows.Count > 0)
            {
                response = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
            }
                //RestClient.RestClient _client = new RestClient.RestClient();

                //_client.URL = Constant.API_BASEURL+"api/get-event-calendar-breakup-data?event_id="+ event_id;
                //_client.Method = HttpMethod.GET;
                //_client.Type = ContentType.JSON;
                //_client.Execute();
                // response = _client.Response();
                //if (response == string.Empty)
                //{
                //    response = _client.errordata();
                //}
                return response;
        }
        public FileResult GenExcel()
        {
           string  global_event_id = Session["event_id_"].ToString();
            string response = string.Empty;

            //RestClient.RestClient _client = new RestClient.RestClient();
            //_client.URL = Constant.API_BASEURL + "api/get-event-calendar-breakup-data?event_id=" + global_event_id;
            //_client.Method = HttpMethod.GET;
            //_client.Type = ContentType.JSON;
            //_client.Execute();
            //response = _client.Response();
            //if (response == string.Empty)
            //{
            //    response = _client.errordata();
            //}
            EventManagement _EM = new EventManagement();
            _dtable = new DataTable();
            _dtable = _EM.Get_event_date(global_event_id);
            if (_dtable.Rows.Count > 0)
            {
                response = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
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
            _postArrData.Add("STATUS",29);
            _postArrData.Add("MESSAGE", 84);
            //16,USP_EVENT_MANAGEMENT,245
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);

            MasterManagement _mm = new MasterManagement();
            _dtable = _mm.TopicContent(_postContent);
            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
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
            _dtable = _MM.View_Master_List("MASTER_REASON");


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

        [HttpPost]
        public string UploadItinerary(EventManagement ob)
        {
            string file_name = ob.file.FileName;
            string response = string.Empty;

            if (!Directory.Exists(Server.MapPath("~/Uploaded_files")))
            {
                DirectorySecurity securityRules = new DirectorySecurity();
                securityRules.AddAccessRule(new FileSystemAccessRule(@"Domain\YourAppAllowedGroup", FileSystemRights.FullControl, AccessControlType.Allow));
                Directory.CreateDirectory(Server.MapPath("~/Uploaded_files"), securityRules);

            }
            try
            {
                string _FileName = Path.GetFileName(file_name);
                string _path = Path.Combine(Server.MapPath("~/Uploaded_files"), _FileName);
                ob.file.SaveAs(_path);
            }
            catch (Exception ex)
            {
                string errordata = ex.ToString();
                return errordata;
            }
            MasterManagement _mmobj = new MasterManagement();
            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();

            _postArrData.Add("EVENT_REG_ID", ob.hide_event_reg_id);            
            _postArrData.Add("ITINERARY_FILES", file_name);
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);
            DataTable dt= new DataTable();
            dt = _mmobj.Upload_Itinerary(_postContent);

            response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);


            return response;


        }
        public string GetContent(string event_id_)
        {
            MasterManagement _mmObj = new MasterManagement();
            DataTable dt = new DataTable();
          dt =  _mmObj.GetContent(event_id_);
           string response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);
            return response;
        }
        public string GetUserCount()
        {
            MasterManagement _mmObj = new MasterManagement();
            DataTable dt = new DataTable();
            dt = _mmObj.GetUserCount();
            string response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);
            return response;
            
        }
        public string GetEventCount()
        {
            MasterManagement _mmObj = new MasterManagement();
            DataTable dt = new DataTable();
            dt = _mmObj.GetEventCount();
            string response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);
            return response;

        }
        /***********************
         * Name - GetEventType
         * param- null
         * return- Event type list in json string
         * ************/
         public string GetEventType()
        {
            MasterManagement _mmobj = new MasterManagement();
            DataTable dt = new DataTable();
            dt = _mmobj.View_Master_List("EVENT_MASTER");
            string response = string.Empty;
            string _response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);
            return _response;
        }
        /**********************
         * Name-GetCountryList
         * param-null
         * return- json
         * Author- Sayan Chatterjee
         * *****************/
         public string GetCountryList()
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            //_dtable = _MM.View_Master_List("MASTER_COUNTRY");
            _dtable = _MM.GetCountry();


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);                
            }
            return _jsonString;
        }
        /**********************
         * Name-GetCityList
         * param-null
         * return- json
         * Author- Sayan Chatterjee
         * *****************/
        public string GetCityList(string Country_id)
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            //_dtable = _MM.View_Master_List("MASTER_CITY");
            _dtable = _MM.GetCityByCountry(Country_id);


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
            }
            return _jsonString;
        }
        /*************************
         * Name- DailyRequirementSummaryReport
         * param- null
         * Return - View
         * Author- Sayan Chatterjee
         * ***********************/
        public ActionResult DailyRequirementSummaryReport()
        {
            //EventManagement _evObj = new EventManagement();
            //string _response = string.Empty;
            //DataTable dt = new DataTable();
            //dt = _evObj.GetSummaryReport("","");
            //_response = dt.Rows[0]["JSON_VALUE"].ToString();
            //if (_response != string.Empty)
            //{
            //    JavaScriptSerializer jsObj = new JavaScriptSerializer();
            //    var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
            //    bool status = Convert.ToBoolean(data["status"]);
            //    if (status)
            //    {
            //        _evObj.SummaryList = (ArrayList)data["response"];
            //    }
            //}
            ViewBag.breadcrumbController = "Report";
            ViewBag.breadcrumbAction = "Daily Requirement Summary Report";
            //ViewBag.Title = "Chapter List" + Constant.PROJECT_NAME;
            return View();

        }
        ///*************************
        // * Name- DailyRequirementDetailedReport
        // * param- null
        // * Return - View
        // * Author- Sayan Chatterjee
        // * ***********************/
        //public ActionResult DailyRequirementDetailedReport()
        //{
        //    EventManagement _evObj = new EventManagement();
        //    string _response = string.Empty;
        //    DataTable dt = new DataTable();
        //    dt = _evObj.GetDetailedReport();
        //    _response = dt.Rows[0]["JSON_VALUE"].ToString();
        //    if (_response != string.Empty)
        //    {
        //        JavaScriptSerializer jsObj = new JavaScriptSerializer();
        //        var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
        //        bool status = Convert.ToBoolean(data["status"]);
        //        if (status)
        //        {
        //            _evObj.DetailedList = (ArrayList)data["response"];
        //        }
        //    }
        //    ViewBag.breadcrumbController = "Report";
        //    ViewBag.breadcrumbAction = "Daily Requirement Detailed Report";
        //    //ViewBag.Title = "Chapter List" + Constant.PROJECT_NAME;
        //    return View(_evObj);

        //}
        /*************************
         * Name- ApprovedVolunteerArrivaldepartureReport
         * param- null
         * Return - View
         * Author- Sayan Chatterjee
         * ***********************/
        public ActionResult ApprovedVolunteerArrivaldepartureReport()
        {
            EventManagement _evObj = new EventManagement();
            string _response = string.Empty;
            DataTable dt = new DataTable();
            dt = _evObj.GetArrivalDepurtureReport();
            _response = dt.Rows[0]["JSON_VALUE"].ToString();
            if (_response != string.Empty)
            {
                JavaScriptSerializer jsObj = new JavaScriptSerializer();
                var data = jsObj.Deserialize<Dictionary<string, object>>(_response);
                bool status = Convert.ToBoolean(data["status"]);
                if (status)
                {
                    //_evObj.ArrivalDepurtureList = (ArrayList)data["response"];
                }
            }
            ViewBag.breadcrumbController = "Report";
            ViewBag.breadcrumbAction = "Approved Volunteer Arrival/Departure Report";
            //ViewBag.Title = "Chapter List" + Constant.PROJECT_NAME;
            //_evObj
            return View();

        }
        /**************************
         * Name - GetSummaryReport
         * param- null
         * Return json string
         * Author - Sayan chatterjee
         * **********************/
         public string GetSummaryReport(string from_date,string to_date)
        {
            string response = string.Empty;
            EventManagement _evObj = new EventManagement();
            string _response = string.Empty;
            DataTable dt = new DataTable();
            dt = _evObj.GetSummaryReport(from_date,to_date);
            response = dt.Rows[0]["JSON_VALUE"].ToString();
            return response;
        }
        /**************************
        * Name - GetSummaryReport
        * param- date
        * Return json string
        * Author - Sayan chatterjee
        * **********************/
        public string GetDetailedReport(string date,string event_name)
        {
            string response = string.Empty;
            EventManagement _evObj = new EventManagement();
            string _response = string.Empty;
            DataTable dt = new DataTable();
            dt = _evObj.GetDetailedReport(date,event_name);
            response = dt.Rows[0]["JSON_VALUE"].ToString();
            return response;
        }
        /**************************
     * Name - GetArrivalDepurtureReport
     * param- date
     * Return json string
     * Author - Sayan chatterjee
     * **********************/
        public string GetArrivalDepurtureReport(string from_date, string to_date)
        {
            string response = string.Empty;
            EventManagement _evObj = new EventManagement();
            string _response = string.Empty;
            DataTable dt = new DataTable();
            dt = _evObj.GetArrivalDepurtureReport(from_date, to_date);
            response = dt.Rows[0]["JSON_VALUE"].ToString();
            return response;
        }
        /***********************
         * Name- Country
         * param- null
         * Return - View
         * Author- Sayan Chatterjee
         * *********************/
        public ActionResult Country()
        {
            return View();
        }
        /***********************
         * Name- City
         * param- null
         * Return - View
         * Author- Sayan Chatterjee
         * *********************/
        public ActionResult City()
        {
            return View();
        }
        /**********************
        * Name-GetCityList
        * param-null
        * return- json
        * Author- Sayan Chatterjee
        * *****************/
        public string GetAllCityList()
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            //_dtable = _MM.View_Master_List("MASTER_CITY");
            _dtable = _MM.GetAllCity();


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
            }
            return _jsonString;
        }
        /**********************
         * Name- Get Sate List
         * param- null
         * return - json string
         * Author- Sayan chatterjee
         * **********************/
        public string GetStateList()
        {
            string _response = string.Empty;
            //RestClient _client = new RestClient();
            //_client.URL = Constant.GET_MASTER_STATE_DATA;
            //_client.Method = HttpMethod.GET;
            //_client.Execute();
            //_response = _client.Response();
            EventManagement evObj = new EventManagement();
            _response = evObj.GetStateData().Rows[0]["JSON_VALUE"].ToString();
            return _response;
        }
        /*****************************
         * Name - SaveStateAllocation
         * param- null
         * return - json string
         * Author- Sayan Chatterjee
         * ***************************/
         
         public string SaveStateAllocation(string jsondata)
        {
            jsondata=  System.Uri.UnescapeDataString(jsondata);
            string response = string.Empty;
            EventManagement evObj = new EventManagement();
            response = evObj.SaveStateAllocatrion(jsondata).Rows[0]["JSON_VALUE"].ToString();
            return response;
        }
        /***********************
         * Name - Delete Country
         * param- country id 
         * Return - json string
         * Author - Sayan Chatterjee
         * **********************/ 
         public string DeleteCountry(string country_id)
        {
            string response = string.Empty;
            EventManagement evObj = new EventManagement();
            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();
            _postArrData.Add("COUNTRY_SYS_ID", country_id);  
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);
            response = evObj.DeleteCountry(_postContent).Rows[0]["JSON_VALUE"].ToString();
            return response;
        }
        /***********************
        * Name - Delete City
        * param- city id 
        * Return - json string
        * Author - Sayan Chatterjee
        * **********************/
        public string DeleteCity(string city_id)
        {
            string response = string.Empty;
            EventManagement evObj = new EventManagement();
            List<object> postdata = new List<object>();
            SortedList<string, object> _postArrData = new SortedList<string, object>();
            _postArrData.Add("CITY_SYS_ID", city_id);           
            postdata.Add(_postArrData);
            var _postContent = System.Web.Helpers.Json.Encode(postdata);
            response = evObj.DeleteCity(_postContent).Rows[0]["JSON_VALUE"].ToString();
            return response;
        }
        //[HttpPost]
        //public ActionResult Index(string qrcode)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        QRCoder.QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
        //        using (Bitmap bitMap = qrCode.GetGraphic(20))
        //        {
        //            bitMap.Save(ms, ImageFormat.Png);
        //            ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
        //        }
        //    }

        //    return View();
        //}
        /********************
         * Name - ExcelExportOfSummaryReport
         * param- null
         * Return Excel file
         * Author - Sayan Chatterjee
         * *********************/
        public FileResult ExcelExportOfSummaryReport(string from_date,string to_date)
        {
           
            string response = string.Empty;
            EventManagement _evObj = new EventManagement();
            string _response = string.Empty;
            DataTable dt1 = new DataTable();
            dt1 = _evObj.GetSummaryReport(from_date,to_date);
            response = dt1.Rows[0]["JSON_VALUE"].ToString();         

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

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Summary_Report.xlsx");
            }
            catch (Exception ex)
            {
                return File(new MemoryStream(Encoding.UTF8.GetBytes(ex.Message.ToString())).ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
            }
        }
        /********************
       * Name - ExcelExportOfSummaryReport
       * param- null
       * Return Excel file
       * Author - Sayan Chatterjee
       * *********************/
        public FileResult ExcelExportOfArrivalDepurtureReport(string from_date,string to_date)
        {

            string response = string.Empty;
            EventManagement _evObj = new EventManagement();
            string _response = string.Empty;
            DataTable dt1 = new DataTable();
            dt1 = _evObj.GetArrivalDepurtureReport(from_date, to_date);
            response = dt1.Rows[0]["JSON_VALUE"].ToString();

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

                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Approved_Volunteer_Arrival_Depurture_Report.xlsx");
            }
            catch (Exception ex)
            {
                return File(new MemoryStream(Encoding.UTF8.GetBytes(ex.Message.ToString())).ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
            }
        }

        public ActionResult AddLocation()
        {
            EventManagement _eventObj = new EventManagement();
            List<SelectListItem> item;
            string _response = string.Empty;
            // Event Type Dropdown Data
            //View_Master_List("EVENT MASTER")
            MasterManagement _mmobj = new MasterManagement();
            DataTable dt = new DataTable();
            dt = _mmobj.View_Master_List("EVENT_MASTER");
            string response = string.Empty;
            _response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);

            dt = _mmobj.View_Master_List("MASTER_STATE");

            _response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);
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
                    item.Add(new SelectListItem() { Value = "0", Text = "Select State" });
                    foreach (Dictionary<string, object> _data in _EventType)
                    {
                        string _val = _data["LOV_ID"].ToString();
                        string _text = _data["LOV_NAME"].ToString();
                        item.Add(new SelectListItem() { Value = _val, Text = _text });
                    }
                    _eventObj.StateList = item;
                }
            }
            // Location Dropdown Data
            item = new List<SelectListItem>();
            item.Add(new SelectListItem() { Value = "0", Text = "Select Location" });
            //item.Add(new SelectListItem() { Value = "1", Text = "Satsang Mumbai" });
            _eventObj.LocationList = item;

            ViewBag.breadcrumbController = "Event";
            ViewBag.breadcrumbAction = "Add New Event";
            ViewBag.Title = "Add New Event" + Constant.PROJECT_NAME;
            return View(_eventObj);
            // return View();
        }


        [HttpPost]
        public string AddLocationName(EventManagement ob)
        {
            string _jsonString = string.Empty;
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    MasterManagement _MM = new MasterManagement();
                    //string _jsonString = string.Empty;
                    int UserId = Convert.ToInt32(Session["USER_ID"]);
                    List<object> postdata = new List<object>();
                    SortedList<string, object> _postArrData = new SortedList<string, object>();
                    _postArrData.Add("CREATED_BY", UserId);
                    _postArrData.Add("COUNTRY_ID",1);
                    _postArrData.Add("STATE_ID", ob.EventStateId);
                    _postArrData.Add("LOCATION_NAME", ob.LOCATION_NAME);
                     postdata.Add(_postArrData);
                    var _postContent = System.Web.Helpers.Json.Encode(postdata);
                    if (_postContent != null)
                    {
                        _dtable = _MM.Add_location_master_data(_postContent);
                    }
                    if (_dtable.Rows.Count > 0)
                    {
                        _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    }
                    else
                    {
                        _jsonString = Data.DatatableEmpty();
                    }
                    return _jsonString;
                }
                else
                {
                    errordata = new Dictionary<string, object>();
                    errordata.Add("status", false);
                   // errordata.Add("response", ModelError(ModelState));
                    return Data.ObjectToJsonString(errordata);
                }
            }
            else
            {
                return Constant.UNAUTH_ACCESS;
            }
        }

        public string GetAllLocationList(string state_id)
        {
            string _jsonString = string.Empty;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            //_dtable = _MM.View_Master_List("MASTER_CITY");
            _dtable = _MM.GetLocationNameByStatID(state_id);
            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
            }
            return _jsonString;
        }
    }
}