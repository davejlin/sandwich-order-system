using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SandwichOrderSystem.States.Level1States;
using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.DI
{
    public class DIMainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IConsoleWrapper>().ImplementedBy<ConsoleWrapper>());
            container.Register(Component.For<ILevel1Context>().ImplementedBy<Level1Context>());

            container.Register(Types.FromThisAssembly()
                .BasedOn<ILevel1State>()
                .WithService.Base()
                .WithService.Self());
        }
    }
}
