using System.Web.Configuration;

namespace GurukulAppAdminPanel.App_Start
{
    public class Constant
    {
        // Public Constant
        internal static string PROJECT_NAME                                 = " :: JIVANMUKTAS";
 //internal static string BASEURL                                      = "http://gurukulweb.tangenttechsolutions.com/";
        internal static string BASEURL = WebConfigurationManager.AppSettings["BASEURL"];
        //internal static string BASEURL                                      = "http://localhost:58949/";        
        internal static string LOG_DIR_PATH                                 = "~/LogReport";
        internal static string LOG_FILE_PATH                                = "~/LogReport/_Log.txt";
        internal static string SERVER_PATH_PREFIX                           = "~/";
        internal static string UPLOAD_FILE                                  = "UploadedFile/";
        internal static string UPLOAD_IMAGE_RAW_FILE                        = "userphoto/";
        //internal static ulong MAX_FILE_SIZE                               = 5242880;  // 5 MB
        internal static string LOGOUT                                       = BASEURL + "logout";
        internal static string DASHBOARD                                    = BASEURL + "dashboard";
        internal static string ALREADY_EXISTS_MSG = "Data already exists.";
        internal static string EMPTY_DATA_MSG = "Data not available.";
        internal static string UNAUTH_ACCESS = "Unauthorised Access";
        internal static string API_BASEURL = "http://gurukulweb.tangenttechsolutions.com/";



        // Private Constant
        // Service URL
        //http://jivanmuktasapi.ttssupport.info/api/
        //private static string _SERVICE_BASEURL = "http://gurukulweb.tangenttechsolutions.com/";
        private static string _SERVICE_BASEURL                              = "http://jivanmuktas.tangenttechsolutions.com/gurukul_app_services.svc/";
        //private static string _SERVICE_BASEURL                              = "http://localhost:36787/Gurukul_App_Services.svc/";        
        internal static string LOGIN                                        = _SERVICE_BASEURL + "user-login";
        internal static string GET_VOLUNTEER_DATA                           = _SERVICE_BASEURL + "get-volunteer-data";
        internal static string USER_APPROVE                                 = _SERVICE_BASEURL + "user-approve";
        internal static string USER_REJECT                                  = _SERVICE_BASEURL + "user-reject";
        internal static string USER_DELETE                                  = _SERVICE_BASEURL + "user-delete";
        internal static string GET_USER_PROFILE_DATA                        = _SERVICE_BASEURL + "get-user-profile";
        internal static string GET_EVENT_DATA                               = _SERVICE_BASEURL + "get-event-data";
        internal static string GET_EVENT_MASTER_TYPE                        = _SERVICE_BASEURL + "get-event-master-type";
        internal static string GET_VOLUNTER_EVENT_DATA                      = _SERVICE_BASEURL + "get-event-volunteer-reg-data";
        internal static string VOLUNTER_EVENT_DATA_ACTION                   = _SERVICE_BASEURL + "update-volunteer-event-status";
        internal static string GET_MASTER_STATE_DATA                        = _SERVICE_BASEURL + "get-state-data";
        internal static string ADD_EVENT_CALENDER                           = _SERVICE_BASEURL + "add-event-calender";
        internal static string APPROVE_EVENT_CALENDER                       = _SERVICE_BASEURL + "approve-event-calender-status";
        internal static string GET_SATSANG_CHAPTER_DATA                     = _SERVICE_BASEURL + "get-satsang-chapter-data";
        internal static string GET_MASTER_COUNTRY_DATA                      = _SERVICE_BASEURL + "get-country-list";
        internal static string ADD_SATSANG_CHAPTER_DATA                     = _SERVICE_BASEURL + "add-satsang-chapter-data";

    }
}