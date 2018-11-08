﻿using System.Web.Http;

namespace GurukulAppAdminPanel.App_Start
{
    public class WebApiRoute
    {
        public static void Configure(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "",
            //    routeTemplate: "",
            //    defaults: new { Controller = "WebApi", Action = "" }
            //);
            config.Routes.MapHttpRoute(
              name: "UPDATE STATUS DATA ",
              routeTemplate: "api/update-user-status",
              defaults: new
              {
                  Controller = "WebApi",
                  Action = "Update_user_status",
              }
          );
            config.Routes.MapHttpRoute(
                name: "DELETE COACHING DETAIL DATA ",
                routeTemplate: "api/delete-coaching-detail/{Record_ld}",
                defaults: new
                {
                    Controller = "WebApi",
                    Action = "Delete_Coaching_detail_Data",
                    Record_ld = RouteParameter.Optional
                }
            );
            config.Routes.MapHttpRoute(
                name: "update USER PROFILE ",
                routeTemplate: "api/update-user-profile",
                defaults: new
                {
                    Controller = "WebApi",
                    Action = "Update_user_profile"
                }
            );
            config.Routes.MapHttpRoute(
                name: "SELECT REGISTERED EVENT DATA",
                routeTemplate: "api/get-registered-event-data/{Event_id}",
                defaults: new
                {
                    Controller = "WebApi",
                    Action = "View_Registered_Event_Data",
                    Event_id = RouteParameter.Optional

                }
            );
            config.Routes.MapHttpRoute(
               name: "SELECT USER DETAIL DATA",
               routeTemplate: "api/get-user-data/{User_id}/{Status}/{Role}",
               defaults: new
               {
                   Controller = "WebApi",
                   Action = "View_User_Data",
                   User_id = RouteParameter.Optional,
                   Status = RouteParameter.Optional,
                   Role = RouteParameter.Optional
               }
           );
            config.Routes.MapHttpRoute(
               name: "SELECT COACHING DETAIL DATA",
               routeTemplate: "api/get-coaching-detail-data",
               defaults: new { Controller = "WebApi", Action = "View_Coaching_Detail_List" }
           );

            config.Routes.MapHttpRoute(
                name: "UPDATE COACHING DETAIL DATA",
                routeTemplate: "api/update-coaching-detail",
                defaults: new { Controller = "WebApi", Action = "Update_coaching_detail" }
            );

            config.Routes.MapHttpRoute(
                name: "ADD COACHING DETAIL DATA",
                routeTemplate: "api/add-coaching-detail",
                defaults: new { Controller = "WebApi", Action = "Add_coaching_detail" }
            );
            config.Routes.MapHttpRoute(
                 name: "ADD PARENT MASTER DATA",
                 routeTemplate: "api/get-parent-master-data-list",
                 defaults: new { Controller = "WebApi", Action = "View_Parent_Master_List" }
             );

            config.Routes.MapHttpRoute(
                name: "ADD SUB CATEGORY DATA",
                routeTemplate: "api/add-sub-category",
                defaults: new { Controller = "WebApi", Action = "Add_sub_category" }
            );

            config.Routes.MapHttpRoute(
                name: "ADD MASTER DATA",
                routeTemplate: "api/add-master-category",
                defaults: new { Controller = "WebApi", Action = "Add_master_Data" }
            );


            config.Routes.MapHttpRoute(
                name: "VIEW MASTER DATA",
                routeTemplate: "api/get-master-data-list",
                defaults: new { Controller = "WebApi", Action = "View_Master_List", category_name = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
               name: "VIEW EVENT DATA",
               routeTemplate: "api/get-event-calendar-breakup-data",
               defaults: new { Controller = "WebApi", Action = "Get_event_date", event_id = RouteParameter.Optional }
           );
            config.Routes.MapHttpRoute(
                name: "VIEW REQUIRE VOLUNTEER",
                routeTemplate: "api/get-nivritti-require-volunteer/{event_id}",
                defaults: new { Controller = "WebApi", Action = "Get_required_volunteer", event_id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Abc",
                routeTemplate: "api/get-project-data/{PATIENT_SYS_ID}",
                defaults: new { Controller = "WebApi", Action = "GETPATIENT", PATIENT_SYS_ID = RouteParameter.Optional }
            );


        }
    }
}