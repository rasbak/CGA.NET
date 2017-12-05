using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CGA_WEB.Startup))]
namespace CGA_WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
