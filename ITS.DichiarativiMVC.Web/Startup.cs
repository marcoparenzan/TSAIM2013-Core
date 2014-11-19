using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITS.DichiarativiMVC.Web.Startup))]
namespace ITS.DichiarativiMVC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
