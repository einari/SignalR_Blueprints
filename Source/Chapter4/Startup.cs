using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chapter4.Startup))]
namespace Chapter4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
