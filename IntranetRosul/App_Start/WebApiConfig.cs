using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IntranetRosul
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Enable CORS
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API configuration and services
            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var serializerSettings = jsonFormatter.SerializerSettings;

            // Remove XML formatting
            formatters.Remove(config.Formatters.XmlFormatter);
            jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            // Configure our JSON output
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.Formatting = Formatting.Indented;
            serializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            serializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
