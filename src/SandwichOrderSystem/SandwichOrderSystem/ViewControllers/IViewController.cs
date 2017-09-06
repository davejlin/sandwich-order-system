using SandwichOrderSystem.Views.ViewState;
using System.Collections.Generic;

namespace SandwichOrderSystem.ViewControllers
{
    public interface IViewController
    {
        void SetContext(IViewContext context);
        string MenuTitle { get; }
        IEnumerable<string> MenuCommands { get; }
        bool ExecuteUserCommand(string command);
    }
}
