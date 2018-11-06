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
        private DatabaseManagement _dbObj = new DatabaseManagement("ConnectDB");
        private DataTable _dtObj;
        private SqlParameter[] _param;

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name shoud be required.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password shoud be required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string LoginAction(AuthenticateManagement authData)
        {
            string _user_name = string.Empty, _password = string.Empty;
            bool _isadmin = true;
            _user_name = authData.UserName;
            _password = authData.Password;
            // Initialize Post Data
            //{"USER_ID":"admin@gurukul.com","PASSWORD":"Abc@123","IS_ADMIN":true}
            SortedList<string, object> _postArrData = new SortedList<string, object>();
            _postArrData.Add("USER_ID", _user_name);
            _postArrData.Add("PASSWORD", _password);
            _postArrData.Add("IS_ADMIN", _isadmin);

            var _postContent = Json.Encode(_postArrData);
            RestClient _client = new RestClient();
            _client.URL = Constant.LOGIN;
            _client.Method = HttpMethod.POST;
            _client.Content = _postContent;
            _client.Type = ContentType.URLENCODE;
            _client.Execute();
            var response = _client.Response();
            if (response == string.Empty)
            {
                response = _client.errordata();
            }
            return response;
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

        
