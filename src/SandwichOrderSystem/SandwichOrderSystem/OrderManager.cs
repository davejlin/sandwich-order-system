using SandwichOrderSystem.States.Level1;

namespace SandwichOrderSystem
{
    public class OrderManager : IOrderManager
    {
        ILevel1Context level1Context;
        public OrderManager(ILevel1Context level1Context)
        {
            this.level1Context = level1Context;
        }

        public void start()
        {
            var command = "";
            while (command != "q")
            {
                command = level1Context.MenuCommands();
            }
        }
    }
}
