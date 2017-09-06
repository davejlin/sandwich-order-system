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

        private Dictionary<ViewStateNumber, Dictionary<string, Action>> menuCommandFunctions;

        private void initMenuCommandFunctions()
        {
            menuCommandFunctions = new Dictionary<ViewStateNumber, Dictionary<string, Action>>();

            var returnQuitCommandFunctions = createReturnQuitCommandFunctions();
            var deleteQuitCommandFunctions = createDeleteQuitCommandFunctions();

            var commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(ADD_COMMAND, () => context.ViewNumber = ViewStateNumber.Add);
            commandFunctionDict.Add(DELETE_COMMAND, () => context.ViewNumber = ViewStateNumber.Delete);
            commandFunctionDict.Add(LIST_COMMAND, () => context.ViewNumber = ViewStateNumber.List);
            commandFunctionDict.Add(FINISH_COMMAND, () => context.ViewNumber = ViewStateNumber.Finish);
            commandFunctionDict.Add(QUIT_COMMAND, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Main, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(SIGNATURE_SANDWICH_COMMAND, () => context.ViewNumber = ViewStateNumber.SignatureSandwich);
            commandFunctionDict.Add(CUSTOM_SANDWICH_COMMAND, () => context.ViewNumber = ViewStateNumber.Bread);
            commandFunctionDict = commandFunctionDict.Concat(returnQuitCommandFunctions).ToDictionary(x => x.Key, x => x.Value);

            menuCommandFunctions.Add(ViewStateNumber.Add, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(PAY_COMMAND, () => context.ViewNumber = ViewStateNumber.Pay);
            commandFunctionDict = commandFunctionDict.Concat(returnQuitCommandFunctions).ToDictionary(x => x.Key, x => x.Value);

            menuCommandFunctions.Add(ViewStateNumber.Finish, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(FINISH_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict = commandFunctionDict.Concat(deleteQuitCommandFunctions).ToDictionary(x => x.Key, x => x.Value);

            menuCommandFunctions.Add(ViewStateNumber.Review, commandFunctionDict);

            menuCommandFunctions.Add(ViewStateNumber.SignatureSandwich, createItemCommandFunction<SignatureSandwich>(ViewStateNumber.Drink));

            menuCommandFunctions.Add(ViewStateNumber.Bread, createItemCommandFunction<Bread>(ViewStateNumber.Filling));
            menuCommandFunctions.Add(ViewStateNumber.Filling, createItemCommandFunction<Filling>(ViewStateNumber.Cheese));

            menuCommandFunctions.Add(ViewStateNumber.Cheese, createItemCommandFunction<Cheese>(ViewStateNumber.Vegetable, true));
            menuCommandFunctions.Add(ViewStateNumber.Vegetable, createItemCommandFunction<Vegetable>(ViewStateNumber.Condiment, true));
            menuCommandFunctions.Add(ViewStateNumber.Condiment, createItemCommandFunction<Condiment>(ViewStateNumber.Drink, true));
            menuCommandFunctions.Add(ViewStateNumber.Drink, createItemCommandFunction<Drink>(ViewStateNumber.Chips, true));
            menuCommandFunctions.Add(ViewStateNumber.Chips, createItemCommandFunction<Chips>(ViewStateNumber.Review, true));

            menuCommandFunctions.Add(ViewStateNumber.CustomSandwich, deleteQuitCommandFunctions);
            menuCommandFunctions.Add(ViewStateNumber.List, returnQuitCommandFunctions);
            menuCommandFunctions.Add(ViewStateNumber.Delete, returnQuitCommandFunctions);
            menuCommandFunctions.Add(ViewStateNumber.Pay, returnQuitCommandFunctions);

            commandFunctionDict = new Dictionary<string, Action>();

            menuCommandFunctions.Add(ViewStateNumber.Quit, commandFunctionDict);
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

        private Dictionary<string, Action> createReturnQuitCommandFunctions()
        {
            var commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(RETURN_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(QUIT_COMMAND, () => context.ViewNumber = ViewStateNumber.Quit);
            return commandFunctionDict;
        }

        private Dictionary<string, Action> createDeleteQuitCommandFunctions()
        {
            var commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(DELETE_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(QUIT_COMMAND, () => context.ViewNumber = ViewStateNumber.Quit);
            return commandFunctionDict;
        }

        private Dictionary<string, Action> createItemCommandFunction<T>(ViewStateNumber nextState, bool addSkipForOptionalItem = false) where T : class, IItem
        {
            var commandFunctionDict = new Dictionary<string, Action>();
            var itemMenuCommands = viewModel.GetItemCommands<T>();

            foreach (string command in itemMenuCommands)
            {
                commandFunctionDict.Add(command, () => context.ViewNumber = nextState);
            }

            if (addSkipForOptionalItem)
            {
                commandFunctionDict.Add(SKIP_COMMAND, () => context.ViewNumber = nextState);
            }

            commandFunctionDict = commandFunctionDict.Concat(createDeleteQuitCommandFunctions()).ToDictionary(x => x.Key, x => x.Value);

            return commandFunctionDict;
        }
    }
}
