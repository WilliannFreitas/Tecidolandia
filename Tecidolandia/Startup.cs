using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tecidolandia.Startup))]
namespace Tecidolandia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
