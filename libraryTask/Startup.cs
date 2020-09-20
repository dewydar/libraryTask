using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(libraryTask.Startup))]
namespace libraryTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
