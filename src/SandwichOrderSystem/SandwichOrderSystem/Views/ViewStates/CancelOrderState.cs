using System;
using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class CancelOrderState : ViewState
    {
        public CancelOrderState(IConsoleWrapper console) : base(console)
        {
        }

        public void Action()
        {
            console.ClearOutput();
            string command = console.ReadInput(" Enter Y to confirm cancelling your order ... ", false);

            console.ClearOutput();
            switch (command)
            {
                case "Y":
                    console.OutputLine(" Your order was cancelled.", true);
                    break;
                default:
                    console.OutputLine(" Your order was not cancelled.", true);
                    break;
            }

            console.PromptToContinue();
            returnToMain();
        }

        private const string commandConfirm = "c";
        private const string commandReturn = "r";
        private const string commandQuit = "q";

        public override string MenuCommands()
        {
            string command = menuPrompt(" Cancel Order Menu ... ", " c - Cancel Order\n r - Return to Main Menu\n q - Quit");
            switch (command)
            {
                case commandConfirm:
                    Action();
                    break;
                case commandReturn:
                    returnToMain();
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
