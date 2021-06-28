using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomebrewRPG.WebMVC.Startup))]
namespace HomebrewRPG.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
