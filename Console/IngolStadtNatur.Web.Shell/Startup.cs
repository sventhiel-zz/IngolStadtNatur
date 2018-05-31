using IngolStadtNatur.Services.NH.Utilities;
using IngolStadtNatur.Web.Shell;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace IngolStadtNatur.Web.Shell
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Auth.Configure(app);
        }
    }
}