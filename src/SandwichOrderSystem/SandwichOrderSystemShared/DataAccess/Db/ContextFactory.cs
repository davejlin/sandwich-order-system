using SandwichOrderSystemShared.DI;

namespace SandwichOrderSystemShared.DataAccess.Db
{
    public class ContextFactory : IContextFactory
    {
        public Context createContext()
        {
            return DISharedInstaller.Container.Resolve<Context>();
        }
    }
}
