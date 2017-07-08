using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Livraria.Startup))]
namespace Livraria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
