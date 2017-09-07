using System.Collections.Generic;

namespace SandwichOrderSystem.Views
{
    public interface IViewState
    {
        string GetMenuCommand(string menuTitle, IEnumerable<string> menuCommands, IEnumerable<string> output);

        void PromptInvalidCommand();
        void PromptToContinue();
    }
}
