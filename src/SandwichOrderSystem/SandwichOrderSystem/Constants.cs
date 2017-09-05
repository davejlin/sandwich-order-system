namespace SandwichOrderSystem
{
    public struct Constants
    {
        public const string CONSOLE_PROMPT_TO_CONTINUE = " Press Enter to return to Main Menu: ";
        public const string CONSOLE_INVALID_COMMAND = " Please enter valid command.";

        public const string VIEW_STATE_COMMANDS_TITLE = " Commands:\n\n";
        public const string VIEW_STATE_ENTER_COMMAND_TITLE = " Enter a Command: ";

        public const string MAIN_STATE_TITLE = " Main Order Menu ... ";
        public const string CANCEL_ORDER_STATE_TITLE = " Cancel Order Menu ... ";

        public const string MAIN_STATE_COMMANDS = " c - Cancel Order\n q - Quit";
        public const string CANCEL_ORDER_STATE_COMMANDS = " c - Cancel Order\n r - Return to Main Menu\n q - Quit";

        public const string MAIN_STATE_COMMAND_CANCEL = "c";
        public const string CANCEL_ORDER_COMMAND_CONFIRM = "c";
        public const string CANCEL_ORDER_ACTION_COMMAND_CONFIRM = "Y";

        public const string VIEW_STATE_COMMAND_RETURN = "r";
        public const string VIEW_STATE_COMMAND_QUIT = "q";

        public const string CANCEL_ORDER_ACTION_CONFIRM = " Enter Y to confirm cancelling your order ... ";
        public const string CANCEL_ORDER_ACTION_COMPLETE = " Your order was cancelled.";
        public const string CANCEL_ORDER_ACTION_INCOMPLETE = " Your order was not cancelled.";
    }
}
