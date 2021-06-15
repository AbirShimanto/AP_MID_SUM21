using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabTask.Startup))]
namespace LabTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
