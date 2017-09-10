using SandwichOrderSystemShared.DI;

namespace SandwichOrderSystemShared.DataAccess.Db
{
    public class ContextFactory : IContextFactory
    {
        private IDIContainerIWrapper container;

        public ContextFactory(IDIContainerIWrapper container)
        {
            this.container = container;
        }

        public Context CreateContext()
        {
            return container.Container.Resolve<Context>();
        }
    }
}
