using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace Chapter10
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                app.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration
                {
                    EnableJSONP = true
                };
                
                /*
                GlobalHost.DependencyResolver.UseSqlServer(
                        "Data Source=(local);"+
                        "Initial Catalog=SignalRChat;"+
                        "Integrated Security=True"
                    );

                GlobalHost.DependencyResolver.UseRedis(
                    "localhost",
                    6379,
                    "",
                    "signalr.key");

                GlobalHost.DependencyResolver.UseServiceBus(
                    "your connection string from azure",
                    "signalr");
                 */

                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
