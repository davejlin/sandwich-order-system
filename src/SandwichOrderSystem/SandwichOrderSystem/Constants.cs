using System.Collections.Generic;

namespace SandwichOrderSystem
{
    public struct Constants
    {
        public enum ViewContext
        {
            Main = 0,
            Add,
            Show,
            Delete,
            Finish,
            Pay,
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

            Review
        }

        public const string GREETING_MESSAGE = "\n\n Welcome to the Sandwich Order System\n\n System initiliaizing ...";

        public const string CONSOLE_PROMPT_TO_CONTINUE = " Press Enter to continue:  ";
        public const string CONSOLE_INVALID_COMMAND = " Please enter a valid command ...";

        public const string COMMANDS_TITLE = " Commands:";
        public const string ENTER_COMMAND_TITLE = " Enter a Command: ";

        public const string MAIN_TITLE = " Main Menu ... ";
        public const string ADD_TITLE = " Please choose a Signature or Custom Sandwich ... ";
        public const string DELETE_TITLE = " Please confirm delete all orders ...";
        public const string SHOW_TITLE = " Here are your orders ... ";
        public const string FINISH_TITLE = " Please review your total order ... ";
        public const string REVIEW_TITLE = " Please review your order ... ";
        public const string SIGNATURE_SANDWICH_TITLE = " Please choose a Signature Sandwich ... ";
        public const string CUSTOM_SANDWICH_TITLE = " Custom Sandwich Menu ... ";
        public const string BREAD_TITLE = " Please choose your Bread ... ";
        public const string FILLING_TITLE = " Please choose your Filling ... ";
        public const string CHEESE_TITLE = " Please choose your Cheese (optional) ... ";
        public const string VEGETABLE_TITLE = " Please choose your Vegetables (optional, multiple allowed) ... ";
        public const string CONDIMENT_TITLE = " Please choose your Condiments (optional, multiple allowed) ... ";
        public const string DRINK_TITLE = " Please choose your Drink (optional) ... ";
        public const string CHIPS_TITLE = " Please choose your Chips (optional) ... ";
        public const string PAY_TITLE = " Thank you for your order! ... ";

        public const string ADD_COMMAND = "a";
        public const string SHOW_COMMAND = "s";

        public const string SIGNATURE_SANDWICH_COMMAND = "s";
        public const string CUSTOM_SANDWICH_COMMAND = "c";

        public const string DELETE_COMMAND = "d";
        public const string NEXT_COMMAND = "n";
        public const string PAY_COMMAND = "p";
        public const string FINISH_COMMAND = "f";

        public const string RETURN_COMMAND = "r";
        public const string QUIT_COMMAND = "q";

        public const string PAY_CREDIT_CARD_COMMAND = "c";
        public const string PAY_CASH_COMMAND = "h";

        public const string FINISH_PAY_CREDIT_CARD_COMMAND_TITLE = "Pay by credit card and checkout";
        public const string FINISH_PAY_CASH_COMMAND_TITLE = "Pay by cash and checkout";

        public const string SIGNATURE_SANDWICH_COMMAND_TITLE = "Add Signature Sandwich";
        public const string CUSTOM_SANDWICH_COMMAND_TITLE = "Add Custom Sandwich";

        public const string ADD_COMMAND_TITLE = "Add new order";
        public const string SHOW_COMMAND_TITLE = "Show orders";
        public const string DELETE_COMMAND_TITLE = "Delete orders";

        public const string FINISH_COMMAND_TITLE = "Finish orders";
        public const string FINISH_PAY_COMMAND_TITLE = "Pay and checkout";

        public const string REVIEW_FINISH_COMMAND_TITLE = "Finish this order";
        public const string REVIEW_DELETE_COMMAND_TITLE = "Delete this order";

        public const string NEXT_COMMAND_TITLE = "Next";

        public const string RETURN_COMMAND_TITLE = "Return to Main Menu";
        public const string QUIT_COMMAND_TITLE = "Quit";

        public const string SHOW_NO_ORDERS_TITLE = "\n\n You have no orders ...\n\n";
        public const string FINISH_COMPLETE_TITLE = "\n\n Your meal is being prepared and will be ready soon ...\n\n";

        public const string TOTAL_PRICE_TITLE = " Total Price:";

        public const string MENU_COMMAND_FORMAT = " {0} - {1,-20} {2,6}";
        public const string ITEM_LIST_FORMAT = " {0} - {1} ";
        public const string TOTAL_PRICE_FORMAT = " {0,-20} {1,10}";
        public const string EMPTY_STRING = "";

        public const int CONSOLE_WIDTH_PERCENTAGE_OF_MAX = 40;
        public const int CONSOLE_HEIGHT_PERCENTAGE_OF_MAX = 70;

        public static Dictionary<ViewContext, string> MENU_TITLES = new Dictionary<ViewContext, string> {
            { ViewContext.Main, MAIN_TITLE },
            { ViewContext.Add, ADD_TITLE },
            { ViewContext.Delete, DELETE_TITLE },
            { ViewContext.Show, SHOW_TITLE },
            { ViewContext.Finish, FINISH_TITLE },
            { ViewContext.Quit, EMPTY_STRING},
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
