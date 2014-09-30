using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminRoles.Startup))]
namespace AdminRoles
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
