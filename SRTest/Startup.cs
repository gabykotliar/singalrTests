using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SRTest.Startup))]
namespace SRTest
{
    public class Startup
    {        
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
