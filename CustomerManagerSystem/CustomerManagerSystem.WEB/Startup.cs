using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerManagerSystem.WEB.Startup))]
namespace CustomerManagerSystem.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
