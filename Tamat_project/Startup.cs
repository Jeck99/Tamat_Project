using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tamat_project.Startup))]
namespace Tamat_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
