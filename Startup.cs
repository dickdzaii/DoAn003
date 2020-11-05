using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAn003.Startup))]
namespace DoAn003
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
