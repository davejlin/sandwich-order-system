using SandwichOrderSystem.Views;
using System;
using System.Collections.Generic;

namespace SandwichOrderSystem.ViewControllers
{
    public interface IViewController
    {
        void SetContext(IViewContext context);
        string MenuTitle { get; }
        IEnumerable<string> MenuCommands { get; }
        Action GetSegueAction(string command);
    }
}
