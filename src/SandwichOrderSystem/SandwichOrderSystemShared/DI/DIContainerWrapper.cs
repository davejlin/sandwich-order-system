using System;
using Castle.Windsor;

namespace SandwichOrderSystemShared.DI
{
    public class DIContainerWrapper : IDContainerIWrapper
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
