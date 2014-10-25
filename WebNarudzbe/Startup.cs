using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebNarudzbe.Startup))]
namespace WebNarudzbe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
