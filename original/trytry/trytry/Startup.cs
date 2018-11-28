using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(trytry.Startup))]
namespace trytry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
