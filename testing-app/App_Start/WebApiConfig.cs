using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;
namespace testing_app
{
 
    public static class WebApiConfig
    {
        public static string UrlPrefixRelative { get { return "~/api"; } }


        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //var cors = new EnableCorsAttribute("http://localhost, "*", "*");
            //config.EnableCors(cors);
            config.EnableCors(new EnableCorsAttribute("http://localhost:3000", "Content-Type", "GET,POST,OPTIONS,PUT") { SupportsCredentials = true });
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}
