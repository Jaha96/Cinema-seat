using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntertainmentWorldTicket.Startup))]
namespace EntertainmentWorldTicket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
