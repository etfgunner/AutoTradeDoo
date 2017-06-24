using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoTradeDoo.Startup))]
namespace AutoTradeDoo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
