namespace SandwichOrderSystem.ViewControllers
{
    public class DisplayOrderViewController : IViewController
    {
        public string MenuCommands { get { return Constants.DISPLAY_ORDER_STATE_COMMANDS; } }
        public string MenuTitle { get { return Constants.DISPLAY_ORDER_STATE_TITLE; } }

        public const string CommandDisplay = Constants.DISPLAY_ORDER_COMMAND_DISPLAY;
        public const string CommandQuit = Constants.VIEW_STATE_COMMAND_QUIT;
        public const string CommandReturn = Constants.VIEW_STATE_COMMAND_RETURN;
    }
}
