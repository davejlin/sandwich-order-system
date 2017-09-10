using Castle.Windsor;

namespace SandwichOrderSystemShared.DI
{
    public interface IDContainerIWrapper
    {
        IWindsorContainer Container { get; }
    }
}
