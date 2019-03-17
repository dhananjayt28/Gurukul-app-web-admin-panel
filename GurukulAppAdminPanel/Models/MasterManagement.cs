using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DatabaseManagementClient;

namespace GurukulAppAdminPanel.Models
{
    public class MasterManagement
    {
        private DatabaseManagement _dbObj = new DatabaseManagement("ConnectDB");
        private DataTable _dtable;
        private SqlParameter[] _param;
        public string CATEGORYID { get; set; }
        public string DELETESUBCATEGORYID { get; set; }
        public string ADDCATEGORY { get; set; }
        public string ADDSUBCATEGORY { get; set; }


        public DataTable View_Master_List(String category_name)
        {//EXEC [dbo].[USP_GET_ALL_MASTER_DATA] @OPERATIONID=1,@V_CATEGORY_NAME
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {
                new SqlParameter("@OPERATIONID",1) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@V_CATEGORY_NAME", category_name) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_GET_ALL_MASTER_DATA", _param);
            return _dtable;
        }
        public DataTable Add_master_Data(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {
                new SqlParameter("@OPERATIONID",1) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_POST_ALL_MASTER_DATA", _param);
            return _dtable;
        }
        public DataTable Delete_sub_category(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {
                new SqlParameter("@OPERATIONID",5) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_POST_ALL_MASTER_DATA", _param);
            return _dtable;
        }
        public DataTable Add_sub_category(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {
                new SqlParameter("@OPERATIONID",2) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_POST_ALL_MASTER_DATA", _param);
            return _dtable;
        }
        public DataTable View_Parent_Master_List()
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {
                new SqlParameter("@OPERATIONID",2) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
                //new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_GET_ALL_MASTER_DATA", _param);
            return _dtable;
        }
        public DataTable Add_coaching_detail(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATIONID=21,@JSON
                new SqlParameter("@OPERATIONID",21) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable Update_coaching_detail(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATIONID=21,@JSON
                new SqlParameter("@OPERATIONID",22) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable View_Coaching_Detail_List()
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATIONID=21,@JSON
                new SqlParameter("@OPERATIONID",23) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
                //new SqlParameter("@RECORD_SYS_ID", Record_id) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable View_Coaching_Detail(string Record_id)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATIONID=24,@JSON
                new SqlParameter("@OPERATIONID",24) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@RECORD_SYS_ID", Record_id) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable View_User_Data(string User_id, string Status, string Role)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_USERS_MANAGEMENT @OPERATION_ID=4,@V_Status
                new SqlParameter("@OPERATION_ID",4) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@USER_ID",User_id) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@V_Role",Role) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
                new SqlParameter("@V_Status",Status) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_USERS_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable View_Registered_Event_Data(string Event_id)
        {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATIONID=25,@EVENT_SYS_ID=1
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {
                new SqlParameter("@OPERATIONID",25) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@EVENT_REG_ID",Event_id) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable Update_user_profile(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_USERS_MANAGEMENT @OPERATION_ID=5,@JSON ='[{"USER_ID":12,"ROLE_ID":6}]'
                new SqlParameter("@OPERATION_ID",5) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_USERS_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable Delete_Coaching_detail_Data(string Record_ld)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATIONID=26,@RECORD_SYS_ID=11  
                new SqlParameter("@OPERATIONID",26) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@RECORD_SYS_ID", Record_ld) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable Update_user_status(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_USERS_MANAGEMENT @OPERATION_ID=6
                new SqlParameter("@OPERATION_ID",6) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_USERS_MANAGEMENT", _param);
            return _dtable;
        }

        public DataTable event_registration(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=2
                new SqlParameter("@OPERATIONID",2) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }

        public DataTable update_event_data(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=2,@JSON=''
                new SqlParameter("@OPERATIONID",6) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }

        public DataTable View_Approved_Event_Data(string user_id)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=7,@USER_ID=''
                new SqlParameter("@OPERATIONID",7) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@USER_ID", user_id) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }

        public DataTable View_Rejected_Event_Data(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=8,@JSON=''
                new SqlParameter("@OPERATIONID",8) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@USER_ID", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }

        public DataTable Get_Event_Volunteer_Reg_Data(string Status = null,string etype=null)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=9
                new SqlParameter("@OPERATIONID",9) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@V_STATUS",Status) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
                new SqlParameter("@V_TYPE",etype) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable VolunteerRegisterEventAction(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=10
                new SqlParameter("@OPERATIONID", 10) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                 new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
                //new SqlParameter("@STATUS", Status) { SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input },
                //new SqlParameter("@MESSAGE", Message) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
                //new SqlParameter("@USER_ID", UserID) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                //new SqlParameter("@EVENT_ID", EventId) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable TopicContent(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=10
                new SqlParameter("@OPERATIONID", 16) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                 new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
               
            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable VolunteerEventRejectAction(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=10
                new SqlParameter("@OPERATIONID",10) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                 new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
                //new SqlParameter("@STATUS", Status) { SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input },
                //new SqlParameter("@MESSAGE", Message) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
                //new SqlParameter("@USER_ID", UserID) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                //new SqlParameter("@EVENT_ID", EventId) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }

        public DataTable Volunteer_Event_Checkinout_Update(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=10
                new SqlParameter("@OPERATIONID",6) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                 new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }
                
            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        public DataTable Volunteer_Event_Cancel(string jsondata)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {
                new SqlParameter("@OPERATIONID",12) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                 new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
        //Login Operation ID call
        public DataTable Login(string jsondata)
        {
            DataTable dt;
            //EXEC dbo.USP_AUTHENTICATE_MANAGEMENT @OPERATION_ID=1, @USER_ID='jayanta@tangenttechsolutions.com', @PASSWORD='215023'
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 1) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }
               
            };

            dt = _dbObj.Select("USP_AUTHENTICATE_MANAGEMENT", _param);

            return dt;
        }
        public DataTable Admin_Login(string jsondata)
        {
            DataTable dt;
            //EXEC dbo.USP_AUTHENTICATE_MANAGEMENT @OPERATION_ID=1, @USER_ID='jayanta@tangenttechsolutions.com', @PASSWORD='215023'
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 2) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_AUTHENTICATE_MANAGEMENT", _param);

            return dt;
        }
        public DataTable Itinary_Confirmation_Update(string jsondata)
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATIONID=28, @JSON='[{"ID_CARD_TYPE":92,"TRANSPORTAION_ARRANGEMENT":"YES","ACCOMODATION_ARRANGEMENT":"YES","EVENT_REG_ID":7,"USER_ID":51}]'
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 28) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);

            return dt;
        }
        //not done currently
        public DataTable Itinary_Status_Update(string jsondata)
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=26, @JSON=[{"EVENT_REG_ID":"","STATUS_ID":"","HOD_COMMENT":""}]''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 00) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);

