using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reddit.Startup))]
namespace Reddit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
