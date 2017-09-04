﻿using Castle.Windsor;
using Castle.Windsor.Installer;
using SandwichOrderingSystemShared.DI;

namespace SandwichOrderingSystem.DI
{
    public class DIContainer
    {
        private static DIContainer container;

        private DIContainer() {}

        public static DIContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = new DIContainer();
                }

                return container;
            }
        }

        public IWindsorContainer InitContainer()
        {
            return new WindsorContainer()
                .Install(
                    FromAssembly.This(),
                    FromAssembly.Containing<DISharedInstaller>()
                );
        }
    }
}
