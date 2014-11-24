using System;
using System.IO;
using System.Web;

namespace Chapter4
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            var path = HttpContext.Current.Request.Path;
            if (path == "/") path = "index.html";

            if (path.ToLowerInvariant().IndexOf(".html") < 0) return;

            var physicalPath = HttpContext.Current.Request.MapPath(path);
            if (File.Exists(physicalPath))
            {
                RequestStatisticsHub.Request();
            }
            else
            {
                RequestStatisticsHub.FailedRequest();
            }
        }
    }
}