using IngolStadtNatur.Persistence.NH;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IngolStadtNatur.Web.Shell
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SessionFactoryManager.Start(ConfigurationManager.ConnectionStrings["ISN"].ConnectionString, ConfigurationManager.AppSettings["CreateDatabase"]);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
