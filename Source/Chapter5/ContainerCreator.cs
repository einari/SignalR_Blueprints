using Bifrost.Configuration;
using Bifrost.Execution;
using Bifrost.Ninject;
using Ninject;

namespace Chapter5
{
    public class ContainerCreator : ICanCreateContainer
    {
        public IContainer CreateContainer()
        {
            var kernel = new StandardKernel();
            var container = new Container(kernel);
            return container;
        }
    }
}