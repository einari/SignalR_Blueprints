using Bifrost.Configuration;
using Bifrost.Execution;
using Bifrost.Ninject;
using Ninject;

namespace Web
{
    public class ContainerCreator : ICanCreateContainer
    {
        public IContainer CreateContainer()
        {
            var kernel = new StandardKernel(new ValidationQueriesModule(), new ClientEventsModule());
            var container = new Container(kernel);
            return container;
        }
    }
}