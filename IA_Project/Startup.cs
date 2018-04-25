using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Graduation_Projects_Idea.Startup))]
namespace Graduation_Projects_Idea
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //  ConfigureAuth(app);
        }
    }
}
