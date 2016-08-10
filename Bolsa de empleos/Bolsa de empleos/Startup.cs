using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bolsa_de_empleos.Startup))]
namespace Bolsa_de_empleos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
