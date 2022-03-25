using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vxdlite.Startup))]
namespace vxdlite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
