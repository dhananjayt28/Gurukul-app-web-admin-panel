namespace GurukulAppAdminPanel.Models
{
    using GurukulAppAdminPanel.App_Start;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Helpers;
    using RestClient;
    using System.Data;
    using System.Data.SqlClient;
    using System;
    public class UserManagement
    {
        public ArrayList UserData = new ArrayList();
        private DataTable _dtable;

        

        /*********************************
         * Title :: CollectUserData
         * Description :: Collect user data for list all user
         * Parameter :: none
         * Return :: JSON
         *********************************/
        public string CollectUserDataOnLoad(string User_id=null,string Status=null,string Role=null)
        {
            string _jsonString = string.Empty;
            //RestClient _client = new RestClient();
            //_client.URL = Constant.GET_VOLUNTEER_DATA;
            //_client.Method = HttpMethod.GET;
            //_client.Execute();
            //_response = _client.Response();
            //return _response;
            MasterManagement _MM = new MasterManagement();
            _MM = new MasterManagement();
            _dtable = new DataTable();
            _dtable = _MM.View_User_Data(User_id, Status, Role);


            if (_dtable.Rows.Count > 0)
            {
                _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
               // response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                _jsonString = Data.DatatableEmpty();
                //response = this.Request.CreateResponse(HttpStatusCode.OK);
            }
            return _jsonString;
        }
        public string CollectUserData()
        {
            string _response = string.Empty;
            RestClient _client = new RestClient();
            _client.URL = Constant.GET_VOLUNTEER_DATA;
            _client.Method = HttpMethod.GET;
            _client.Execute();
            _response = _client.Response();
            return _response;
        }

        /*********************************
         * Title :: User Approve Action
         * Description :: 
         * Parameter :: UserId
         * Return :: JSON
         *********************************/
        public string UserApproveAction(int UserId = 0)
        {
            if(UserId > 0)
            {
                string _response = string.Empty;
                SortedList<string, object> _list = new SortedList<string, object>();
                _list.Add("USER_ID", UserId);
                RestClient _client = new RestClient();
                _client.URL = Constant.USER_APPROVE;
                _client.Method = HttpMethod.PUT;
                _client.Content = Json.Encode(_list);
                _client.Execute();
                _response = _client.Response();
                return _response;
            }
            else
            {
                return string.Empty;
            }
            
        }

        /*********************************
         * Title :: User Reject Action
         * Description :: 
         * Parameter :: UserId
         * Return :: JSON
         *********************************/
        public string UserRejectAction(int UserId = 0)
        {
            if (UserId > 0)
            {
                string _response = string.Empty;
                SortedList<string, object> _list = new SortedList<string, object>();
                _list.Add("USER_ID", UserId);
                RestClient _client = new RestClient();
                _client.URL = Constant.USER_REJECT;
                _client.Method = HttpMethod.PUT;
                _client.Content = Json.Encode(_list);
                _client.Execute();
                _response = _client.Response();
                if(_response == string.Empty)
                {
                    _response = _client.errordata();
                    if(_response == string.Empty)
                    {
                        _response = _client.exceptiondata();
                    }
                }
                return _response;
            }
            else
            {
                return string.Empty;
            }

        }
        /*********************************
         * Title :: User Reject Action
         * Description :: 
         * Parameter :: UserId
         * Return :: JSON
         *********************************/
        public string UserDeleteAction(int UserId = 0)
        {
            if (UserId > 0)
            {
                string _response = string.Empty;
                SortedList<string, object> _list = new SortedList<string, object>();
                _list.Add("USER_ID", UserId);
                RestClient _client = new RestClient();
                _client.URL = Constant.USER_DELETE;
                _client.Method = HttpMethod.DELETE;
                _client.Content = Json.Encode(_list);
                _client.Execute();
                _response = _client.Response();
                if(_response == string.Empty)
                {
                    _response = _client.errordata();
                    if(_response == string.Empty)
                    {
                        _response = _client.exceptiondata();
                    }
                }
                return _response;
            }
            else
            {
                return string.Empty;
            }

        }

        public string UserProfileDataByUserId(int UserId)
        {
            string _response = string.Empty;
            RestClient _client = new RestClient();
            _client.URL = Constant.GET_USER_PROFILE_DATA + "?id=" + UserId + "&t=web";
            _client.Method = HttpMethod.GET;
            _client.Execute();
            _response = _client.Response();
            if (_response == string.Empty)
            {
                _response = _client.errordata();
                if (_response == string.Empty)
                {
                    _response = _client.exceptiondata();
                }
            }
            return _response;
        }
    }
    public class UpdateBusinessProfile
    {
        public string hide_user_id { get; set; }
        public string bp_dd { get; set; }
    }
}