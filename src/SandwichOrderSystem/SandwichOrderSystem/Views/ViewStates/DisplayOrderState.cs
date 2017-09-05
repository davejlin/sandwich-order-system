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

        public override void Action()
        {
            console.ClearOutput();
            console.OutputLine(" Displaying order ... ", true);
            console.PromptToContinue();
            returnToMain();
        }

        public override string MenuCommands()
        {
            string command = menuPrompt(viewController.MenuTitle, viewController.MenuCommands);
            switch (command)
            {
                case DisplayOrderViewController.CommandDisplay:
                    Action();
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
