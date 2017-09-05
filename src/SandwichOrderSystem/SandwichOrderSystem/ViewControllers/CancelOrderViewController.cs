namespace SandwichOrderSystem.ViewControllers
{
    public class CancelOrderViewController : IVewController
    {
        public string MenuCommands { get { return Constants.CANCEL_ORDER_STATE_COMMANDS; } }
        public string MenuTitle { get { return Constants.CANCEL_ORDER_STATE_TITLE; } }

        public const string CommandConfirm = Constants.CANCEL_ORDER_COMMAND_CONFIRM;
        public const string CommandQuit = Constants.VIEW_STATE_COMMAND_QUIT;
        public const string CommandReturn = Constants.VIEW_STATE_COMMAND_RETURN;
        public const string ActionConfirm = Constants.CANCEL_ORDER_ACTION_CONFIRM;
        public const string ActionCommandConfirm = Constants.CANCEL_ORDER_ACTION_COMMAND_CONFIRM;
        public const string ActionComplete = Constants.CANCEL_ORDER_ACTION_COMPLETE;
        public const string ActionIncomplete = Constants.CANCEL_ORDER_ACTION_INCOMPLETE;
    }
}
