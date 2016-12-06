using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IntranetRosul
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;

          





        }
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("http://192.168.16.13", "*", "*");
            config.EnableCors(corsAttr);
        }
     

       
    }
}
