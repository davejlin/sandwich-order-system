using Castle.Windsor;

namespace SandwichOrderSystemShared.DI
{
    public interface IDIContainerIWrapper
    {
        IWindsorContainer Container { get; }
    }
}
