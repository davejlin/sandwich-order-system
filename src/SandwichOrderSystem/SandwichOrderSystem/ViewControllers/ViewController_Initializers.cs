using System;
using System.Collections.Generic;
using SandwichOrderSystemShared.Models;
using static SandwichOrderSystem.Constants;
using System.Linq;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController
    {
        string menuCommandFormat = " {0} - {1} ";
        string blank = "";

        private Dictionary<ViewContext, IEnumerable<string>> menuCommands;

        private void initMenuCommands()
        {
            menuCommands = new Dictionary<ViewContext, IEnumerable<string>>();

            var returnQuitCommands = createReturnQuitCommands();

            var commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, ADD_COMMAND, ADD_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, LIST_COMMAND, LIST_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, DELETE_COMMAND, DELETE_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, FINISH_COMMAND, FINISH_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, QUIT_COMMAND, QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewContext.Main, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, SIGNATURE_SANDWICH_COMMAND, SIGNATURE_SANDWICH_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, CUSTOM_SANDWICH_COMMAND, CUSTOM_SANDWICH_COMMAND_TITLE));
            commandList.AddRange(returnQuitCommands);

            menuCommands.Add(ViewContext.Add, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, FINISH_COMMAND, REVIEW_FINISH_COMMAND_TITLE));
            commandList.AddRange(createDeleteQuitCommands());

            menuCommands.Add(ViewContext.Review, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, PAY_COMMAND, FINISH_PAY_COMMAND_TITLE));
            commandList.AddRange(returnQuitCommands);

            menuCommands.Add(ViewContext.Finish, commandList);

            commandList = new List<string>();
            commandList.AddRange(returnQuitCommands);

            menuCommands.Add(ViewContext.List, commandList);
            menuCommands.Add(ViewContext.Delete, commandList);
            menuCommands.Add(ViewContext.CustomSandwich, commandList);
            menuCommands.Add(ViewContext.Pay, commandList);

            menuCommands.Add(ViewContext.SignatureSandwich, createItemCommandList<SignatureSandwich>());
            menuCommands.Add(ViewContext.Bread, createItemCommandList<Bread>());
            menuCommands.Add(ViewContext.Filling, createItemCommandList<Filling>());

            menuCommands.Add(ViewContext.Cheese, createItemCommandList<Cheese>(true));
            menuCommands.Add(ViewContext.Vegetable, createItemCommandList<Vegetable>(true));
            menuCommands.Add(ViewContext.Condiment, createItemCommandList<Condiment>(true));
            menuCommands.Add(ViewContext.Drink, createItemCommandList<Drink>(true));
            menuCommands.Add(ViewContext.Chips, createItemCommandList<Chips>(true));

            commandList = new List<string>();

            menuCommands.Add(ViewContext.Quit, commandList);
        }

        private Dictionary<ViewContext, Dictionary<string, Action>> menuSegueActions;

        private void initMenuSegueActions()
        {
            menuSegueActions = new Dictionary<ViewContext, Dictionary<string, Action>>();

            var returnQuitSegueActions = createReturnQuitSegueActions();
            var deleteQuitSegueActions = createDeleteQuitSegueActions();

            var segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(ADD_COMMAND, () => viewContext = ViewContext.Add);
            segueActionDict.Add(DELETE_COMMAND, () => viewContext = ViewContext.Delete);
            segueActionDict.Add(LIST_COMMAND, () => viewContext = ViewContext.List);
            segueActionDict.Add(FINISH_COMMAND, () => viewContext = ViewContext.Finish);
            segueActionDict.Add(QUIT_COMMAND, () => viewContext = ViewContext.Quit);

            menuSegueActions.Add(ViewContext.Main, segueActionDict);

            segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(SIGNATURE_SANDWICH_COMMAND, () => viewContext = ViewContext.SignatureSandwich);
            segueActionDict.Add(CUSTOM_SANDWICH_COMMAND, () => viewContext = ViewContext.Bread);
            segueActionDict = segueActionDict.Concat(returnQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);

            menuSegueActions.Add(ViewContext.Add, segueActionDict);

            segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(PAY_COMMAND, () => viewContext = ViewContext.Pay);
            segueActionDict = segueActionDict.Concat(returnQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);

            menuSegueActions.Add(ViewContext.Finish, segueActionDict);

            segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(FINISH_COMMAND, () => viewContext = ViewContext.Main);
            segueActionDict = segueActionDict.Concat(deleteQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);

            menuSegueActions.Add(ViewContext.Review, segueActionDict);

            menuSegueActions.Add(ViewContext.SignatureSandwich, createItemSegueActions<SignatureSandwich>(ViewContext.Drink));

            menuSegueActions.Add(ViewContext.Bread, createItemSegueActions<Bread>(ViewContext.Filling));
            menuSegueActions.Add(ViewContext.Filling, createItemSegueActions<Filling>(ViewContext.Cheese));

            menuSegueActions.Add(ViewContext.Cheese, createItemSegueActions<Cheese>(ViewContext.Vegetable, true));
            menuSegueActions.Add(ViewContext.Vegetable, createItemSegueActions<Vegetable>(ViewContext.Condiment, true));
            menuSegueActions.Add(ViewContext.Condiment, createItemSegueActions<Condiment>(ViewContext.Drink, true));
            menuSegueActions.Add(ViewContext.Drink, createItemSegueActions<Drink>(ViewContext.Chips, true));
            menuSegueActions.Add(ViewContext.Chips, createItemSegueActions<Chips>(ViewContext.Review, true));

            menuSegueActions.Add(ViewContext.CustomSandwich, deleteQuitSegueActions);

            menuSegueActions.Add(ViewContext.List, returnQuitSegueActions);
            menuSegueActions.Add(ViewContext.Delete, returnQuitSegueActions);
            menuSegueActions.Add(ViewContext.Pay, returnQuitSegueActions);

            segueActionDict = new Dictionary<string, Action>();

            menuSegueActions.Add(ViewContext.Quit, segueActionDict);
        }

        private IEnumerable<string> createReturnQuitCommands()
        {
            var commandList = new List<string>();
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, RETURN_COMMAND, RETURN_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, QUIT_COMMAND, QUIT_COMMAND_TITLE));
            return commandList;
        }

        private IEnumerable<string> createDeleteQuitCommands()
        {
            var commandList = new List<string>();
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, DELETE_COMMAND, REVIEW_DELETE_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, QUIT_COMMAND, QUIT_COMMAND_TITLE));
            return commandList;
        }

        private IEnumerable<string> createItemCommandList<T>(bool addSkipForOptionalItem = false) where T : class, IItem
        {
            var commandList = new List<string>();
            commandList.AddRange(viewModel.GetItemCommandMenu<T>());

            if (addSkipForOptionalItem)
            {
                commandList.Add(blank);
                commandList.Add(string.Format(menuCommandFormat, SKIP_COMMAND, SKIP_COMMAND_TITLE));
            }

            commandList.AddRange(createDeleteQuitCommands());
            return commandList;
        }

        private Dictionary<string, Action> createReturnQuitSegueActions()
        {
            var segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(RETURN_COMMAND, () => viewContext = ViewContext.Main);
            segueActionDict.Add(QUIT_COMMAND, () => viewContext = ViewContext.Quit);
            return segueActionDict;
        }

        private Dictionary<string, Action> createDeleteQuitSegueActions()
        {
            var segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(DELETE_COMMAND, () => viewContext = ViewContext.Main);
            segueActionDict.Add(QUIT_COMMAND, () => viewContext = ViewContext.Quit);
            return segueActionDict;
        }

        private Dictionary<string, Action> createItemSegueActions<T>(ViewContext nextState, bool addSkipForOptionalItem = false) where T : class, IItem
        {
            var commandActionDict = new Dictionary<string, Action>();
            var itemMenuCommands = viewModel.GetItemCommands<T>();

            foreach (string command in itemMenuCommands)
            {
                commandActionDict.Add(command, () => viewContext = nextState);
            }

            if (addSkipForOptionalItem)
            {
                commandActionDict.Add(SKIP_COMMAND, () => viewContext = nextState);
            }

            commandActionDict = commandActionDict.Concat(createDeleteQuitSegueActions()).ToDictionary(x => x.Key, x => x.Value);

            return commandActionDict;
        }
    }
}
