using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(imrg_web.Startup))]
namespace imrg_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
