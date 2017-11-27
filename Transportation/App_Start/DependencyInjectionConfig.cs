using DryIoc;
using DryIoc.WebApi;
using System.Web.Http;
using Transportation.Data;

namespace Transportation.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDependencyInjection(HttpConfiguration config)
        {
            var container = new Container();
            Configure(container).WithWebApi(config);
        }

        private static Container Configure(Container container)
        {
            container.RegisterInstance(new DataContext());

            return container;
        }
    }
}