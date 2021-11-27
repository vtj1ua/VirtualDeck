using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualDeckWeb.Startup))]
namespace VirtualDeckWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
