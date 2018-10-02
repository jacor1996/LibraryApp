using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library.WebApplication.Startup))]
namespace Library.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
