using System.Collections.Generic;

namespace SandwichOrderSystem
{
    public struct Constants
    {
        public enum ViewContext
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

        public const string COMMANDS_TITLE = " Commands:";
        public const string ENTER_COMMAND_TITLE = " Enter a Command: ";

        public const string MAIN_TITLE = " Main Menu ... ";
        public const string ADD_TITLE = " Please choose a Signature or Custom Sandwich ... ";
        public const string DELETE_TITLE = " Deleted your orders ... ";
        public const string LIST_TITLE = " Here are your orders ... ";
        public const string FINISH_TITLE = " Please review your total order ... ";
        public const string REVIEW_TITLE = " Please review your order ... ";
        public const string SIGNATURE_SANDWICH_TITLE = " Please choose a Signature Sandwich ... ";
        public const string CUSTOM_SANDWICH_TITLE = " Custom Sandwich Menu ... ";
        public const string BREAD_TITLE = " Please choose your Bread ... ";
        public const string FILLING_TITLE = " Please choose your Filling ... ";
        public const string CHEESE_TITLE = " Please choose your Cheese ... ";
        public const string VEGETABLE_TITLE = " Please choose your Vegetable ... ";
        public const string CONDIMENT_TITLE = " Please choose your Condiment ... ";
        public const string DRINK_TITLE = " Please choose your Drink ... ";
        public const string CHIPS_TITLE = " Please choose your Chips ... ";
        public const string PAY_TITLE = " Thank you for your order! ... ";

        public const string ADD_COMMAND = "a";
        public const string LIST_COMMAND = "l";

        public const string SIGNATURE_SANDWICH_COMMAND = "s";
        public const string CUSTOM_SANDWICH_COMMAND = "c";

        public const string DELETE_COMMAND = "d";
        public const string SKIP_COMMAND = "s";

        public const string PAY_COMMAND = "p";
        public const string FINISH_COMMAND = "f";

        public const string RETURN_COMMAND = "r";
        public const string QUIT_COMMAND = "q";

        public const string SIGNATURE_SANDWICH_COMMAND_TITLE = "Add Signature Sandwich";
        public const string CUSTOM_SANDWICH_COMMAND_TITLE = "Add Custom Sandwich";

        public const string ADD_COMMAND_TITLE = "Add new order";
        public const string LIST_COMMAND_TITLE = "List orders";
        public const string DELETE_COMMAND_TITLE = "Delete order";

        public const string FINISH_COMMAND_TITLE = "Finish orders";
        public const string FINISH_PAY_COMMAND_TITLE = "Pay and checkout";

        public const string REVIEW_FINISH_COMMAND_TITLE = "Finish this order";
        public const string REVIEW_DELETE_COMMAND_TITLE = "Delete this order";

        public const string SKIP_COMMAND_TITLE = "Skip this extra item";

        public const string RETURN_COMMAND_TITLE = "Return to Main Menu";
        public const string QUIT_COMMAND_TITLE = "Quit";

        public const string DELETE_ACTION_COMMAND_CONFIRM = "Y";
        public const string DELETE_ACTION_CONFIRM = " Enter Y to confirm deleting your order ... ";
        public const string DELETE_ACTION_COMPLETE = " Your order was deleted.";
        public const string DELETE_ACTION_INCOMPLETE = " Your order was not deleted.";

        public static Dictionary<ViewContext, string> MENU_TITLES = new Dictionary<ViewContext, string> {
            { ViewContext.Main, MAIN_TITLE },
            { ViewContext.Add, ADD_TITLE },
            { ViewContext.Delete, DELETE_TITLE },
            { ViewContext.List, LIST_TITLE },
            { ViewContext.Finish, FINISH_TITLE },
            { ViewContext.Quit, ""},
            { ViewContext.SignatureSandwich, SIGNATURE_SANDWICH_TITLE },
            { ViewContext.CustomSandwich, CUSTOM_SANDWICH_TITLE },
            { ViewContext.Bread, BREAD_TITLE },
            { ViewContext.Filling, FILLING_TITLE },
            { ViewContext.Cheese, CHEESE_TITLE },
            { ViewContext.Vegetable, VEGETABLE_TITLE },
            { ViewContext.Condiment, CONDIMENT_TITLE },
            { ViewContext.Drink, DRINK_TITLE },
            { ViewContext.Chips, CHIPS_TITLE },
            { ViewContext.Review, REVIEW_TITLE },
            { ViewContext.Pay, PAY_TITLE }
        };
    }
}
