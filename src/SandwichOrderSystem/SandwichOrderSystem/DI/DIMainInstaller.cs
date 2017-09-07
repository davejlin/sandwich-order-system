using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SandwichOrderSystem.Views;
using SandwichOrderSystem.ViewControllers;
using SandwichOrderSystem.ViewModels;
using SandwichOrderSystem.Services;

namespace SandwichOrderSystem.DI
{
    public class DIMainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IConsoleWrapper>().ImplementedBy<ConsoleWrapper>());
            container.Register(Component.For<IMenuItemsFactory>().ImplementedBy<MenuItemsFactory>());

            container.Register(Component.For<IViewState>().ImplementedBy<ViewState>());
            container.Register(Component.For<IViewModel>().ImplementedBy<ViewModel>());
            container.Register(Component.For<IViewController>().ImplementedBy<ViewController>());
        }
    }
}
