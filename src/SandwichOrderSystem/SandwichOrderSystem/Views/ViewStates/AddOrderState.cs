using SandwichOrderSystem.ViewControllers;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class AddOrderState : ViewState
    {
        AddOrderViewController viewController;
        public AddOrderState(AddOrderViewController viewController, IConsoleWrapper console) : base(console)
        {
            this.viewController = viewController;
        }

        public override string MenuCommands()
        {
            string command = menuPrompt(viewController.MenuTitle, viewController.MenuCommands);
            switch (command)
            {
                case AddOrderViewController.CommandAdd:
                    break;
                case AddOrderViewController.CommandReturn:
                    returnToMain();
                    break;
                case AddOrderViewController.CommandQuit:
                    break;
                default:
                    console.PromptInvalidCommand();
                    break;
            }

            return command;
        }
    }
}
