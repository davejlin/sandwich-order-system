using SandwichOrderSystemShared.DI;

namespace SandwichOrderSystemShared.DataAccess.Db
{
    public class ContextFactory : IContextFactory
    {
        private IDContainerIWrapper container;

        public ContextFactory(IDContainerIWrapper container)
        {
            this.container = container;
        }

        public Context CreateContext()
        {
            return container.Container.Resolve<Context>();
        }
    }
}
