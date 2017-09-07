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

        private Dictionary<ViewStateNumber, IEnumerable<string>> menuCommands;

        private void initMenuCommands()
        {
            menuCommands = new Dictionary<ViewStateNumber, IEnumerable<string>>();

            var returnQuitCommands = createReturnQuitCommands();

            var commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, ADD_COMMAND, ADD_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, LIST_COMMAND, LIST_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, DELETE_COMMAND, DELETE_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, FINISH_COMMAND, FINISH_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, QUIT_COMMAND, QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Main, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, SIGNATURE_SANDWICH_COMMAND, SIGNATURE_SANDWICH_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, CUSTOM_SANDWICH_COMMAND, CUSTOM_SANDWICH_COMMAND_TITLE));
            commandList.AddRange(returnQuitCommands);

            menuCommands.Add(ViewStateNumber.Add, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, FINISH_COMMAND, REVIEW_FINISH_COMMAND_TITLE));
            commandList.AddRange(createDeleteQuitCommands());

            menuCommands.Add(ViewStateNumber.Review, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, PAY_COMMAND, FINISH_PAY_COMMAND_TITLE));
            commandList.AddRange(returnQuitCommands);

            menuCommands.Add(ViewStateNumber.Finish, commandList);

            commandList = new List<string>();
            commandList.AddRange(returnQuitCommands);

            menuCommands.Add(ViewStateNumber.List, commandList);
            menuCommands.Add(ViewStateNumber.Delete, commandList);
            menuCommands.Add(ViewStateNumber.CustomSandwich, commandList);
            menuCommands.Add(ViewStateNumber.Pay, commandList);

            menuCommands.Add(ViewStateNumber.SignatureSandwich, createItemCommandList<SignatureSandwich>());
            menuCommands.Add(ViewStateNumber.Bread, createItemCommandList<Bread>());
            menuCommands.Add(ViewStateNumber.Filling, createItemCommandList<Filling>());

            menuCommands.Add(ViewStateNumber.Cheese, createItemCommandList<Cheese>(true));
            menuCommands.Add(ViewStateNumber.Vegetable, createItemCommandList<Vegetable>(true));
            menuCommands.Add(ViewStateNumber.Condiment, createItemCommandList<Condiment>(true));
            menuCommands.Add(ViewStateNumber.Drink, createItemCommandList<Drink>(true));
            menuCommands.Add(ViewStateNumber.Chips, createItemCommandList<Chips>(true));

            commandList = new List<string>();

            menuCommands.Add(ViewStateNumber.Quit, commandList);
        }

        private Dictionary<ViewStateNumber, Dictionary<string, Action>> menuSegueActions;

        private void initMenuSegueActions()
        {
            menuSegueActions = new Dictionary<ViewStateNumber, Dictionary<string, Action>>();

            var returnQuitSegueActions = createReturnQuitSegueActions();
            var deleteQuitSegueActions = createDeleteQuitSegueActions();

            var segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(ADD_COMMAND, () => context.ViewNumber = ViewStateNumber.Add);
            segueActionDict.Add(DELETE_COMMAND, () => context.ViewNumber = ViewStateNumber.Delete);
            segueActionDict.Add(LIST_COMMAND, () => context.ViewNumber = ViewStateNumber.List);
            segueActionDict.Add(FINISH_COMMAND, () => context.ViewNumber = ViewStateNumber.Finish);
            segueActionDict.Add(QUIT_COMMAND, () => context.ViewNumber = ViewStateNumber.Quit);

            menuSegueActions.Add(ViewStateNumber.Main, segueActionDict);

            segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(SIGNATURE_SANDWICH_COMMAND, () => context.ViewNumber = ViewStateNumber.SignatureSandwich);
            segueActionDict.Add(CUSTOM_SANDWICH_COMMAND, () => context.ViewNumber = ViewStateNumber.Bread);
            segueActionDict = segueActionDict.Concat(returnQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);

            menuSegueActions.Add(ViewStateNumber.Add, segueActionDict);

            segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(PAY_COMMAND, () => context.ViewNumber = ViewStateNumber.Pay);
            segueActionDict = segueActionDict.Concat(returnQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);

            menuSegueActions.Add(ViewStateNumber.Finish, segueActionDict);

            segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(FINISH_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            segueActionDict = segueActionDict.Concat(deleteQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);

            menuSegueActions.Add(ViewStateNumber.Review, segueActionDict);

            menuSegueActions.Add(ViewStateNumber.SignatureSandwich, createItemSegueActions<SignatureSandwich>(ViewStateNumber.Drink));

            menuSegueActions.Add(ViewStateNumber.Bread, createItemSegueActions<Bread>(ViewStateNumber.Filling));
            menuSegueActions.Add(ViewStateNumber.Filling, createItemSegueActions<Filling>(ViewStateNumber.Cheese));

            menuSegueActions.Add(ViewStateNumber.Cheese, createItemSegueActions<Cheese>(ViewStateNumber.Vegetable, true));
            menuSegueActions.Add(ViewStateNumber.Vegetable, createItemSegueActions<Vegetable>(ViewStateNumber.Condiment, true));
            menuSegueActions.Add(ViewStateNumber.Condiment, createItemSegueActions<Condiment>(ViewStateNumber.Drink, true));
            menuSegueActions.Add(ViewStateNumber.Drink, createItemSegueActions<Drink>(ViewStateNumber.Chips, true));
            menuSegueActions.Add(ViewStateNumber.Chips, createItemSegueActions<Chips>(ViewStateNumber.Review, true));

            menuSegueActions.Add(ViewStateNumber.CustomSandwich, deleteQuitSegueActions);

            menuSegueActions.Add(ViewStateNumber.List, returnQuitSegueActions);
            menuSegueActions.Add(ViewStateNumber.Delete, returnQuitSegueActions);
            menuSegueActions.Add(ViewStateNumber.Pay, returnQuitSegueActions);

            segueActionDict = new Dictionary<string, Action>();

            menuSegueActions.Add(ViewStateNumber.Quit, segueActionDict);
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
            segueActionDict.Add(RETURN_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            segueActionDict.Add(QUIT_COMMAND, () => context.ViewNumber = ViewStateNumber.Quit);
            return segueActionDict;
        }

        private Dictionary<string, Action> createDeleteQuitSegueActions()
        {
            var segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(DELETE_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            segueActionDict.Add(QUIT_COMMAND, () => context.ViewNumber = ViewStateNumber.Quit);
            return segueActionDict;
        }

        private Dictionary<string, Action> createItemSegueActions<T>(ViewStateNumber nextState, bool addSkipForOptionalItem = false) where T : class, IItem
        {
            var commandActionDict = new Dictionary<string, Action>();
            var itemMenuCommands = viewModel.GetItemCommands<T>();

            foreach (string command in itemMenuCommands)
            {
                commandActionDict.Add(command, () => context.ViewNumber = nextState);
            }

            if (addSkipForOptionalItem)
            {
                commandActionDict.Add(SKIP_COMMAND, () => context.ViewNumber = nextState);
            }

            commandActionDict = commandActionDict.Concat(createDeleteQuitSegueActions()).ToDictionary(x => x.Key, x => x.Value);

            return commandActionDict;
        }
    }
}
