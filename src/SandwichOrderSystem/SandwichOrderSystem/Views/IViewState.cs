using System.Collections.Generic;

namespace SandwichOrderSystem.Views
{
    public interface IViewState
    {
        string GetMenuCommand(string menuTitle, IEnumerable<string> menuCommands);

        void PromptInvalidCommand();
        void PromptToContinue();
    }
}
