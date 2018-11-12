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
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=7,@JSON=''
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

        public DataTable Get_Event_Volunteer_Reg_Data(string Status = null)
        {
            _dtable = new DataTable();
            _param = new SqlParameter[]
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=9
                new SqlParameter("@OPERATIONID",9) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@V_STATUS",Status) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

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
            {//EXEC dbo.USP_EVENT_MANAGEMENT @OPERATION_ID=10
                new SqlParameter("@OPERATIONID",12) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                 new SqlParameter("@JSON", jsondata) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }

            };
            _dtable = _dbObj.Select("USP_EVENT_MANAGEMENT", _param);
            return _dtable;
        }
    }

}