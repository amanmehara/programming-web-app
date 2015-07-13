using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(programmingwebapp.Startup))]
namespace programmingwebapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
