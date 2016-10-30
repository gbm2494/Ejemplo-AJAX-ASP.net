using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ajax_IMEC.Startup))]
namespace Ajax_IMEC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
