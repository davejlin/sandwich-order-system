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

        private void initMenuSegueFunctions()
        {
            menuCommandFunctions = new Dictionary<ViewStateNumber, Dictionary<string, Action>>();

            var returnQuitSegueFunctions = createReturnQuitSegueFunctions();
            var deleteQuitSegueFunctions = createDeleteQuitSegueFunctions();

            var segueFunctionDict = new Dictionary<string, Action>();
            segueFunctionDict.Add(ADD_COMMAND, () => context.ViewNumber = ViewStateNumber.Add);
            segueFunctionDict.Add(DELETE_COMMAND, () => context.ViewNumber = ViewStateNumber.Delete);
            segueFunctionDict.Add(LIST_COMMAND, () => context.ViewNumber = ViewStateNumber.List);
            segueFunctionDict.Add(FINISH_COMMAND, () => context.ViewNumber = ViewStateNumber.Finish);
            segueFunctionDict.Add(QUIT_COMMAND, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Main, segueFunctionDict);

            segueFunctionDict = new Dictionary<string, Action>();
            segueFunctionDict.Add(SIGNATURE_SANDWICH_COMMAND, () => context.ViewNumber = ViewStateNumber.SignatureSandwich);
            segueFunctionDict.Add(CUSTOM_SANDWICH_COMMAND, () => context.ViewNumber = ViewStateNumber.Bread);
            segueFunctionDict = segueFunctionDict.Concat(returnQuitSegueFunctions).ToDictionary(x => x.Key, x => x.Value);

            menuCommandFunctions.Add(ViewStateNumber.Add, segueFunctionDict);

            segueFunctionDict = new Dictionary<string, Action>();
            segueFunctionDict.Add(PAY_COMMAND, () => context.ViewNumber = ViewStateNumber.Pay);
            segueFunctionDict = segueFunctionDict.Concat(returnQuitSegueFunctions).ToDictionary(x => x.Key, x => x.Value);

            menuCommandFunctions.Add(ViewStateNumber.Finish, segueFunctionDict);

            segueFunctionDict = new Dictionary<string, Action>();
            segueFunctionDict.Add(FINISH_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            segueFunctionDict = segueFunctionDict.Concat(deleteQuitSegueFunctions).ToDictionary(x => x.Key, x => x.Value);

            menuCommandFunctions.Add(ViewStateNumber.Review, segueFunctionDict);

            menuCommandFunctions.Add(ViewStateNumber.SignatureSandwich, createItemSegueFunctions<SignatureSandwich>(ViewStateNumber.Drink));

            menuCommandFunctions.Add(ViewStateNumber.Bread, createItemSegueFunctions<Bread>(ViewStateNumber.Filling));
            menuCommandFunctions.Add(ViewStateNumber.Filling, createItemSegueFunctions<Filling>(ViewStateNumber.Cheese));

            menuCommandFunctions.Add(ViewStateNumber.Cheese, createItemSegueFunctions<Cheese>(ViewStateNumber.Vegetable, true));
            menuCommandFunctions.Add(ViewStateNumber.Vegetable, createItemSegueFunctions<Vegetable>(ViewStateNumber.Condiment, true));
            menuCommandFunctions.Add(ViewStateNumber.Condiment, createItemSegueFunctions<Condiment>(ViewStateNumber.Drink, true));
            menuCommandFunctions.Add(ViewStateNumber.Drink, createItemSegueFunctions<Drink>(ViewStateNumber.Chips, true));
            menuCommandFunctions.Add(ViewStateNumber.Chips, createItemSegueFunctions<Chips>(ViewStateNumber.Review, true));

            menuCommandFunctions.Add(ViewStateNumber.CustomSandwich, deleteQuitSegueFunctions);

            menuCommandFunctions.Add(ViewStateNumber.List, returnQuitSegueFunctions);
            menuCommandFunctions.Add(ViewStateNumber.Delete, returnQuitSegueFunctions);
            menuCommandFunctions.Add(ViewStateNumber.Pay, returnQuitSegueFunctions);

            segueFunctionDict = new Dictionary<string, Action>();

            menuCommandFunctions.Add(ViewStateNumber.Quit, segueFunctionDict);
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

        private Dictionary<string, Action> createReturnQuitSegueFunctions()
        {
            var segueFunctionDict = new Dictionary<string, Action>();
            segueFunctionDict.Add(RETURN_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            segueFunctionDict.Add(QUIT_COMMAND, () => context.ViewNumber = ViewStateNumber.Quit);
            return segueFunctionDict;
        }

        private Dictionary<string, Action> createDeleteQuitSegueFunctions()
        {
            var segueFunctionDict = new Dictionary<string, Action>();
            segueFunctionDict.Add(DELETE_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            segueFunctionDict.Add(QUIT_COMMAND, () => context.ViewNumber = ViewStateNumber.Quit);
            return segueFunctionDict;
        }

        private Dictionary<string, Action> createItemSegueFunctions<T>(ViewStateNumber nextState, bool addSkipForOptionalItem = false) where T : class, IItem
        {
            var segueFunctionDict = new Dictionary<string, Action>();
            var itemMenuCommands = viewModel.GetItemCommands<T>();

            foreach (string command in itemMenuCommands)
            {
                segueFunctionDict.Add(command, () => context.ViewNumber = nextState);
            }

            if (addSkipForOptionalItem)
            {
                segueFunctionDict.Add(SKIP_COMMAND, () => context.ViewNumber = nextState);
            }

            segueFunctionDict = segueFunctionDict.Concat(createDeleteQuitSegueFunctions()).ToDictionary(x => x.Key, x => x.Value);

            return segueFunctionDict;
        }
    }
}
