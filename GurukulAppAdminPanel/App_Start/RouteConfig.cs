﻿using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace GurukulAppAdminPanel.App_Start
{
    public class RouteConfig
    {
        public static void Configure(RouteCollection routes)
        {//UserStatusUpdate
            routes.MapRoute(
            name: "UserStatusUpdate",
            url: "user/update-status/{userid}/{status}",
            defaults: new { controller = "User", action = "UserStatusUpdate", userid = UrlParameter.Optional ,status =UrlParameter.Optional}
       );
            routes.MapRoute(
            name: "DeleteIAS",
            url: "ias/delete-ias",
            defaults: new { controller = "IAScoaching", action = "DeleteIAS" }
       );
            routes.MapRoute(
             name: "UpdateBusinessProfile",
             url: "user/update-bp",
             defaults: new { controller = "User", action = "UpdateBusinessProfile" }
        );
            routes.MapRoute(
             name: "GetEvent",
             url: "event/get-event",
             defaults: new { controller = "Event", action = "GetEvent" }
        );
            routes.MapRoute(
              name: "GetStatus",
              url: "user/get-status",
              defaults: new { controller = "User", action = "GetStatus" }
         );
            routes.MapRoute(
              name: "GetRecordDetails",
              url: "iascoaching/get-record",
              defaults: new { controller = "IAScoaching", action = "GetRecordDetails" }
         );
            routes.MapRoute(
              name: "UpdateIasCoaching",
              url: "iascoaching/update-ias",
              defaults: new { controller = "IAScoaching", action = "UpdateIasCoaching" }
         );
            routes.MapRoute(
              name: "GetIasDetails",
              url: "iascoaching/get-ias",
              defaults: new { controller = "IAScoaching", action = "GetIasDetails" }
         );
            routes.MapRoute(
              name: "AddIasCoaching",
              url: "iascoaching/add-ias",
              defaults: new { controller = "IAScoaching", action = "AddIasCoaching" }
         );
            routes.MapRoute(
              name: "GetBusinessProfile",
              url: "iascoaching/get-bp",
              defaults: new { controller = "IAScoaching", action = "GetBusinessProfile" }
         );
            routes.MapRoute(
              name: "GetSubject",
              url: "iascoaching/get-subject",
              defaults: new { controller = "IAScoaching", action = "GetSubject" }
         );
            routes.MapRoute(
              name: "AddSubCategory",
              url: "master/add-sub-category",
              defaults: new { controller = "MasterManagement", action = "AddSubCategory" }
         );
            routes.MapRoute(
               name: "IasCoaching",
               url: "iascoaching/iascoaching",
               defaults: new { controller = "IAScoaching", action = "Index"}
          );
            routes.MapRoute(
                name: "GetListDataList",
                url: "master/get-list/{category_name}",
                defaults: new { controller = "MasterManagement", action = "GetListDataList", category_name = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "GetMasterDataList",
                url: "master/get-master/{eventid}",
                defaults: new { controller = "MasterManagement", action = "GetMasterDataList", eventid = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "AddCategory",
                url: "master/add-category",
                defaults: new { controller = "MasterManagement", action = "AddCategory" }
           );
            routes.MapRoute(
                name: "ViewMaster",
                url: "master/view-master",
                defaults: new { controller = "MasterManagement", action = "ViewMaster"}
            );
            routes.MapRoute(
                name: "GenExcel",
                url: "event/gen-excel/{eventid}",
                defaults: new { controller = "Event", action = "GenExcel", eventid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "GetEventCalendar",
                url: "event/event-calendar/{eventid}",
                defaults: new { controller = "Event", action = "GetEventCalendar", eventid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Chapter List",
                url: "chapter/chapter-list",
                defaults: new { controller = "Event", action = "SatsangChapterList" }
            );
            routes.MapRoute(
                name: "Chapter Add",
                url: "chapter/chapter-add",
                defaults: new { controller = "Event", action = "AddSatsangChapter" }
            );
            routes.MapRoute(
                name: "Event Add",
                url: "event/event-add",
                defaults: new { controller = "Event", action = "Index" }
            );
            routes.MapRoute(
                name: "Event List",
                url: "event/event-list/{eventid}",
                defaults: new { controller = "Event", action = "EventList", eventid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Volunteer Event Registration List",
                url: "event/volunteer-event-reg-list",
                defaults: new { controller = "Event", action = "VolunteerEventList" }
            );
            routes.MapRoute(
                name: "Event Approve Action",
                url: "event/approve-event-calender/{calenderid}",
                defaults: new { controller = "Event", action = "EventCalenderApprove", calenderid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Volunteer Event Approved",
                url: "event/volunteer-event-approved/{_statusVal}/{_event_reg_id}",
                defaults: new { controller = "Event", action = "VolunteerEventApprove", urldata = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User Profile Data",
                url: "user/user-profile-data/{userid}",
                defaults: new { controller = "User", action = "GetUserProfileData", userid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User Delete",
                url: "user/user-delete/{userid}",
                defaults: new { controller = "User", action = "UserDelete", userid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User Reject",
                url: "user/user-reject/{userid}",
                defaults: new { controller = "User", action = "UserReject", userid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User Approve",
                url: "user/user-approve/{userid}",
                defaults: new { controller = "User", action = "UserApprove", userid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Add User",
                url: "user/add-user",
                defaults: new { controller = "User", action = "Index" }
            );
            routes.MapRoute(
                name: "UserList",
                url: "user/user-list",
                defaults: new { controller = "User", action = "UserList" }
            );
            routes.MapRoute(
                name: "Dashboard",
                url: "dashboard/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Logout",
               url: "logout/{id}",
               defaults: new { controller = "Login", action = "Logout", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}