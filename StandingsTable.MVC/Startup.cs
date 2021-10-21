using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StandingsTable.MVC.Startup))]
namespace StandingsTable.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
