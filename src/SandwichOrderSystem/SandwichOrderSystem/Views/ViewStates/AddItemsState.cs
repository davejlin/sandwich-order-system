using SandwichOrderSystem.ViewControllers;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class AddItemsState : ViewState
    {
        AddItemsViewController viewController;
        public AddItemsState(AddItemsViewController viewController, IConsoleWrapper console) : base(console)
        {
            this.viewController = viewController;
        }

        public override void Action()
        {
        }

        public override string MenuCommands()
        {
            string command = menuPrompt(viewController.MenuTitle, viewController.MenuCommands);
            switch (command)
            {
                case AddItemsViewController.CommandAddSignatureSandwich:
                    Action();
                    break;
                case AddItemsViewController.CommandAddCustomSandwich:
                    Action();
                    break;
                case AddItemsViewController.CommandAddDrink:
                    Action();
                    break;
                case AddItemsViewController.CommandAddChips:
                    Action();
                    break;
                case AddItemsViewController.CommandReturn:
                    returnToMain();
                    break;
                case AddItemsViewController.CommandQuit:
                    break;
                default:
                    console.PromptInvalidCommand();
                    break;
            }

            return command;
        }
    }
}
