using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RunningApplication.Startup))]
namespace RunningApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
