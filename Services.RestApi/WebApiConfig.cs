using System.Web.Http;

namespace Services.RestApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}",
                new {id = RouteParameter.Optional}
                );
        }
    }
}