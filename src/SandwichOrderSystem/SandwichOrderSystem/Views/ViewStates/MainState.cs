using SandwichOrderSystem.ViewControllers;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class MainState : ViewState
    {
        MainStateViewController viewController;
        public MainState(MainStateViewController viewController, IConsoleWrapper console) : base(console)
        {
            this.viewController = viewController;
        }

        public override string MenuCommands()
        {
            string command = menuPrompt(viewController.MenuTitle, viewController.MenuCommands);
            switch (command)
            {
                case MainStateViewController.CommandAdd:
                    context.State = context.AddOrderState;
                    break;
                case MainStateViewController.CommandCancel:
                    context.State = context.CancelOrderState;
                    break;
                case MainStateViewController.CommandDisplay:
                    context.State = context.DisplayOrderState;
                    break;
                case MainStateViewController.CommandFinish:
                    context.State = context.FinishOrderState;
                    break;
                case MainStateViewController.CommandQuit:
                    break;
                default:
                    console.PromptInvalidCommand();
                    break;
            }

            return command;
        }
    }
}
