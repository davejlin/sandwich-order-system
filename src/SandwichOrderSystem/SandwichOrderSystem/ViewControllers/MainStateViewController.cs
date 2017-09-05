namespace SandwichOrderSystem.ViewControllers
{
    public class MainStateViewController
    {
        public string MenuCommands { get { return Constants.MAIN_STATE_COMMANDS; } }
        public string MenuTitle { get { return Constants.MAIN_STATE_TITLE; } }

        public const string CommandAdd = Constants.MAIN_STATE_COMMAND_ADD;
        public const string CommandCancel = Constants.MAIN_STATE_COMMAND_CANCEL;
        public const string CommandDisplay = Constants.MAIN_STATE_COMMAND_DISPLAY;
        public const string CommandFinish = Constants.MAIN_STATE_COMMAND_FINISH;
        public const string CommandQuit = Constants.VIEW_STATE_COMMAND_QUIT;
    }
}
