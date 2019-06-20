using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rent_a_Car.Startup))]
namespace Rent_a_Car
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
