using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using GurukulAppAdminPanel.Models;
using GurukulAppAdminPanel.App_Start;
using System.Collections;

using System.Net.Http.Headers;
using System.Web;

namespace GurukulAppAdminPanel.Controllers
{
    public class WebApiController : ApiController
    {
        private bool _Status = false;
        private string _jsonString = string.Empty;
        private dynamic response;
        private Dictionary<string, object> MainArray, data;
        private JavaScriptSerializer _JSObj = new JavaScriptSerializer();
        private SortedList<string, object> arrayData;
        private AuthenticateManagement _AMM;
        private EventManagement _EM;
        private DataTable _dtable;
        private Fetch_data _pmmodel;

        [HttpPost]
        [Route("api/immunization-insert")]
        public HttpResponseMessage patient_insert(HttpRequestMessage request)
        {
            try
            {
                var requestdata = request.Content.ReadAsStringAsync().Result;
                _AMM = new AuthenticateManagement();
                _dtable = _AMM.insert_patient(requestdata);
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception)
            {
                _jsonString = Data.DatatableEmpty();
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //[Route("api/get-patient-data")]//Deep
        public HttpResponseMessage GETPATIENT(string PATIENT_SYS_ID)
        {
            try
            {
                //var requestdata = request.Content.ReadAsStringAsync().Result;
                _AMM = new AuthenticateManagement();
                _dtable = new DataTable();
                _dtable = _AMM.Fetch_PATIENT_name(PATIENT_SYS_ID);
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception)
            {
                _jsonString = Data.DatatableEmpty();
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        [Route("api/project-insert")]
        public HttpResponseMessage project_insert(HttpRequestMessage request)
        {
            try
            {
                var requestdata = request.Content.ReadAsStringAsync().Result;
                _AMM = new AuthenticateManagement();
                _dtable = _AMM.insert_patient(requestdata);
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception)
            {
                _jsonString = Data.DatatableEmpty();
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }


        [HttpPost]
        [Route("api/project-upa")]
        public HttpResponseMessage genaral_upda(HttpRequestMessage request)
        {
            try
            {
                var requestdata = request.Content.ReadAsStringAsync().Result;
                _AMM = new AuthenticateManagement();
                _dtable = _AMM.insert_person(requestdata);
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception)
            {
                _jsonString = Data.DatatableEmpty();
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        [Route("api/project-insert")]
        public HttpResponseMessage genaral_insert(HttpRequestMessage request)
        {
            try
            {
                var requestdata = request.Content.ReadAsStringAsync().Result;
                _AMM = new AuthenticateManagement();
                _dtable = _AMM.insert_person(requestdata);
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception)
            {
                _jsonString = Data.DatatableEmpty();
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }

        //[HttpPost]
        //[Route("api/patient-insert")]
        //public HttpResponseMessage person_insert(HttpRequestMessage request)       
        //{
        //    try
        //    {
        //        var requestdata = request.Content.ReadAsStringAsync().Result;
        //        _AMM = new AuthenticateManagement();
        //        _dtable = _AMM.insert_person(requestdata);
        //        if (_dtable.Rows.Count > 0)
        //        {
        //            _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
        //            response = this.Request.CreateResponse(HttpStatusCode.OK);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _jsonString = Data.DatatableEmpty();
        //        response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
        //    }

        //    response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
        //    return response;
        //}






        [HttpGet]
        //[Route("api/get-persons3-data")]//Deep
        public HttpResponseMessage GET_PERSON3()
        {
            try
            {
                //var requestdata = request.Content.ReadAsStringAsync().Result;
                _AMM = new AuthenticateManagement();
                _dtable = new DataTable();
                _dtable = _AMM.Fetch_persons3_name();
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //[Route("api/get-nivritti-require-volunteer")]//Sudip
        public HttpResponseMessage Get_required_volunteer(string event_id)
        {
            try
            {
                //var requestdata = request.Content.ReadAsStringAsync().Result;
                _EM = new EventManagement();
                _dtable = new DataTable();
                _dtable = _EM.Get_required_volunteer(event_id);
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //[Route("api/get-event-calendar-breakup-data")]//Sudip
        public HttpResponseMessage Get_event_date(string event_id)
        {
            try
            {
                //var requestdata = request.Content.ReadAsStringAsync().Result;
                _EM = new EventManagement();
                _dtable = new DataTable();
                _dtable = _EM.Get_event_date(event_id);
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //api/get-master-data-list/{category_name}
        public HttpResponseMessage View_Master_List(string category_name)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.View_Master_List(category_name);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/add-master-category")]
        public HttpResponseMessage Add_master_Data(HttpRequestMessage request)
        {
            try
            {

                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();
                MasterManagement _MM = new MasterManagement();
                _dtable = new DataTable();
                _MM = new MasterManagement();
                //int status = 0;
                //JavaScriptSerializer JsonArray = new JavaScriptSerializer();
                //Dictionary<string, object> _data = (Dictionary<string, object>)JsonArray.Deserialize(data, typeof(Dictionary<string, object>));
                if (data != null)
                {
                    _dtable = _MM.Add_master_Data(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/add-sub-category")]
        public HttpResponseMessage Add_sub_category(HttpRequestMessage request)
        {
            try
            {

                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();
                MasterManagement _MM = new MasterManagement();
                _dtable = new DataTable();
                _MM = new MasterManagement();
                //int status = 0;
                //JavaScriptSerializer JsonArray = new JavaScriptSerializer();
                //Dictionary<string, object> _data = (Dictionary<string, object>)JsonArray.Deserialize(data, typeof(Dictionary<string, object>));
                if (data != null)
                {
                    _dtable = _MM.Add_sub_category(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //api/get-parent-master-data-list
        public HttpResponseMessage View_Parent_Master_List()
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.View_Parent_Master_List();


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/add-coaching-detail")]
        public HttpResponseMessage Add_coaching_detail(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                //int status = 0;
                //JavaScriptSerializer JsonArray = new JavaScriptSerializer();
                //Dictionary<string, object> _data = (Dictionary<string, object>)JsonArray.Deserialize(data, typeof(Dictionary<string, object>));
                if (data != null)
                {
                    _dtable = _MM.Add_coaching_detail(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPut]
        //[Route("api/update-coaching-detail")]
        public HttpResponseMessage Update_coaching_detail(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                //int status = 0;
                //JavaScriptSerializer JsonArray = new JavaScriptSerializer();
                //Dictionary<string, object> _data = (Dictionary<string, object>)JsonArray.Deserialize(data, typeof(Dictionary<string, object>));
                if (data != null)
                {
                    _dtable = _MM.Update_coaching_detail(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //api/get-coaching-detail-data
        public HttpResponseMessage View_Coaching_Detail_List(string Record_id = null)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                if (Record_id == null)
                {
                    _dtable = _MM.View_Coaching_Detail_List();
                }
                else
                {
                    _dtable = _MM.View_Coaching_Detail(Record_id);
                }
                //_dtable = _EM.View_Coaching_Detail_List();


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //api/get-user-data/{User_id}/{Status}/{Role}
        public HttpResponseMessage View_User_Data(string User_id = null, string Status = null, string Role = null)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.View_User_Data(User_id, Status, Role);
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //api/get-registered-event-data/{Event_id}
        public HttpResponseMessage View_Registered_Event_Data(string Event_id)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.View_Registered_Event_Data(Event_id);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPut]
        //[Route("api/update-user-profile")]
        public HttpResponseMessage Update_user_profile(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                //int status = 0;
                //JavaScriptSerializer JsonArray = new JavaScriptSerializer();
                //Dictionary<string, object> _data = (Dictionary<string, object>)JsonArray.Deserialize(data, typeof(Dictionary<string, object>));
                if (data != null)
                {
                    _dtable = _MM.Update_user_profile(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpDelete]
        //api/delete-coaching-detail/{Record_ld}
        public HttpResponseMessage Delete_Coaching_detail_Data(string Record_ld)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.Delete_Coaching_detail_Data(Record_ld);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPut]
        //[Route("api/update-user-status")]
        public HttpResponseMessage Update_user_status(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                //int status = 0;
                //JavaScriptSerializer JsonArray = new JavaScriptSerializer();
                //Dictionary<string, object> _data = (Dictionary<string, object>)JsonArray.Deserialize(data, typeof(Dictionary<string, object>));
                if (data != null)
                {
                    _dtable = _MM.Update_user_status(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/event-registration")]
        public HttpResponseMessage event_registration(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                //int status = 0;
                //JavaScriptSerializer JsonArray = new JavaScriptSerializer();
                //Dictionary<string, object> _data = (Dictionary<string, object>)JsonArray.Deserialize(data, typeof(Dictionary<string, object>));
                if (data != null)
                {
                    _dtable = _MM.event_registration(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPut]
        //[Route("api/update-event-data")]
        public HttpResponseMessage update_event_data(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (data != null)
                {
                    _dtable = _MM.update_event_data(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }


        [HttpGet]
        //[Route("api/get-approved-event-data")]
        public HttpResponseMessage get_approved_event_data(string user_id)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                //var data = request.Content.ReadAsStringAsync().Result;
               // string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (user_id != null)
                {
                    _dtable = _MM.View_Approved_Event_Data(user_id);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }





        [HttpGet]
        //[Route[("api/get-rejected-event-data/{id}")]
        public HttpResponseMessage get_rejected_event_data(string user_id)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                //var data = request.Content.ReadAsStringAsync().Result;
               //string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (user_id != null)
                {
                    _dtable = _MM.View_Rejected_Event_Data(user_id);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //[Route[("api/get-event-volunteer-reg-data")]
        public HttpResponseMessage get_event_volunteer_reg_data()
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.Get_Event_Volunteer_Reg_Data();


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        //[Route("api/volunteer-event-checkinout-update")]
        public HttpResponseMessage volunteer_event_checkinout_update(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (data != null)
                {
                    _dtable = _MM.Volunteer_Event_Checkinout_Update(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/event-registration-cancel")]
        public HttpResponseMessage event_registration_cancel(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (data != null)
                {
                    _dtable = _MM.Volunteer_Event_Cancel(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/user-login")]
        public HttpResponseMessage user_login(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (data != null)
                {
                    _dtable = _MM.Login(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/itinary-confirmation-update")]
        public HttpResponseMessage itinary_conformation_update(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (data != null)
                {
                    _dtable = _MM.Itinary_Confirmation_Update(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/itinary-status-update")]
        public HttpResponseMessage itinary_status_update(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (data != null)
                {
                    _dtable = _MM.Itinary_Status_Update(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/topic-status-update")]
        public HttpResponseMessage topic_status_update(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (data != null)
                {
                    _dtable = _MM.Topic_Status_Update(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }

        //Get_Event_Data

        [HttpGet]
        //[Route[("api/get-event-data")]
        public HttpResponseMessage get_event_data(int event_type)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.Get_Event_Data(event_type);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //[Route[("api/get-content-data")]
        public HttpResponseMessage get_content_data(string event_reg_id)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.GetContent(event_reg_id);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["Json_Value"]);
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpPost]
        //[Route("api/user-registration")]
        public HttpResponseMessage user_registration(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (data != null)
                {
                    _dtable = _MM.user_registration(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //[Route[("api/get-satsang-chapter-data/{country_id}")]
        public HttpResponseMessage get_satsang_chapter_data(string country_id)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.GetSatsangChapterData(country_id);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"].ToString());
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/user-profile-update")]
        public HttpResponseMessage user_profile_update(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (data != null)
                {
                    _dtable = _MM.user_update(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //[Route[("api/get-education-data/{education_id}")]
        public HttpResponseMessage get_education_data(string education_id)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.GetSubjectDatabyEducationId(education_id);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"].ToString());
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //[Route[("api/get-country-data")]
        public HttpResponseMessage get_country_data()
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.GetCountry();


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"].ToString());
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //[Route[("api/password-reset/{user_id}")]
        public HttpResponseMessage password_reset(string user_id)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.PasswordReset(user_id);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"].ToString());
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpGet]
        //[Route[("api/get-itinerary-information/{event_reg_id}")]
        public HttpResponseMessage get_itinerary_information(string event_reg_id)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                _MM = new MasterManagement();
                _dtable = new DataTable();
                _dtable = _MM.GetItineraryInformation(event_reg_id);


                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = Convert.ToString(_dtable.Rows[0]["JSON_VALUE"].ToString());
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);

            }
            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }
        [HttpPost]
        //[Route("api/update-itinerary-status")]
        public HttpResponseMessage update_itinerary_status(HttpRequestMessage request)
        {
            try
            {
                MasterManagement _MM = new MasterManagement();
                var data = request.Content.ReadAsStringAsync().Result;
                string Jsondata = data.ToString();

                _dtable = new DataTable();
                _MM = new MasterManagement();
                if (data != null)
                {
                    _dtable = _MM.UpdateItineraryStatus(Jsondata);
                }
                if (_dtable.Rows.Count > 0)
                {
                    _jsonString = _dtable.Rows[0]["JSON_VALUE"].ToString();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    _jsonString = Data.DatatableEmpty();
                    response = this.Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _jsonString = Data.ExceptionToJsonString(ex.Message);
                response = this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }

            response.Content = new StringContent(_jsonString, Encoding.UTF8, "application/json");
            return response;
        }

    }
}


        

    