            return dt;
        }
        public DataTable user_registration(string jsondata)
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=26, @JSON=[{"EVENT_REG_ID":"","STATUS_ID":"","HOD_COMMENT":""}]''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 4) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_AUTHENTICATE_MANAGEMENT", _param);

            return dt;
        }
        public DataTable user_update(string jsondata)
        {
            DataTable dt;
            //EXEC dbo.USP_USERS_MANAGEMENT @OPERATION_ID = 2,@JSON=
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 2) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_USERS_MANAGEMENT", _param);

            return dt;
        }
        public DataTable UpdateItineraryStatus(string jsondata)
        {
            DataTable dt;
            //--## EXEC dbo.USP_EVENT_MANAGEMENT @OPERATIONID=31,@JSON=[{"EVENT_REG_SYS_ID":"7","ITINERARY_STATUS":"95","ITINERARY_COMMENTS":"GOOD"}]
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 31) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);

            return dt;
        }
        /*************************************
         * Title :: User Approved by Admin
         * Description :: Fetch Data method using Procedure name by Opeation Id
         * Parameter :: UserId,Value
         * Return :: row affected count
         *************************************/
        public DataTable UserApprovedAction(string jsondata)
        {
            int _response = 0;
            _dtable = new DataTable();
            //EXEC dbo.USP_AUTHENTICATE_MANAGEMENT @OPERATION_ID=10,@USER_ID = 3
            SqlParameter[] _Param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 10) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _dtable = _dbObj.Select("USP_AUTHENTICATE_MANAGEMENT", _Param);
            return _dtable;
        }
        /*************************************
         * Title :: User Rejected by Admin
         * Description :: Fetch Data method using Procedure name by Opeation Id
         * Parameter :: UserId,Value
         * Return :: row affected count
         *************************************/
        public DataTable UserRejectedAction(string jsondata)
        {
            int _response = 0;
            _dtable = new DataTable();
            //EXEC dbo.USP_AUTHENTICATE_MANAGEMENT @OPERATION_ID=11,@USER_ID = 3
            SqlParameter[] _Param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 11) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _dtable = _dbObj.Select("USP_AUTHENTICATE_MANAGEMENT", _Param);
            return _dtable;
        }
        /*************************************
         * Title :: User Rejected by Admin
         * Description :: Fetch Data method using Procedure name by Opeation Id
         * Parameter :: UserId,Value
         * Return :: row affected count
         *************************************/
        public DataTable UserDeleteAction(string jsondata)
        {
            int _response = 0;
            _dtable = new DataTable();
            //EXEC dbo.USP_AUTHENTICATE_MANAGEMENT @OPERATION_ID=11,@USER_ID = 3
            SqlParameter[] _Param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 12) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _dtable = _dbObj.Select("USP_AUTHENTICATE_MANAGEMENT", _Param);
            return _dtable;
        }
        //get-event-master-type
        public DataTable GetEventMasterType()
        {
            //EXEC dbo.USP_MASTER_MANAGEMENT @OPERATIONID=2 
            DataTable _datatable;
            _datatable = new DataTable();
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 2) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _datatable = _dbObj.Select("USP_MASTER_MANAGEMENT", _param);
            return _datatable;
        }
        //get-state-data
        public DataTable GetStateData()
        {
            //EXEC dbo.USP_MASTER_MANAGEMENT @OPERATIONID=5
            DataTable _datatable;
            _datatable = new DataTable();
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 5) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _datatable = _dbObj.Select("USP_MASTER_MANAGEMENT", _param);
            return _datatable;
        }
        //get-country-list
        public DataTable GetCountryData()
        {
            //EXEC dbo.USP_MASTER_MANAGEMENT @OPERATIONID=7
            DataTable _datatable;
            _datatable = new DataTable();
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 7) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _datatable = _dbObj.Select("USP_MASTER_MANAGEMENT", _param);
            return _datatable;
        }
        public DataTable AddChapterData(string jsondata)
        {
           int  _queryResponse = 0;
           DataTable datatable = new DataTable();
            try
            {
                //EXEC dbo.USP_MASTER_MANAGEMENT @OPERATIONID=8, @CHAPTER_NAME = 'Manama', @CHAPTER_DESC='', @COUNTRYID = '1'
                SqlParameter[] _Param = new SqlParameter[] {
                    new SqlParameter("@OPERATIONID", 8) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                    new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
                    
                };
                datatable = _dbObj.Select("USP_MASTER_MANAGEMENT", _Param);
            }
            catch (SqlException ex)
            {
                string Msg = ex.Message.ToString();
            }
           
            return datatable;
        }
        public DataTable Topic_Status_Update(string jsondata)
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=27, @JSON='[{"TOPIC_ID":"","STATUS_ID":"","EVENT_REG_ID":"","HOD_COMMENT":""}]'
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 27) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);

            return dt;
        }
        //AddNewEventCalender
        public DataTable AddNewEvent(string jsondata)
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=27, @JSON=''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 1) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);

            return dt;
        }
        public DataTable Get_Event_Data(int event_type)
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=27, @JSON=''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 5) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@EVENT_TYPE", event_type) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);

            return dt;
        }
        public DataTable Upload_Itinerary(string  jsondata)
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=27, @JSON=''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 29) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);

            return dt;
        }

        public DataTable GetContent(string event_id_)
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=27, @JSON=''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 30) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@EVENT_REG_ID", event_id_) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }

            };

            dt = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);

            return dt;
        }
        public DataTable GetUserCount()
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=31, @JSON=''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 1) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
               

            };

            dt = _dbObj.Select("USP_DASHBOARD", _param);

            return dt;
        }
        public DataTable GetEventCount()
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=31, @JSON=''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 2) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }


            };

            dt = _dbObj.Select("USP_DASHBOARD", _param);

            return dt;
        }
        //Get City List in respect of Country
        public DataTable GetCityByCountry(string Country_id)
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=31, @JSON=''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 4) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@V_COUNTRY_ID", Country_id) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }


            };

            dt = _dbObj.Select("USP_GET_ALL_MASTER_DATA", _param);

            return dt;
        }
        public DataTable GetAllCity()
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=31, @JSON=''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 7) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
              
            };

            dt = _dbObj.Select("USP_GET_ALL_MASTER_DATA", _param);

            return dt;
        }
        //Get Country List in respect of Country
        public DataTable GetCountry()
        {
            DataTable dt;
            //EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=31, @JSON=''
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 3) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }               


            };

            dt = _dbObj.Select("USP_GET_ALL_MASTER_DATA", _param);

            return dt;
        }
        public DataTable GetSatsangChapterData(string country_id = "")
        {
            DataTable dt;
            // EXEC dbo.USP_MASTER_MANAGEMENT @OPERATIONID=6,@COUNTRYID='2'
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 6) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@COUNTRYID", country_id) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }
            };

            dt = _dbObj.Select("USP_MASTER_MANAGEMENT", _param);
            return dt;
        }

        public DataTable PasswordReset(string Userid)
        {
            //Int32 Status = 0;
            DataTable dt = new DataTable();
            //EXEC dbo.USP_AUTHENTICATE_MANAGEMENT @OPERATION_ID=5,@USER_ID='abc@gmail.com'
            SqlParameter[] _Param = new SqlParameter[] {
                new SqlParameter("@OPERATION_ID", 5) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@USER_ID", Userid) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
            };

            dt = _dbObj.Select("USP_AUTHENTICATE_MANAGEMENT", _Param);
            return dt;
            //return Status;
        }
        public DataTable GetItineraryInformation(string event_reg_id,string user_id)
        {
            //Int32 Status = 0;
            DataTable dt = new DataTable();
            //EXEC dbo.USP_AUTHENTICATE_MANAGEMENT @OPERATION_ID=5,@USER_ID='abc@gmail.com'
            SqlParameter[] _Param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 32) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@V_EVENT_REG_SYS_ID", event_reg_id) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@V_USER_ID", user_id) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
            };

            dt = _dbObj.Select("USP_EVENT_MANAGEMENT", _Param);
            return dt;
            //return Status;
        }
        public Int32 EventRegistrationCancel(int UserId, int EventId)
        {
            int _response = 0;
            // EXEC dbo.USP_EVENT_MANAGEMENT @OPERATIONID=12,@USER_ID=1,@EVENT_ID=8
            SqlParameter[] _param = new SqlParameter[]
            {
                new SqlParameter("@OPERATIONID", 12) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@USER_ID", UserId) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@EVENT_ID", EventId) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _response = _dbObj.Update("USP_EVENT_MANAGEMENT", _param);
            return _response;
        }
        /*************************************
       * Title :: Get Subject Data by Education Id method
       * Description :: Get Data from this method using Education ID
       * Parameter :: OperationId, id
       * Return :: Table data
       * Author - Sayan Chatterjee
       *************************************/
        public DataTable GetSubjectDatabyEducationId(string education_id="")
        {
            //EXEC dbo.USP_MASTER_MANAGEMENT @OPERATIONID = 4, @EDUCATION_ID = 2
           DataTable dt = new DataTable();
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 4) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@EDUCATION_ID", education_id) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            dt = _dbObj.Select("USP_MASTER_MANAGEMENT", _param);
            return dt;
        }




    }

}