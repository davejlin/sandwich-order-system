﻿using SandwichOrderSystem.ViewModels;
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
        private IEnumerable<string> currentOutputList = new List<string>();
        private IEnumerable<string> previousOutputList = new List<string>();
        private Action segue;

        public ViewController(IViewState viewState, IViewModel viewModel)
        {
            this.viewState = viewState;
            this.viewModel = viewModel;

            viewContext = ViewContext.Main;
            initMenuCommands();
            initMenuSegueFuncs();
            initExecuteFuncs();
        }

        public string AdvanceViewCycle()
        {
            var menuTitle = MENU_TITLES[viewContext];
            var menuCommandsList = invokeMenuCommandsFunc();

            currentCommand = viewState.GetMenuCommand(menuTitle, menuCommandsList, currentOutputList);

            getSegue(currentCommand);

            previousOutputList = currentOutputList;
            currentOutputList = invokeExecuteFunc(currentCommand);

            invokeSegue();

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
            if (command != null)
            {
                if (executeFuncs.ContainsKey(viewContext) && executeFuncs[viewContext].ContainsKey(command))
                {
                    return executeFuncs[viewContext][command];
                }
            }

            return null;
        }

        private void getSegue(string command)
        {
            if (command != null)
            {
                if (menuSegueFuncs.ContainsKey(viewContext))
                {
                    var segueFunc = menuSegueFuncs[viewContext];
                    var segueActions = segueFunc();
                    if (segueActions.ContainsKey(command))
                    {
                        segue = segueActions[command];
                        return;
                    }
                }
            }

            segue = null;
        }

        private void invokeSegue()
        {
            if (segue == null)
            {
                viewState.PromptInvalidCommand();
                currentOutputList = previousOutputList;
            }
            else
            {
                segue();
            }
        }
    }
}
