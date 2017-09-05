namespace SandwichOrderSystem
{
    public struct Constants
    {
        public const string CONSOLE_PROMPT_TO_CONTINUE = " Press Enter to return to Main Menu: ";
        public const string CONSOLE_INVALID_COMMAND = " Please enter valid command.";

        public const string VIEW_STATE_COMMANDS_TITLE = " Commands:\n\n";
        public const string VIEW_STATE_ENTER_COMMAND_TITLE = " Enter a Command: ";

        public const string MAIN_STATE_TITLE = " Main Order Menu ... ";
        public const string ADD_ORDER_STATE_TITLE = " Add Order Menu ... ";
        public const string CANCEL_ORDER_STATE_TITLE = " Cancel Order Menu ... ";
        public const string DISPLAY_ORDER_STATE_TITLE = " Display Order Menu ... ";
        public const string FINISH_ORDER_STATE_TITLE = " Finish Order Menu ... ";

        public const string MAIN_STATE_COMMANDS = " a - Add Order Menu\n d - Display Order Menu\n c - Cancel Order Menu\n f - Finish Order Menu\n q - Quit";
        public const string ADD_ORDER_STATE_COMMANDS = " a - Add Order\n r - Return to Main Menu\n q - Quit";
        public const string DISPLAY_ORDER_STATE_COMMANDS = " d - Display Order\n r - Return to Main Menu\n q - Quit";
        public const string FINISH_ORDER_STATE_COMMANDS = " f - Finish Order\n r - Return to Main Menu\n q - Quit";
        public const string CANCEL_ORDER_STATE_COMMANDS = " c - Cancel Order\n r - Return to Main Menu\n q - Quit";

        public const string MAIN_STATE_COMMAND_ADD = "a";
        public const string MAIN_STATE_COMMAND_CANCEL = "c";
        public const string MAIN_STATE_COMMAND_DISPLAY = "d";
        public const string MAIN_STATE_COMMAND_FINISH = "f";

        public const string ADD_ORDER_COMMAND_ADD = "a";
        public const string CANCEL_ORDER_COMMAND_CONFIRM = "c";
        public const string CANCEL_ORDER_ACTION_COMMAND_CONFIRM = "Y";
        public const string DISPLAY_ORDER_COMMAND_DISPLAY = "d";
        public const string FINISH_ORDER_COMMAND_FINISH = "f";

        public const string VIEW_STATE_COMMAND_RETURN = "r";
        public const string VIEW_STATE_COMMAND_QUIT = "q";

        public const string CANCEL_ORDER_ACTION_CONFIRM = " Enter Y to confirm cancelling your order ... ";
        public const string CANCEL_ORDER_ACTION_COMPLETE = " Your order was cancelled.";
        public const string CANCEL_ORDER_ACTION_INCOMPLETE = " Your order was not cancelled.";



    }
}
