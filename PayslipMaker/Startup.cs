using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayslipMaker.Startup))]
namespace PayslipMaker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
