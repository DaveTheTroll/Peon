using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Peon.Web.Startup))]
namespace Peon.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
