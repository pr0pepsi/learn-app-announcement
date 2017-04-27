using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Announcements.Startup))]
namespace Announcements
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
