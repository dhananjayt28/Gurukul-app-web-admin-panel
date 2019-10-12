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

    }
}