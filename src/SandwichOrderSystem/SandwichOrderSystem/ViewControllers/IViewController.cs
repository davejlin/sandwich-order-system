using SandwichOrderSystem.Views.ViewStates;
using System;

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
