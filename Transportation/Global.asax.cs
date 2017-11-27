using System.Web.Http;
using Transportation.App_Start;

namespace Transportation
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(FormatConfig.Formatters);
            GlobalConfiguration.Configure(DependencyInjectionConfig.RegisterDependencyInjection);
            AutoMapperConfig.Intialize();
        }
    }
}
