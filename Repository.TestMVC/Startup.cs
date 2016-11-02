using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Repository.TestMVC.Startup))]
namespace Repository.TestMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
