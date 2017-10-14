using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TelefonskiImenik.Web.Startup))]
namespace TelefonskiImenik.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
