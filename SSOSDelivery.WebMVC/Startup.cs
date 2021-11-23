using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSOSDelivery.WebMVC.Startup))]
namespace SSOSDelivery.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
