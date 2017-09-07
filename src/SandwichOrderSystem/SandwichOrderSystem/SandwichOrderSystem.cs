using SandwichOrderSystem.ViewControllers;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem
{
    public class SandwichOrderSystem : ISandwichOrderSystem
    {
        IViewController viewController;

        public SandwichOrderSystem(IViewController viewController)
        {
            this.viewController = viewController;
        }

        public void Start()
        {
            string currentCommand = "";
            while (currentCommand != QUIT_COMMAND)
            {
                currentCommand = viewController.AdvanceViewCycle();
            }
        }
    }
}
