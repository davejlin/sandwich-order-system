using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SandwichOrderSystem.Views.ViewState;
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
            container.Register(Component.For<IViewState>().ImplementedBy<ViewState>());
            container.Register(Component.For<IViewController>().ImplementedBy<ViewController>());
        }
    }
}
