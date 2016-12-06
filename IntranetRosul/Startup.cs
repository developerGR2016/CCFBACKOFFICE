using Microsoft.Owin;
using Owin;
using System.Web.Helpers;

[assembly: OwinStartupAttribute(typeof(IntranetRosul.Startup))]
namespace IntranetRosul
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            

        }
    }
}
