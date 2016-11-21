using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestLodopPrint.Startup))]
namespace TestLodopPrint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
