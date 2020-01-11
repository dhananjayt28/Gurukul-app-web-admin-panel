namespace GurukulAppAdminPanel.Models
{
    using System.Collections.Generic;
    using System.Web.Helpers;
    using System.ComponentModel.DataAnnotations;
    using GurukulAppAdminPanel.App_Start;
    using RestClient;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using DatabaseManagementClient;

    public partial class AuthenticateManagement
    {
        private DataTable _dtable;
       // private Dictionary<string, object> errordata, dictionaryObj;
        private DatabaseManagement _dbObj = new DatabaseManagement("ConnectDB");
        private DataTable _dtObj;
        private SqlParameter[] _param;

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name should be required.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password should be required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string LoginAction(AuthenticateManagement authData)
        {
            string _jsonString = string.Empty;
            string _user_name = string.Empty, _password = string.Empty;
           // bool _isadmin = true;
            _user_name = authData.UserName;
            _password = authData.Password;
            // Initialize Post Data
            //{"USER_ID":"admin@gurukul.com","PASSWORD":"Abc@123","IS_ADMIN":true}
            SortedList<string, object> _postArrData = new SortedList<string, object>();
            _postArrData.Add("V_USER_NAME", _user_name);
            _postArrData.Add("V_PASSWORD", _password);
           // _postArrData.Add("IS_ADMIN", _isadmin);
           //role id is hardcode in backend

            var _postContent = Json.Encode(_postArrData);
            MasterManagement _mmob = new MasterManagement();
            _dtable = _mmob.Admin_Login(_postContent);


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

            //previous code which was  logging in with service 
            //RestClient _client = new RestClient();
            //_client.URL = Constant.LOGIN;
            //_client.Method = HttpMethod.POST;
            //_client.Content = _postContent;
            //_client.Type = ContentType.URLENCODE;
            //_client.Execute();
            //var response = _client.Response();
            //if (response == string.Empty)
            //{
            //    response = _client.errordata();
            //}
            return _jsonString;
        }

        public DataTable insert_patient(string requestdata)
        {
            _dtObj = new DataTable();
            _param = new SqlParameter[] {
               new SqlParameter("@OPERATION_ID",3) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
               new SqlParameter("@JSON", requestdata) {SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }
             };
            _dtObj = _dbObj.Select("USP_GENERAL_MANAGEMENT", _param);
            return _dtObj;

        }

        internal DataTable Fetch_IMMUNIZATION_name(int v)
        {
            _dtObj = new DataTable();
            _param = new SqlParameter[] {
               new SqlParameter("@OPERATION_ID",3) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

             };
            _dtObj = _dbObj.Select("USP_GENERAL_MANAGEMENT", _param);
            return _dtObj;
        }

        public DataTable Fetch_PATIENT_name(string pATIENT_SYS_ID)
        {
            //EXEC dbo.USP_GENERAL_MANAGEMENT @OPERATION_ID = 6, @PATIENT_SYS_ID = 4
            _dtObj = new DataTable();
            _param = new SqlParameter[] {
               new SqlParameter("@OPERATION_ID",6) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
               new SqlParameter("@PATIENT_SYS_ID", pATIENT_SYS_ID) {SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _dtObj = _dbObj.Select("USP_GENERAL_MANAGEMENT", _param);
            var abc = _dbObj.ErrorList();

            return _dtObj;
        }

        public DataTable Fetch_policy_name(int OperationId)
        {
            _dtObj = new DataTable();
            _param = new SqlParameter[] {
               new SqlParameter("@OPERATION_ID",OperationId) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },

             };
            _dtObj = _dbObj.Select("USP_GENERAL_MANAGEMENT", _param);
            return _dtObj;

        }

        public DataTable insert_person(string requestdata)
        {
            _dtObj = new DataTable();
            _param = new SqlParameter[] {
               new SqlParameter("@OPERATIONID",3) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
               new SqlParameter("@JSON", requestdata) {SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }
             };
            _dtObj = _dbObj.Select("USP_GENERAL_MANAGEMENT", _param);
            return _dtObj;

        }

        public DataTable Fetch_booster_name(int OperationId)
        {
            _dtObj = new DataTable();
            _param = new SqlParameter[] {
               new SqlParameter("@OPERATIONID",OperationId) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

             };
            _dtObj = _dbObj.Select("USP_GENERAL_MANAGEMENT", _param);
            return _dtObj;
        }

        internal DataTable Fetch_data_name(int OperationId)
        {
            _dtObj = new DataTable();
            _param = new SqlParameter[] {
               new SqlParameter("@OPERATION_ID",4) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
           };
            _dtObj = _dbObj.Select("USP_GENERAL_MANAGEMENT", _param);
            return _dtObj;
        }



        internal DataTable Fetch_persons3_name()
        {
            _dtObj = new DataTable();
            _param = new SqlParameter[] {
               new SqlParameter("@OPERATION_ID",4) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _dtObj = _dbObj.Select("USP_GENERAL_MANAGEMENT", _param);
            return _dtObj;
        }
    }
}

        
