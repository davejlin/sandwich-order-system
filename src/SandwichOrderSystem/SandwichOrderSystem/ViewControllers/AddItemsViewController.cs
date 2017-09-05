namespace SandwichOrderSystem.ViewControllers
{
    public class AddItemsViewController : IViewController
    {
        public string MenuCommands { get { return Constants.ADD_ORDER_STATE_COMMANDS; } }
        public string MenuTitle { get { return Constants.ADD_ORDER_STATE_TITLE; } }

        public const string CommandAddSignatureSandwich = Constants.ADD_ORDER_COMMAND_ADD_SIGNATURE_SANDWICH;
        public const string CommandAddCustomSandwich = Constants.ADD_ORDER_COMMAND_ADD_CUSTOM_SANDWICH;
        public const string CommandAddChips = Constants.ADD_ORDER_COMMAND_ADD_CHIPS;
        public const string CommandAddDrink = Constants.ADD_ORDER_COMMAND_ADD_DRINK;
        public const string CommandQuit = Constants.VIEW_STATE_COMMAND_QUIT;
        public const string CommandReturn = Constants.VIEW_STATE_COMMAND_RETURN;
    }
}
