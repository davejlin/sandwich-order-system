using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SandwichOrderSystem.Views.ViewStates;
using SandwichOrderSystem.Views;
using SandwichOrderSystem.ViewControllers;

namespace SandwichOrderSystem.DI
{
    public class DIMainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IConsoleAppManager>().ImplementedBy<ConsoleAppManager>());
            container.Register(Component.For<IConsoleWrapper>().ImplementedBy<ConsoleWrapper>());
            container.Register(Component.For<IViewContext>().ImplementedBy<ViewContext>());

            container.Register(Types.FromThisAssembly()
                .BasedOn<IViewState>()
                .WithService.Base()
                .WithService.Self());

            container.Register(Types.FromThisAssembly()
                .BasedOn<IViewController>()
                .WithService.Base()
                .WithService.Self());
        }
    }
}
