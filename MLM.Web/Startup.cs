using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MLM.Web.Startup))]
namespace MLM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
