using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rebbit.Startup))]
namespace Rebbit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
