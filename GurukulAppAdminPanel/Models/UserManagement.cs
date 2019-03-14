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
    using System.Web.Script.Serialization;
    using DatabaseManagementClient;

    public class UserManagement
    {
        private DatabaseManagement _dbObj = new DatabaseManagement("ConnectDB");
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
            //RestClient _client = new RestClient();
            //_client.URL = Constant.GET_VOLUNTEER_DATA;
            //_client.Method = HttpMethod.GET;
            //_client.Execute();
            //_response = _client.Response();
            Dictionary<string, object> _MainArr = new Dictionary<string, object>();
            JavaScriptSerializer _JSObj = new JavaScriptSerializer();
            bool _Status = true;
            if (AllUserData().Rows.Count > 0)
            {             
              
                List<Dictionary<string, object>> _parentArr = new List<Dictionary<string, object>>();
                Dictionary<string, object> _childArr;
                foreach (DataRow row in AllUserData().Rows)
                {
                    _childArr = new Dictionary<string, object>();
                    foreach (DataColumn column in AllUserData().Columns)
                    {
                        _childArr.Add(column.ColumnName, row[column]);
                    }
                    _parentArr.Add(_childArr);
                }
                _MainArr.Add("status", _Status);
                _MainArr.Add("response", _parentArr);
            }
            else
            {
                _MainArr.Add("status", _Status);
                _MainArr.Add("response", "Data not found");
            }
            _response = _JSObj.Serialize(_MainArr);

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
            Dictionary<string, object> _MainArr = new Dictionary<string, object>();
            JavaScriptSerializer _JSObj = new JavaScriptSerializer();
            if (UserId > 0)
            {
                string _response = string.Empty;
                //SortedList<string, object> _list = new SortedList<string, object>();
                //_list.Add("USER_ID", UserId);
                //RestClient _client = new RestClient();
                //_client.URL = Constant.USER_APPROVE;
                //_client.Method = HttpMethod.PUT;
                //_client.Content = Json.Encode(_list);
                //_client.Execute();
                //_response = _client.Response();
                int _queryResponse = UserApprovedAction(UserId);
                if (_queryResponse > 0)
                {
                    _MainArr.Add("status", true);
                    _MainArr.Add("response", "Volunteer Appoved Successfully.");
                }
                else
                {
                    _MainArr.Add("status", false);
                    _MainArr.Add("response", "Volunteer Already Appoved.");
                }
                _response = _JSObj.Serialize(_MainArr);
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
            Dictionary<string, object> _MainArr = new Dictionary<string, object>();
            JavaScriptSerializer _JSObj = new JavaScriptSerializer();
            if (UserId > 0)
            {
                string _response = string.Empty;
                int _queryResponse = UserRejectedAction(UserId);
                if (_queryResponse > 0)
                {
                    _MainArr.Add("status", true);
                    _MainArr.Add("response", "Volunteer Rejected Successfully.");
                }
                else
                {
                    _MainArr.Add("status", false);
                    _MainArr.Add("response", "Volunteer Already Rejected.");
                }
                _response = _JSObj.Serialize(_MainArr);

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
            Dictionary<string, object> _MainArr = new Dictionary<string, object>();
            JavaScriptSerializer _JSObj = new JavaScriptSerializer();

            if (UserId > 0)
            {
                string _response = string.Empty;
                //SortedList<string, object> _list = new SortedList<string, object>();
                //_list.Add("USER_ID", UserId);
                //RestClient _client = new RestClient();
                //_client.URL = Constant.USER_DELETE;
                //_client.Method = HttpMethod.DELETE;
                //_client.Content = Json.Encode(_list);
                //_client.Execute();
                //_response = _client.Response();
                //if(_response == string.Empty)
                //{
                //    _response = _client.errordata();
                //    if(_response == string.Empty)
                //    {
                //        _response = _client.exceptiondata();
                //    }
                //}
                int _queryResponse = UserDelete(UserId);
                if (_queryResponse > 0)
                {
                    _MainArr.Add("status", true);
                    _MainArr.Add("response", "Volunteer Deleted Successfully.");
                }
                else
                {
                    _MainArr.Add("status", false);
                    _MainArr.Add("response", "Volunteer Already Deleted.");
                }
                _response = _JSObj.Serialize(_MainArr);
                return _response;
            }
            else
            {
                return string.Empty;
            }

        }

        public string UserProfileDataByUserId(int UserId)
        {
            Dictionary<string, object> _MainArr = new Dictionary<string, object>();
            JavaScriptSerializer _JSObj = new JavaScriptSerializer();
            string _response = string.Empty;
           bool _Status = true;
            //RestClient _client = new RestClient();
            //_client.URL = Constant.GET_USER_PROFILE_DATA + "?id=" + UserId + "&t=web";
            //_client.Method = HttpMethod.GET;
            //_client.Execute();
            //_response = _client.Response();
            //if (_response == string.Empty)
            //{
            //    _response = _client.errordata();
            //    if (_response == string.Empty)
            //    {
            //        _response = _client.exceptiondata();
            //    }
            //}
            if (CollectUserProfile(UserId).Rows.Count > 0)
            {
                
                List<Dictionary<string, object>> _parentArr = new List<Dictionary<string, object>>();
                Dictionary<string, object> _childArr;
                foreach (DataRow row in CollectUserProfile(UserId).Rows)
                {
                    _childArr = new Dictionary<string, object>();
                    foreach (DataColumn column in CollectUserProfile(UserId).Columns)
                    {
                        _childArr.Add(column.ColumnName, row[column]);
                    }
                    _parentArr.Add(_childArr);
                }
                _MainArr.Add("status", _Status);
                _MainArr.Add("response", _parentArr);
            }
            else
            {
                _MainArr.Add("status", _Status);
                _MainArr.Add("response", "Data not found");
            }
            _response = _JSObj.Serialize(_MainArr);
            return _response;
        }
        public DataTable AllUserData()
        {
            DataTable dt = new DataTable();
            //EXEC dbo.USP_USERS_MANAGEMENT @OPERATION_ID=1
            SqlParameter[] _Param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 1) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            dt = _dbObj.Select("USP_USERS_MANAGEMENT", _Param);
            return dt;
        }
        public Int32 UserApprovedAction(int UserId)
        {
            int _response = 0;
            //EXEC dbo.USP_AUTHENTICATE_MANAGEMENT @OPERATION_ID=10,@USER_ID = 3
            SqlParameter[] _Param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 10) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@USER_ID", UserId) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _response = _dbObj.Update("USP_AUTHENTICATE_MANAGEMENT", _Param);
            return _response;
        }
        public Int32 UserRejectedAction(int UserId)
        {
            int _response = 0;
            //EXEC dbo.USP_AUTHENTICATE_MANAGEMENT @OPERATION_ID=11,@USER_ID = 3
            SqlParameter[] _Param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 11) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@USER_ID", UserId) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _response = _dbObj.Update("USP_AUTHENTICATE_MANAGEMENT", _Param);
            return _response;
        }
        public Int32 UserDelete(int UserId)
        {
            int _response = 0;
            //EXEC dbo.USP_AUTHENTICATE_MANAGEMENT @OPERATION_ID=11,@USER_ID = 3
            SqlParameter[] _Param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 12) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@USER_ID", UserId) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _response = _dbObj.Update("USP_AUTHENTICATE_MANAGEMENT", _Param);
            return _response;
        }
        public DataTable CollectUserProfile(int UserId, string type = "app")
        {
            DataTable dt = new DataTable();
            //EXEC dbo.USP_USERS_MANAGEMENT @OPERATION_ID=3,@USER_ID = '1'
            if (UserId > 0)
            {
                SqlParameter[] _Param = new SqlParameter[] {
                   new SqlParameter("@OPERATION_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = 3 },
                   new SqlParameter("@USER_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = UserId },
                   new SqlParameter("@ACCESS_TYPE", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = type }
                };
                dt = _dbObj.Select("USP_USERS_MANAGEMENT", _Param);
            }
            return dt;
        }

    }
    public class UpdateBusinessProfile
    {
        public string hide_user_id { get; set; }
        public string bp_dd { get; set; }
    }
}