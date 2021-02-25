using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFInal2021Beta.Startup))]
namespace WebFInal2021Beta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
