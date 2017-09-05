using System.Collections.Generic;

namespace SandwichOrderSystem
{
    public struct Constants
    {
        public enum ViewStateNumber
        {
            Main = 0,
            Add,
            Display,
            Cancel,
            Finish,
            Quit
        }

        public const string CONSOLE_PROMPT_TO_CONTINUE = " Press Enter to return to Main Menu: ";
        public const string CONSOLE_INVALID_COMMAND = " Please enter valid command.";

        public const string VIEW_STATE_COMMANDS_TITLE = " Commands:\n\n";
        public const string VIEW_STATE_ENTER_COMMAND_TITLE = " Enter a Command: ";

        public const string MAIN_STATE_TITLE = " Main Order Menu ... ";
        public const string ADD_ITEMS_STATE_TITLE = " Add Items Menu ... ";
        public const string CANCEL_ORDER_STATE_TITLE = " Cancel Order Menu ... ";
        public const string DISPLAY_ORDER_STATE_TITLE = " Display Order Menu ... ";
        public const string FINISH_ORDER_STATE_TITLE = " Finish Order Menu ... ";

        public const string MAIN_STATE_COMMAND_ADD = "a";
        public const string MAIN_STATE_COMMAND_CANCEL = "c";
        public const string MAIN_STATE_COMMAND_DISPLAY = "d";
        public const string MAIN_STATE_COMMAND_FINISH = "f";

        public const string ADD_ITEMS_COMMAND_ADD_SIGNATURE_SANDWICH = "s";
        public const string ADD_ITEMS_COMMAND_ADD_CUSTOM_SANDWICH = "c";
        public const string ADD_ITEMS_COMMAND_ADD_CHIPS = "h";
        public const string ADD_ITEMS_COMMAND_ADD_DRINK = "d";

        public const string CANCEL_ORDER_COMMAND_CONFIRM = "c";
        public const string CANCEL_ORDER_ACTION_COMMAND_CONFIRM = "Y";

        public const string DISPLAY_ORDER_COMMAND_DISPLAY = "d";
        public const string FINISH_ORDER_COMMAND_FINISH = "f";

        public const string VIEW_STATE_COMMAND_RETURN = "r";
        public const string VIEW_STATE_COMMAND_QUIT = "q";

        public const string CANCEL_ORDER_ACTION_CONFIRM = " Enter Y to confirm cancelling your order ... ";
        public const string CANCEL_ORDER_ACTION_COMPLETE = " Your order was cancelled.";
        public const string CANCEL_ORDER_ACTION_INCOMPLETE = " Your order was not cancelled.";

        public const string MAIN_STATE_COMMANDS = " a - Add Items Menu\n d - Display Order\n c - Cancel Order\n\n f - Finish Order\n\n q - Quit";
        public const string ADD_ITEMS_STATE_COMMANDS = " s - Add Signature Sandwich\n c - Add Custom Sandwich\n d - Add Drink\n h - Add Chips\n\n r - Return to Main Menu\n q - Quit";
        public const string DISPLAY_ORDER_STATE_COMMANDS = " d - Display Order\n\n r - Return to Main Menu\n q - Quit";
        public const string FINISH_ORDER_STATE_COMMANDS = " f - Finish Order\n\n r - Return to Main Menu\n q - Quit";
        public const string CANCEL_ORDER_STATE_COMMANDS = " c - Cancel Order\n\n r - Return to Main Menu\n q - Quit";

        public static Dictionary<ViewStateNumber, string> MENU_TITLES = new Dictionary<ViewStateNumber, string> {
            { ViewStateNumber.Main, MAIN_STATE_TITLE },
            { ViewStateNumber.Add, ADD_ITEMS_STATE_TITLE },
            { ViewStateNumber.Cancel, CANCEL_ORDER_STATE_TITLE },
            { ViewStateNumber.Display, DISPLAY_ORDER_STATE_TITLE },
            { ViewStateNumber.Finish, FINISH_ORDER_STATE_TITLE }
        };

        public static Dictionary<ViewStateNumber, string> MENU_COMMANDS = new Dictionary<ViewStateNumber, string> {
            { ViewStateNumber.Main, MAIN_STATE_COMMANDS },
            { ViewStateNumber.Add, ADD_ITEMS_STATE_COMMANDS },
            { ViewStateNumber.Cancel, CANCEL_ORDER_STATE_COMMANDS },
            { ViewStateNumber.Display, DISPLAY_ORDER_STATE_COMMANDS },
            { ViewStateNumber.Finish, FINISH_ORDER_STATE_COMMANDS }
        };

    }
}
