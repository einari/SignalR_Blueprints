using System.Web;
using System.Web.Routing;
using Bifrost.Configuration;
using Bifrost.Web.Services;

namespace Web
{
    public class BifrostConfigurator : ICanConfigure
    {
        public void Configure(IConfigure configure)
        {
            var entitiesPath = HttpContext.Current.Server.MapPath("~/App_Data/Entities");
            var eventsPath = HttpContext.Current.Server.MapPath("~/App_Data/Events");

            configure
                .Serialization
                    .UsingJson()
                .Events
                    .UsingFiles(eventsPath)
                .DefaultStorage
                    .UsingFiles(entitiesPath)
                .Frontend
					.Web(w=> {
                        w.AsSinglePageApplication();

                        w.PathsToNamespaces.Add("**/", "Web.**.");
                        w.PathsToNamespaces.Add("/**/", "Web.**.");
                        w.PathsToNamespaces.Add("", "Web");

                        w.NamespaceMapper.Add("Web.**.", "Web.Domain.**.");
                        w.NamespaceMapper.Add("Web.**.", "Web.Read.**.");
                        w.NamespaceMapper.Add("Web.**.", "Web.**.");

                    })
                .WithMimir();

            RouteTable.Routes.AddService<Defaults>();
        }
    }
}