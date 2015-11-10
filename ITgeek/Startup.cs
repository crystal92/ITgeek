using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITgeek.Startup))]
namespace ITgeek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
