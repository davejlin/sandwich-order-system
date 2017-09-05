namespace SandwichOrderSystem.ViewControllers
{
    public class AddOrderViewController : IVewController
    {
        public string MenuCommands { get { return Constants.ADD_ORDER_STATE_COMMANDS; } }
        public string MenuTitle { get { return Constants.ADD_ORDER_STATE_TITLE; } }

        public const string CommandAdd = Constants.ADD_ORDER_COMMAND_ADD;
        public const string CommandQuit = Constants.VIEW_STATE_COMMAND_QUIT;
        public const string CommandReturn = Constants.VIEW_STATE_COMMAND_RETURN;
    }
}
