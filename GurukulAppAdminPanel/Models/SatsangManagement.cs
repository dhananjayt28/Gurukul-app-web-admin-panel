namespace GurukulAppAdminPanel.Models
{
    using GurukulAppAdminPanel.App_Start;
    using RestClient;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Data;
    using System.Data.SqlClient;
    using System;
    using DatabaseManagementClient;

    public class SatsangManagement
    {
        DatabaseManagement _dbObj;
        public string chaptername { get; set; }
        public string chaperdescription { get; set; }
        public string stateid { get; set; }
        public string state { get; set; }
        public string countryid { get; set; }
        public string country { get; set; }

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
            MasterManagement mmobj = new MasterManagement();
            DataTable dt = new DataTable();
            dt = mmobj.GetSatsangChapterData();
            _response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);
           // return response;

            //RestClient _client = new RestClient();
            //_client.URL = Constant.GET_SATSANG_CHAPTER_DATA;
            //_client.Method = HttpMethod.GET;
            //_client.Execute();
            //_response = _client.Response();

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

            //RestClient _client = new RestClient();
            //_client.URL = Constant.GET_MASTER_COUNTRY_DATA;
            //_client.Method = HttpMethod.GET;
            //_client.Execute();
            //_response = _client.Response();
            _response = GetCountryData().Rows[0]["JSON_VALUE"].ToString();

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
            //SortedList<string, object> _postdata = new SortedList<string, object>();
            //_postdata.Add("CHAPTER_NAME", _data.chaptername);
            //_postdata.Add("CHAPTER_DESCRIPTION", (_data.chaperdescription == null) ? "N/A" : _data.chaperdescription);
            //_postdata.Add("COUNTRY_ID", _data.countryid);

            //RestClient _client = new RestClient();
            //_client.URL = Constant.ADD_SATSANG_CHAPTER_DATA;
            //_client.Method = HttpMethod.POST;
            //_client.Content = Json.Encode(_postdata);
            //_client.Type = ContentType.URLENCODE;
            //_client.Execute();
            //_response = _client.Response();
            AddChapterData(_data.chaptername, (_data.chaperdescription == null) ? "N/A" : _data.chaperdescription, _data.countryid);

            return _response;
        }
        public string AddChapterData(string chapterName, string chapterDesc, string countryid)
        {
            DataTable dt = new DataTable();
            string response = string.Empty;
           // _queryResponse = 0;
                      
                //EXEC dbo.USP_MASTER_MANAGEMENT @OPERATIONID=8, @CHAPTER_NAME = 'Manama', @CHAPTER_DESC='', @COUNTRYID = '1'
                SqlParameter[] _Param = new SqlParameter[] {
                    new SqlParameter("@OPERATIONID", 8) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                    new SqlParameter("@CHAPTER_NAME", chapterName) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
                    new SqlParameter("@CHAPTER_DESC", chapterDesc) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input },
                    new SqlParameter("@COUNTRYID", countryid) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
                };
                dt = _dbObj.Select("USP_MASTER_MANAGEMENT", _Param);
           
          if (dt.Rows.Count > 0)
            {
                response = Convert.ToString(dt.Rows[0]["JSON_VALUE"]);
            }
            return response;
        }
        public DataTable GetSatsangChapterData(string country_id = "")
        {
          DataTable  dt = new DataTable();
            // EXEC dbo.USP_MASTER_MANAGEMENT @OPERATIONID=6,@COUNTRYID='2'
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 6) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input },
                new SqlParameter("@COUNTRYID", country_id) { SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input }
            };

            dt = _dbObj.Select("USP_MASTER_MANAGEMENT", _param);
            return dt;
        }
        public DataTable GetCountryData()
        {
            //EXEC dbo.USP_MASTER_MANAGEMENT @OPERATIONID=7
           DataTable _datatable = new DataTable();
            SqlParameter[] _param = new SqlParameter[] {
                new SqlParameter("@OPERATIONID", 7) { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input }
            };
            _datatable = _dbObj.Select("USP_MASTER_MANAGEMENT", _param);
            return _datatable;
        }
    }
}