using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GurukulAppAdminPanel.Models
{
    public class IasMangement
    {
       
        public string Record_id { get; set; }
        [Required(ErrorMessage = "Date Required.")]
        public string Date { get; set; }
        [Required(ErrorMessage = "Subject Required.")]
        public string Subject { get; set; }
        public List<SelectListItem> subjectlist = new List<SelectListItem>();
    }
}