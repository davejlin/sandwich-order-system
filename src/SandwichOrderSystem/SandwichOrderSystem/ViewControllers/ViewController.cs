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

        private string currentCommand = EMPTY_STRING;
        private IEnumerable<string> currentFuncResponse = new List<string>();
        private IEnumerable<string> previousFuncResponse = new List<string>();

        public ViewController(IViewState viewState, IViewModel viewModel)
        {
            this.viewState = viewState;
            this.viewModel = viewModel;

            viewContext = ViewContext.Main;
            initMenuCommands();
            initMenuSegueActions();
            initExecuteFuncs();
        }

        public string AdvanceViewCycle()
        {
            var menuTitle = MENU_TITLES[viewContext];
            var menuCommandsList = invokeMenuCommandsFunc();

            currentCommand = viewState.GetMenuCommand(menuTitle, menuCommandsList, currentFuncResponse);

            previousFuncResponse = currentFuncResponse;
            currentFuncResponse = invokeExecuteFunc(currentCommand);

            segue(currentCommand);

            return currentCommand;
        }

        private IEnumerable<string> invokeMenuCommandsFunc()
        {
            return getMenuCommandsFunc()?
                .Invoke();
        }

        private Func<IEnumerable<string>> getMenuCommandsFunc()
        {
            if (menuCommandsFuncs.ContainsKey(viewContext))
            {
                return menuCommandsFuncs[viewContext];
            }
            else
            {
                return null;
            }
        }

        private IEnumerable<string> invokeExecuteFunc(string command)
        {
            return getExectueFunc(command)?
                .Invoke(command);
        }

        private Func<string, IEnumerable<string>> getExectueFunc(string command)
        {
            if (executeFuncs.ContainsKey(viewContext) && executeFuncs[viewContext].ContainsKey(command))
            {
                return executeFuncs[viewContext][command];
            }
            else
            {
                return null;
            }
        }

        private void segue(string command)
        {
            var segueAction = getSegueAction(command);
            if (segueAction == null)
            {
                viewState.PromptInvalidCommand();
                currentFuncResponse = previousFuncResponse;
            }
            else
            {
                segueAction();
            }
        }

        private Action getSegueAction(string command)
        {
            if (menuSegueActions.ContainsKey(viewContext) && menuSegueActions[viewContext].ContainsKey(command))
            {
                return menuSegueActions[viewContext][command];
            }
            else
            {
                return null;
            }
        }
    }
}
