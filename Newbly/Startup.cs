using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Newbly.Startup))]
namespace Newbly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
