using SandwichOrderSystem.ViewControllers;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class DisplayOrderState : ViewState
    {
        DisplayOrderViewController viewController;
        public DisplayOrderState(DisplayOrderViewController viewController, IConsoleWrapper console) : base(console)
        {
            this.viewController = viewController;
        }

        public override string MenuCommands()
        {
            string command = menuPrompt(viewController.MenuTitle, viewController.MenuCommands);
            switch (command)
            {
                case DisplayOrderViewController.CommandDisplay:
                    break;
                case DisplayOrderViewController.CommandReturn:
                    returnToMain();
                    break;
                case DisplayOrderViewController.CommandQuit:
                    break;
                default:
                    console.PromptInvalidCommand();
                    break;
            }

            return command;
        }
    }
}
