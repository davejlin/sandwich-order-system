using System;
using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.States.Level1
{
    public class MainState : Level1State
    {
        public MainState(IConsoleWrapper console) : base(console)
        {
        }

        public override void Action()
        {
            // no action
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
