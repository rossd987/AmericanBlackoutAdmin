using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AmericanBlackoutAdmin.Startup))]
namespace AmericanBlackoutAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
