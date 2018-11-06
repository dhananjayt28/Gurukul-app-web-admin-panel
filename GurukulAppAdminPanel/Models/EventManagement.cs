namespace GurukulAppAdminPanel.Models
{
    using System.Collections;
    using RestClient;
    using GurukulAppAdminPanel.App_Start;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Helpers;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using DatabaseManagementClient;

    public class EventManagement
    {
        private DatabaseManagement _dbObj = new DatabaseManagement("ConnectDB");
        private DataTable _dtable;
        private SqlParameter[] _param;

        public string EventId { get; set; }

        //public string LocationId { get; set; }

        [Display(Name = "Start Date")]
        //[Required(ErrorMessage = "Start Date should be require")]
        public string EventStartDate { get; set; }
        [Display(Name = "End Date")]
        //[Required(ErrorMessage = "End Date should be require")]
        public string EventEndDate { get; set; }
        [Display(Name = "Expire Date")]
        //[Required(ErrorMessage = "Expire Date should be require")]
        public string EventExpireDate { get; set; }
        [Display(Name = "No. of Male")]
        //[Required(ErrorMessage = "Please enter the required Male Volunteers")]
        public string EventMaleNo { get; set; }
        [Display(Name = "No. of Female")]
        //[Required(ErrorMessage = "Please enter the required Female Volunteers")]
        public string EventFemaleNo { get; set; }
        [Display(Name = "State")]
        public string EventStateId { get; set; }
        [Display(Name = "Location")]
        public string EventLocationId { get; set; }

        [Display(Name = "Message")]
        public string RejectMessage { get; set; }

        public bool IsActive { get; set; }



        public ArrayList EventNivrittilist = new ArrayList();
        public ArrayList EventWorkshoplist = new ArrayList();
        public ArrayList EventGitalist = new ArrayList();
        public ArrayList VolunteerEventList = new ArrayList();
        public ArrayList ChapterList = new ArrayList();
        public List<SelectListItem> List = new List<SelectListItem>();
        public List<SelectListItem> StateList = new List<SelectListItem>();
        public List<SelectListItem> LocationList = new List<SelectListItem>();

        /***************************************
         * Title :: Add Event Calender
         * Description :: this module use for collect list of Master Event Type Data(e.g - Nivritty Gurukul, Workshop)
         * Param :: none
         * Return :: Event list type.
         **************************************/
        public string AddEventCalender(EventManagement data, int createdby = 0)
        {
            //@START_DATE,@END_DATE,@YEAR,@MONTH,@EXPIRED_ON,@EVENT_TYPE,@MALE,@FEMALE,@ISACTIVE,@CREATED_BY
            //{"EVENT_ID":"","START_DATE":"","END_DATE":"","EXPIRE_DATE":"","NO_OF_MALE":"","NO_OF_FEMALE":"","LOCATION_ID":"","STATE_ID":"","YEAR":"","MONTH":"","STATUS":""}
            string _response = string.Empty,
                   _endDate = string.Empty,
                   _enddate = string.Empty,
                   _expiredate = string.Empty;
            int _eventid = 0,
                _male_no = 0,
                _female_no = 0,
                _stateid = 0,
                _locationid = 0,
                _year = 0,
                _month = 0,
                _isactive = 0;
            SortedList<string, object> _data = new SortedList<string, object>();

            _eventid = Convert.ToInt32(data.EventId);
            _endDate = data.EventStartDate;
            _enddate = data.EventEndDate;
            _expiredate = data.EventExpireDate;
            _male_no = Convert.ToInt32(data.EventMaleNo);
            _female_no = Convert.ToInt32(data.EventFemaleNo);
            _isactive = data.IsActive ? 1 : 0;
            DateTime s_date = Convert.ToDateTime(_endDate);
            _month = s_date.Month;
            _year = s_date.Year;

            // Ready Array
            _data.Add("EVENT_ID", _eventid);
            _data.Add("USER_ID", createdby);
            _data.Add("START_DATE", _endDate);
            _data.Add("END_DATE", _enddate);
            _data.Add("EXPIRE_DATE", _expiredate);
            _data.Add("NO_OF_MALE", _male_no);
            _data.Add("NO_OF_FEMALE", _female_no);
            _data.Add("YEAR", _year);
            _data.Add("MONTH", _month);
            _data.Add("STATUS", _isactive);

            if (_eventid == 2)
            {
                _stateid = Convert.ToInt32(data.EventStateId);
                _data.Add("STATE_ID", _stateid);
            }
            else if (_eventid == 3)
            {
                _stateid = Convert.ToInt32(data.EventStateId);
                _locationid = Convert.ToInt32(data.EventLocationId);
                _data.Add("STATE_ID", _stateid);
                _data.Add("LOCATION_ID", _locationid);
            }

            RestClient _client = new RestClient();
            _client.URL = Constant.ADD_EVENT_CALENDER;
            _client.Method = HttpMethod.POST;
            _client.Content = Json.Encode(_data);
            _client.Type = ContentType.URLENCODE;
            _client.Execute();
            _response = _client.Response();
            return _response;
        }
        /***************************************
         * Title :: Get Event Master Type
         * Description :: this module use for collect list of Master Event Type Data(e.g - Nivritty Gurukul, Workshop)
         * Param :: none
         * Return :: Event list type.
         **************************************/
        public string GetEventMasterType()
        {
            string _response = string.Empty;
            RestClient _client = new RestClient();
            _client.URL = Constant.GET_EVENT_MASTER_TYPE;
            _client.Method = HttpMethod.GET;
            _client.Execute();
            _response = _client.Response();
            return _response;
        }
        /***************************************
         * Title :: Get Event Calender Data
         * Description :: this module use for collect event list through event id
         * Param :: event id
         * Return :: Event data.
         **************************************/
        public string GetEventData(int EventId = 0)
        {
            string _response = string.Empty;
            if (EventId > 0)
            {

                string _URL = Constant.GET_EVENT_DATA + "?eventid=" + EventId + "&isactive=1,0";
                RestClient _client = new RestClient();
                _client.URL = _URL;
                _client.Method = HttpMethod.GET;
                _client.Execute();
                _response = _client.Response();
            }
            return _response;
        }
        /***************************************
         * Title :: Get State Data
         * Description :: this module use for collect state
         * Param :: none
         * Return :: State data.
         **************************************/
        public string GetEventData()
        {
            string _response = string.Empty;
            RestClient _client = new RestClient();
            _client.URL = Constant.GET_MASTER_STATE_DATA;
            _client.Method = HttpMethod.GET;
            _client.Execute();
            _response = _client.Response();
            return _response;
        }
        /***************************************
         * Title :: Get Volunteer Event Data
         * Description :: this module use for collect volunteer event registration list
         * Param :: none
         * Return :: Volunteer Event Data
         **************************************/
        public string GetVolunteerEventRegData()
        {
            string _response = string.Empty;
            string _URL = Constant.GET_VOLUNTER_EVENT_DATA;
            RestClient _client = new RestClient();
            _client.URL = _URL;
            _client.Method = HttpMethod.GET;
            _client.Execute();
            _response = _client.Response();
            return _response;
        }
        /***************************************
         * Title :: Approve Volunteer Event Registration Data
         * Description :: this module use for Volunteer Event Rejection
         * Param :: 
         * Return :: Response data
         **************************************/
        public string ApproveVolunteerEventRegData(string eventid, string status, int sessionUserId)
        {
            string _response = string.Empty;
            SortedList<string, object> _list = new SortedList<string, object>();
            _list.Add("USER_ID", sessionUserId);
            _list.Add("EVENT_ID", eventid);
            _list.Add("STATUS", status);

            RestClient _client = new RestClient();
            _client.URL = Constant.VOLUNTER_EVENT_DATA_ACTION;
            _client.Method = HttpMethod.PUT;
            _client.Content = Json.Encode(_list);
            _client.Execute();
            _response = _client.Response();

            return _response;
        }
        /***************************************
         * Title :: Reject Volunteer Event Registration Data
         * Description :: this module use for Volunteer Event Rejection
         * Param :: 
         * Return :: Response data
         **************************************/
        public string RejectionVolunteerEventRegData(string eventid, string status, string message, int sessionUserId)
        {
            string _response = string.Empty;
            SortedList<string, object> _list = new SortedList<string, object>();
            _list.Add("USER_ID", sessionUserId);
            _list.Add("EVENT_ID", eventid);
            _list.Add("STATUS", status);
            _list.Add("MESSAGE", message);

            RestClient _client = new RestClient();
            _client.URL = Constant.VOLUNTER_EVENT_DATA_ACTION;
            _client.Method = HttpMethod.PUT;
            _client.Content = Json.Encode(_list);
            _client.Execute();
            _response = _client.Response();

            return _response;
        }
        /***************************************
         * Title :: Approve Event Calender Data
         * Description :: this module use for Volunteer Event Rejection
         * Param :: 
         * Return :: Response data
         **************************************/
        public string ApproveEventCalender(int calendertid, int sessionUserId)
        {
            string _response = string.Empty;
            SortedList<string, object> _list = new SortedList<string, object>();
            _list.Add("USER_ID", sessionUserId);
            _list.Add("EVENT_ID", calendertid);

            RestClient _client = new RestClient();
            _client.URL = Constant.APPROVE_EVENT_CALENDER;
            _client.Method = HttpMethod.PUT;
            _client.Content = Json.Encode(_list);
            _client.Execute();
            _response = _client.Response();

            return _response;
        }
        public DataTable Get_required_volunteer(string event_id)
        {//EXEC dbo.USP_EVENT_MANAGEMENT  @OPERATIONID=19,@EVENT_SYS_ID = 2
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {
                new SqlParameter("@OPERATIONID",19) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@EVENT_SYS_ID", event_id) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable Get_event_date(string event_id)
        {//EXEC dbo.USP_EVENT_MANAGEMENT  @OPERATIONID=20,@EVENT_SYS_ID =9
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {
                new SqlParameter("@OPERATIONID",20) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@EVENT_SYS_ID", event_id) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }

    }
}