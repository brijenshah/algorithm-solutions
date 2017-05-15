using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ToDoApp
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "Default",
                "{namespace}/{controller}/{id}",
                new {@namespace = "api", controller="ToDoItems", id=RouteParameter.Optional}
            );

            AppSettingsReader reader = new AppSettingsReader();
            string clientUrl = reader.GetValue("clientUrl", typeof (string)).ToString();

            config.EnableCors(new EnableCorsAttribute(clientUrl.ToLowerInvariant(), "*", "*", "*"));
        }
    }
}