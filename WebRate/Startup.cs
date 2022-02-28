using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRate.Startup))]
namespace WebRate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
