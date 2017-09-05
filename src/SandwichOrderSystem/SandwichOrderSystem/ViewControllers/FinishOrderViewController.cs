namespace SandwichOrderSystem.ViewControllers
{
    public class FinishOrderViewController : IViewController
    {
        public string MenuCommands { get { return Constants.FINISH_ORDER_STATE_COMMANDS; } }
        public string MenuTitle { get { return Constants.FINISH_ORDER_STATE_TITLE; } }

        public const string CommandFinish = Constants.FINISH_ORDER_COMMAND_FINISH;
        public const string CommandQuit = Constants.VIEW_STATE_COMMAND_QUIT;
        public const string CommandReturn = Constants.VIEW_STATE_COMMAND_RETURN;
    }
}
