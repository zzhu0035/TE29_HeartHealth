using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TE29_HeartHealth_GCardiac.Startup))]
namespace TE29_HeartHealth_GCardiac
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
