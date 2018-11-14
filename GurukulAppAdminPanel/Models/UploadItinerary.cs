using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GurukulAppAdminPanel.Models
{
    public class UploadItinerary
    {
        public string hide_event_reg_id { get; set; }
        public HttpPostedFileBase file_ { get; set; }
        

        //public string UploadMouFile(string file_name, string mou_id, string user_id)
        //{
        //    string api = "http://testtmlcsrmvc.ttssupport.info/api/update-mou-upload";
        //    List<object> postdata = new List<object>();
        //    SortedList<string, object> _postArrData = new SortedList<string, object>();
        //    _postArrData.Add("Mou_file", file_name);
        //    _postArrData.Add("Mou_ID", mou_id);
        //    _postArrData.Add("User_Id", user_id);

        //    postdata.Add(_postArrData);
        //    var _postContent = Json.Encode(postdata);

        //    RestClient.RestClient _client = new RestClient.RestClient();
        //    _client.URL = api;
        //    _client.Method = HttpMethod.PUT;
        //    _client.Content = _postContent;
        //    _client.Type = ContentType.JSON;
        //    _client.Execute();
        //    var response = _client.Response();
        //    return response;
        //}
    }
}