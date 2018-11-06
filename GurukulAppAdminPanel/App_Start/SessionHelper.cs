

namespace GurukulAppAdminPanel.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class SessionHelper
    {
        private dynamic _sessData = System.Web.HttpContext.Current.Session;
    }
}