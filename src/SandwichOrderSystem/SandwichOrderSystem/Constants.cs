using System.Collections.Generic;

namespace SandwichOrderSystem
{
    public struct Constants
    {
        public enum ViewStateNumber
        {
            Main = 0,
            Add,
            List,
            Delete,
            Finish,
            Quit,

            SignatureSandwich,
            CustomSandwich,

            Bread,
            Filling,
            Cheese,
            Vegetable,
            Condiment,

            Drink,
            Chips,

            Review,
            Pay,
        }

        public const string CONSOLE_PROMPT_TO_CONTINUE = " Press Enter to return to Main Menu: ";
        public const string CONSOLE_INVALID_COMMAND = " Please enter valid command.";

        public const string VIEW_STATE_COMMANDS_TITLE = " Commands:";
        public const string VIEW_STATE_ENTER_COMMAND_TITLE = " Enter a Command: ";

        public const string MAIN_STATE_TITLE = " Main Menu ... ";
        public const string ADD_MEAL_STATE_TITLE = " Add Meal Menu ... ";
        public const string DELETE_STATE_TITLE = " Delete Order ... ";
        public const string LIST_STATE_TITLE = " List Order ... ";
        public const string FINISH_STATE_TITLE = " Please review your total order ... ";
        public const string REVIEW_STATE_TITLE = " Please review your order ... ";
        public const string SIGNATURE_SANDWICH_STATE_TITLE = " Please choose a Signature Sandwich ... ";
        public const string CUSTOM_SANDWICH_STATE_TITLE = " Custom Sandwich Menu ... ";
        public const string BREAD_STATE_TITLE = " Please choose your Bread ... ";
        public const string FILLING_STATE_TITLE = " Please choose your Filling ... ";
        public const string CHEESE_STATE_TITLE = " Please choose your Cheese ... ";
        public const string VEGETABLE_STATE_TITLE = " Please choose your Vegetable ... ";
        public const string CONDIMENT_STATE_TITLE = " Please choose your Condiment ... ";
        public const string DRINK_STATE_TITLE = " Please choose your Drink ... ";
        public const string CHIPS_STATE_TITLE = " Please choose your Chips ... ";
        public const string PAY_STATE_TITLE = " Thank you for your order! ... ";

        public const string MAIN_STATE_ADD_COMMAND = "a";
        public const string MAIN_STATE_LIST_COMMAND = "l";
        public const string MAIN_STATE_FINISH_COMMAND = "f";

        public const string ADD_MEAL_SIGNATURE_SANDWICH_COMMAND = "s";
        public const string ADD_MEAL_CUSTOM_SANDWICH_COMMAND = "c";

        public const string DELETE_COMMAND = "d";
        public const string FINISH_STATE_PAY_COMMAND = "p";
        public const string REVIEW_STATE_FINISH_COMMAND = "f";

        public const string VIEW_STATE_COMMAND_RETURN = "r";
        public const string VIEW_STATE_COMMAND_QUIT = "q";

        public const string ADD_MEAL_STATE_SIGNATURE_SANDWICH_COMMAND_TITLE = "Add Signature Sandwich";
        public const string ADD_MEAL_STATE_CUSTOM_SANDWICH_COMMAND_TITLE = "Add Custom Sandwich";

        public const string ADD_MEAL_STATE_COMMAND_TITLE = "Add new order";
        public const string LIST_STATE_COMMAND_TITLE = "List orders";
        public const string DELETE_STATE_COMMAND_TITLE = "Delete order";

        public const string FINISH_STATE_COMMAND_TITLE = "Finish orders";
        public const string FINISH_STATE_PAY_COMMAND_TITLE = "Pay and checkout";

        public const string REVIEW_STATE_FINISH_COMMAND_TITLE = "Finish this order";

        public const string VIEW_STATE_DELETE_COMMAND_TITLE = "Delete this order";
        public const string VIEW_STATE_RETURN_COMMAND_TITLE = "Return to Main Menu";
        public const string VIEW_STATE_QUIT_COMMAND_TITLE = "Quit";

        public const string DELETE_ACTION_COMMAND_CONFIRM = "Y";
        public const string DELETE_ACTION_CONFIRM = " Enter Y to confirm deleting your order ... ";
        public const string DELETE_ACTION_COMPLETE = " Your order was deleted.";
        public const string DELETE_ACTION_INCOMPLETE = " Your order was not deleted.";

        public static Dictionary<ViewStateNumber, string> MENU_TITLES = new Dictionary<ViewStateNumber, string> {
            { ViewStateNumber.Main, MAIN_STATE_TITLE },
            { ViewStateNumber.Add, ADD_MEAL_STATE_TITLE },
            { ViewStateNumber.Delete, DELETE_STATE_TITLE },
            { ViewStateNumber.List, LIST_STATE_TITLE },
            { ViewStateNumber.Finish, FINISH_STATE_TITLE },
            { ViewStateNumber.Quit, ""},
            { ViewStateNumber.SignatureSandwich, SIGNATURE_SANDWICH_STATE_TITLE },
            { ViewStateNumber.CustomSandwich, CUSTOM_SANDWICH_STATE_TITLE },
            { ViewStateNumber.Bread, BREAD_STATE_TITLE },
            { ViewStateNumber.Filling, FILLING_STATE_TITLE },
            { ViewStateNumber.Cheese, CHEESE_STATE_TITLE },
            { ViewStateNumber.Vegetable, VEGETABLE_STATE_TITLE },
            { ViewStateNumber.Condiment, CONDIMENT_STATE_TITLE },
            { ViewStateNumber.Drink, DRINK_STATE_TITLE },
            { ViewStateNumber.Chips, CHIPS_STATE_TITLE },
            { ViewStateNumber.Review, REVIEW_STATE_TITLE },
            { ViewStateNumber.Pay, PAY_STATE_TITLE }
        };
    }
}
