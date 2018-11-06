namespace GurukulAppAdminPanel.Models
{
    using GurukulAppAdminPanel.App_Start;
    using RestClient;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Helpers;
    using System.Web.Mvc;
    public class SatsangManagement
    {
        public string chaptername { get; set; }
        public string chaperdescription { get; set; }
        public string countryid { get; set; }

        public ArrayList ChapterList = new ArrayList();
        public List<SelectListItem> CountryList = new List<SelectListItem>();

        /***************************************
         * Title :: Get Satsang Chapter Data
         * Description :: this module use for get satsang chapter
         * Param :: 
         * Return :: Response data
         **************************************/
        public string GetSatsangChapterData()
        {
            string _response = string.Empty;

            RestClient _client = new RestClient();
            _client.URL = Constant.GET_SATSANG_CHAPTER_DATA;
            _client.Method = HttpMethod.GET;
            _client.Execute();
            _response = _client.Response();

            return _response;
        }
        /***************************************
         * Title :: Get Country List Data
         * Description :: this module use for get country data
         * Param :: 
         * Return :: Response data
         **************************************/
        public string GetCountryListData()
        {
            string _response = string.Empty;

            RestClient _client = new RestClient();
            _client.URL = Constant.GET_MASTER_COUNTRY_DATA;
            _client.Method = HttpMethod.GET;
            _client.Execute();
            _response = _client.Response();

            return _response;
        }
        /***************************************
         * Title :: Add Satsang Chapter
         * Description :: this module use for Add Satsang Chapter
         * Param :: 
         * Return :: Response data
         **************************************/
        public string AddChapterData(SatsangManagement _data)
        {
            string _response = string.Empty;
            SortedList<string, object> _postdata = new SortedList<string, object>();
            _postdata.Add("CHAPTER_NAME", _data.chaptername);
            _postdata.Add("CHAPTER_DESCRIPTION", (_data.chaperdescription == null) ? "N/A" : _data.chaperdescription);
            _postdata.Add("COUNTRY_ID", _data.countryid);

            RestClient _client = new RestClient();
            _client.URL = Constant.ADD_SATSANG_CHAPTER_DATA;
            _client.Method = HttpMethod.POST;
            _client.Content = Json.Encode(_postdata);
            _client.Type = ContentType.URLENCODE;
            _client.Execute();
            _response = _client.Response();

            return _response;
        }
    }
}