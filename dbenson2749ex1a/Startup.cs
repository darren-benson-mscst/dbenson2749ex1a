using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dbenson2749ex1a.Startup))]
namespace dbenson2749ex1a
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
