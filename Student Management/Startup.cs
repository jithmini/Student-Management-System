using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Student_Management.Startup))]
namespace Student_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
