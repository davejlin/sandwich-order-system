namespace SandwichOrderSystem.ViewControllers
{
    public class MainStateViewController : IVewController
    {
        public string MenuCommands { get { return Constants.MAIN_STATE_COMMANDS; } }
        public string MenuTitle { get { return Constants.MAIN_STATE_TITLE; } }

        public const string CommandCancel = Constants.MAIN_STATE_COMMAND_CANCEL;
        public const string CommandQuit = Constants.VIEW_STATE_COMMAND_QUIT;
    }
}
