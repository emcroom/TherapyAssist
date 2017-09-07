using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TherapyAssist.Startup))]
namespace TherapyAssist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
