using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeDemoCRUD.Startup))]
namespace EmployeeDemoCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
