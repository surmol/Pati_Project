using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pati_Project.Startup))]
namespace Pati_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
