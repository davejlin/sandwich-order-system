using SandwichOrderSystem.ViewControllers;
using System.Collections.Generic;

namespace SandwichOrderSystem.Views
{
    public interface IViewState
    {
        void Action();
        string GetMenuCommand(string menuTitle, IEnumerable<string> menuCommands);
        void SetViewController(IViewController viewController);
    }
}
