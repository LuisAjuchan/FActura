using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Factura.Startup))]
namespace Factura
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
