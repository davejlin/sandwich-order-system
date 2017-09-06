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
        public const string ADD_MEAL_STATE_TITLE = " Add Meal Menu ... ";
        public const string CANCEL_ORDER_STATE_TITLE = " Cancel Order Menu ... ";
        public const string DISPLAY_ORDER_STATE_TITLE = " Display Order Menu ... ";
        public const string FINISH_ORDER_STATE_TITLE = " Finish Order Menu ... ";

        public const string MAIN_STATE_COMMAND_ADD = "a";
        public const string MAIN_STATE_COMMAND_CANCEL = "c";
        public const string MAIN_STATE_COMMAND_DISPLAY = "d";
        public const string MAIN_STATE_COMMAND_FINISH = "f";

        public const string ADD_MEAL_COMMAND_ADD_SIGNATURE_SANDWICH = "s";
        public const string ADD_MEAL_COMMAND_ADD_CUSTOM_SANDWICH = "c";
        public const string ADD_MEAL_COMMAND_ADD_CHIPS = "h";
        public const string ADD_MEAL_COMMAND_ADD_DRINK = "d";

        public const string CANCEL_ORDER_COMMAND_CONFIRM = "c";
        public const string CANCEL_ORDER_ACTION_COMMAND_CONFIRM = "Y";

        public const string DISPLAY_ORDER_COMMAND_DISPLAY = "d";
        public const string FINISH_ORDER_COMMAND_FINISH = "f";

        public const string VIEW_STATE_COMMAND_RETURN = "r";
        public const string VIEW_STATE_COMMAND_QUIT = "q";

        public const string CANCEL_ORDER_ACTION_CONFIRM = " Enter Y to confirm cancelling your order ... ";
        public const string CANCEL_ORDER_ACTION_COMPLETE = " Your order was cancelled.";
        public const string CANCEL_ORDER_ACTION_INCOMPLETE = " Your order was not cancelled.";

        public const string ADD_MEAL_STATE_SIGNATURE_SANDWICH_COMMAND_TITLE = "Add Signature Sandwich";
        public const string ADD_MEAL_STATE_CUSTOM_SANDWICH_COMMAND_TITLE = "Add Custom Sandwich";

        public const string ADD_DRINK_STATE_COMMAND_TITLE = "Add Drink";
        public const string ADD_CHIPS_STATE_COMMAND_TITLE = "Add Chips";
        public const string ADD_CONDIMENT_STATE_COMMAND_TITLE = "Add Condiment";
        public const string ADD_CHEESE_STATE_COMMAND_TITLE = "Add Cheese";
        public const string ADD_VEGETABLE_STATE_COMMAND_TITLE = "Add Vegetable";

        public const string ADD_MEAL_STATE_COMMAND_TITLE = "Add Meal";
        public const string DISPLAY_ORDER_STATE_COMMAND_TITLE = "Display Order";
        public const string CANCEL_ORDER_STATE_COMMAND_TITLE = "Cancel Order";
        public const string FINISH_ORDER_STATE_COMMAND_TITLE = "Finish Order Checkout";

        public const string VIEW_STATE_RETURN_COMMAND_TITLE = "Return to Main Menu";
        public const string VIEW_STATE_QUIT_COMMAND_TITLE = "Quit";

        public static Dictionary<ViewStateNumber, string> MENU_TITLES = new Dictionary<ViewStateNumber, string> {
            { ViewStateNumber.Main, MAIN_STATE_TITLE },
            { ViewStateNumber.Add, ADD_MEAL_STATE_TITLE },
            { ViewStateNumber.Cancel, CANCEL_ORDER_STATE_TITLE },
            { ViewStateNumber.Display, DISPLAY_ORDER_STATE_TITLE },
            { ViewStateNumber.Finish, FINISH_ORDER_STATE_TITLE }
        };
    }
}
