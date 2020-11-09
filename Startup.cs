using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookish.Startup))]
namespace Bookish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
