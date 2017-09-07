using SandwichOrderSystem.ViewModels;
using SandwichOrderSystem.Views;
using System;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController : IViewController
    {
        private IViewState viewState;
        private IViewModel viewModel;
        private ViewContext viewContext;

        public ViewController(IViewState viewState, IViewModel viewModel)
        {
            this.viewState = viewState;
            this.viewModel = viewModel;

            viewContext = ViewContext.Main;
            initMenuCommands();
            initMenuSegueActions();
            initExecuteFuncs();
        }

        public void Start()
        {
            string currentCommand = "";
            IEnumerable<string> funcResponse = null;
            while (currentCommand != QUIT_COMMAND)
            {
                currentCommand = viewState.GetMenuCommand(MENU_TITLES[viewContext], menuCommands[viewContext], funcResponse);
                segue(currentCommand);
                funcResponse = executeFunc(currentCommand);
            }
        }

        private IEnumerable<string> executeFunc(string command)
        {
            return getExectueFunc(command)?
                .Invoke(command);
        }

        private Func<string, IEnumerable<string>> getExectueFunc(string command)
        {
            if (executeFuncs.ContainsKey(viewContext))
            {
                return executeFuncs[viewContext];
            }

            return null;
        }

        private void segue(string command)
        {
            var segueAction = getSegueAction(command);
            if (segueAction != null)
            {
                segueAction();
            }
            else
            {
                viewState.PromptInvalidCommand();
            }
        }

        private Action getSegueAction(string command)
        {
            if (menuSegueActions[viewContext].ContainsKey(command))
            {
                return menuSegueActions[viewContext][command];
            }

            return null;
        }
    }
}
