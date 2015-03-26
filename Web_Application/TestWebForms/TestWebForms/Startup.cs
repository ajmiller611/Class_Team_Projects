using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestWebForms.Startup))]
namespace TestWebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
