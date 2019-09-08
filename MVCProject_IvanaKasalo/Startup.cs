using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCProject_IvanaKasalo.Startup))]
namespace MVCProject_IvanaKasalo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
