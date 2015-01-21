using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InTheRoom.Web.Startup))]
namespace InTheRoom.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
