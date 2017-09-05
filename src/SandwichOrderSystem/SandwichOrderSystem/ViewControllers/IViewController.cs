using SandwichOrderSystem.Views.ViewState;

namespace SandwichOrderSystem.ViewControllers
{
    public interface IViewController
    {
        void SetContext(IViewContext context);
        string MenuTitle { get; }
        string MenuCommands { get; }
        bool ExecuteUserCommand(string command);
    }
}
