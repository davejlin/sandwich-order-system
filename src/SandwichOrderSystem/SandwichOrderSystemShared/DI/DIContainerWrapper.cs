using Castle.Windsor;

namespace SandwichOrderSystemShared.DI
{
    public class DIContainerWrapper : IDIContainerIWrapper
    {
        public DIContainerWrapper() { }

        public IWindsorContainer Container
        {
            get
            {
                return DISharedInstaller.Container;
            }
        }
    }
}
