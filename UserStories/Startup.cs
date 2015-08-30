using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserStories.Startup))]
namespace UserStories
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
