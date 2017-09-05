using SandwichOrderSystem.ViewControllers;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class CancelOrderState : ViewState
    {
        CancelOrderViewController viewController;
        public CancelOrderState(CancelOrderViewController viewController, IConsoleWrapper console) : base(console)
        {
            this.viewController = viewController;
        }

        public void Action()
        {
            console.ClearOutput();
            string command = console.ReadInput(CancelOrderViewController.ActionConfirm, false);

            console.ClearOutput();
            switch (command)
            {
                case CancelOrderViewController.ActionCommandConfirm:
                    console.OutputLine(CancelOrderViewController.ActionComplete, true);
                    break;
                default:
                    console.OutputLine(CancelOrderViewController.ActionIncomplete, true);
                    break;
            }

            console.PromptToContinue();
            returnToMain();
        }

        public override string MenuCommands()
        {
            string command = menuPrompt(viewController.MenuTitle, viewController.MenuCommands);
            switch (command)
            {
                case CancelOrderViewController.CommandConfirm:
                    Action();
                    break;
                case CancelOrderViewController.CommandReturn:
                    returnToMain();
                    break;
                case CancelOrderViewController.CommandQuit:
                    break;
                default:
                    console.PromptInvalidCommand();
                    break;
            }

            return command;
        }
    }
}
