using System;
using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class MainState : ViewState
    {
        public MainState(IConsoleWrapper console) : base(console)
        {
        }

        private const string commandCancel = "c";
        private const string commandQuit = "q";

        public override string MenuCommands()
        {
            string command = menuPrompt(" Main Order Menu ... ", " c - Cancel Order\n q - Quit");
            switch (command)
            {
                case commandCancel:
                    context.State = context.CancelOrderState;
                    break;
                case commandQuit:
                    break;
                default:
                    console.PromptInvalidCommand();
                    break;
            }

            return command;
        }
    }
}
