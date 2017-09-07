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
            initMenuSegueActions();
            initMenuCommands();
        }

        public void Start()
        {
            string currentCommand = "";
            IEnumerable<string> funcResponse = null;
            while (currentCommand != QUIT_COMMAND)
            {
                currentCommand = viewState.GetMenuCommand(MENU_TITLES[viewContext], menuCommands[viewContext], funcResponse);
                funcResponse = executeFunc(currentCommand);
                segue(currentCommand);
            }
        }

        private IEnumerable<string> executeFunc(string command)
        {
            var response = getExectueFunc()?.Invoke();
            
            if (response != null)
            {
                return response;
            } else
            {
                return null;
            }
        }

        private Func<IEnumerable<string>> getExectueFunc()
        {
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
