using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UMC.Startup))]
namespace UMC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
