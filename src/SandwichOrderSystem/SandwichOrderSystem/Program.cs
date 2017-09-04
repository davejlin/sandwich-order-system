using SandwichOrderSystem.DI;
using SandwichOrderSystem.States.Level1States;
using System;

namespace SandwichOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DIContainer.Container.InitContainer();
            var level1Context = container.Resolve<ILevel1Context>();
            level1Context.MenuCommands();

            Console.ReadLine();

            container.Dispose();
        }
    }
}
