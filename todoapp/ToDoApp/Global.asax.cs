using System;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace ToDoApp
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Clear();
            formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}