using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportRadarPlayByPlay.Startup))]
namespace SportRadarPlayByPlay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
