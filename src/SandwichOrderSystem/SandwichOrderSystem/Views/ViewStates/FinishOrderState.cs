using SandwichOrderSystem.ViewControllers;
using System;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class FinishOrderState : ViewState
    {
        FinishOrderViewController viewController;
        public FinishOrderState(FinishOrderViewController viewController, IConsoleWrapper console) : base(console)
        {
            this.viewController = viewController;
        }

        public override string MenuCommands()
        {
            string command = menuPrompt(viewController.MenuTitle, viewController.MenuCommands);
            switch (command)
            {
                case FinishOrderViewController.CommandFinish:
                    break;
                case FinishOrderViewController.CommandReturn:
                    returnToMain();
                    break;
                case FinishOrderViewController.CommandQuit:
                    break;
                default:
                    console.PromptInvalidCommand();
                    break;
            }

            return command;
        }
    }
}
