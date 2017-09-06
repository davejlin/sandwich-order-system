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
            commandList.Add(string.Format(menuCommandFormat, MAIN_STATE_ADD_COMMAND, ADD_MEAL_STATE_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, MAIN_STATE_DISPLAY_COMMAND, DISPLAY_STATE_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, MAIN_STATE_CANCEL_COMMAND, CANCEL_STATE_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, MAIN_STATE_FINISH_COMMAND, FINISH_STATE_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Main, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, ADD_MEAL_SIGNATURE_SANDWICH_COMMAND, ADD_MEAL_STATE_SIGNATURE_SANDWICH_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, ADD_MEAL_CUSTOM_SANDWICH_COMMAND, ADD_MEAL_STATE_CUSTOM_SANDWICH_COMMAND_TITLE));
            commandList.AddRange(returnQuitCommands);

            menuCommands.Add(ViewStateNumber.Add, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, REVIEW_STATE_FINISH_COMMAND, REVIEW_STATE_ADD_COMMAND_TITLE));
            commandList.AddRange(returnQuitCommands);

            menuCommands.Add(ViewStateNumber.Review, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, FINISH_STATE_PAY_COMMAND, FINISH_STATE_PAY_COMMAND_TITLE));
            commandList.AddRange(returnQuitCommands);

            menuCommands.Add(ViewStateNumber.Finish, commandList);

            commandList = new List<string>();
            commandList.AddRange(returnQuitCommands);

            menuCommands.Add(ViewStateNumber.Display, commandList);
            menuCommands.Add(ViewStateNumber.Cancel, commandList);
            menuCommands.Add(ViewStateNumber.CustomSandwich, commandList);
            menuCommands.Add(ViewStateNumber.Pay, commandList);

            menuCommands.Add(ViewStateNumber.SignatureSandwich, createItemCommandList<SignatureSandwich>());
            menuCommands.Add(ViewStateNumber.Bread, createItemCommandList<Bread>());
            menuCommands.Add(ViewStateNumber.Filling, createItemCommandList<Filling>());
            menuCommands.Add(ViewStateNumber.Cheese, createItemCommandList<Cheese>());
            menuCommands.Add(ViewStateNumber.Vegetable, createItemCommandList<Vegetable>());
            menuCommands.Add(ViewStateNumber.Condiment, createItemCommandList<Condiment>());
            menuCommands.Add(ViewStateNumber.Drink, createItemCommandList<Drink>());
            menuCommands.Add(ViewStateNumber.Chips, createItemCommandList<Chips>());

            commandList = new List<string>();

            menuCommands.Add(ViewStateNumber.Quit, commandList);
        }

        private Dictionary<ViewStateNumber, Dictionary<string, Action>> menuCommandFunctions;

        private void initMenuCommandFunctions()
        {
            menuCommandFunctions = new Dictionary<ViewStateNumber, Dictionary<string, Action>>();

            var returnQuitCommandFunctions = createReturnQuitCommandFunctions();

            var commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(MAIN_STATE_ADD_COMMAND, () => context.ViewNumber = ViewStateNumber.Add);
            commandFunctionDict.Add(MAIN_STATE_CANCEL_COMMAND, () => context.ViewNumber = ViewStateNumber.Cancel);
            commandFunctionDict.Add(MAIN_STATE_DISPLAY_COMMAND, () => context.ViewNumber = ViewStateNumber.Display);
            commandFunctionDict.Add(MAIN_STATE_FINISH_COMMAND, () => context.ViewNumber = ViewStateNumber.Finish);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Main, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(ADD_MEAL_SIGNATURE_SANDWICH_COMMAND, () => context.ViewNumber = ViewStateNumber.SignatureSandwich);
            commandFunctionDict.Add(ADD_MEAL_CUSTOM_SANDWICH_COMMAND, () => context.ViewNumber = ViewStateNumber.Bread);
            commandFunctionDict = commandFunctionDict.Concat(returnQuitCommandFunctions).ToDictionary(x => x.Key, x => x.Value);

            menuCommandFunctions.Add(ViewStateNumber.Add, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(FINISH_STATE_PAY_COMMAND, () => context.ViewNumber = ViewStateNumber.Pay);
            commandFunctionDict = commandFunctionDict.Concat(returnQuitCommandFunctions).ToDictionary(x => x.Key, x => x.Value);

            menuCommandFunctions.Add(ViewStateNumber.Finish, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(REVIEW_STATE_FINISH_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict = commandFunctionDict.Concat(returnQuitCommandFunctions).ToDictionary(x => x.Key, x => x.Value);

            menuCommandFunctions.Add(ViewStateNumber.Review, commandFunctionDict);

            menuCommandFunctions.Add(ViewStateNumber.SignatureSandwich, createItemCommandFunction<SignatureSandwich>(ViewStateNumber.Drink));
            menuCommandFunctions.Add(ViewStateNumber.CustomSandwich, createItemCommandFunction<SignatureSandwich>(ViewStateNumber.Bread));
            menuCommandFunctions.Add(ViewStateNumber.Bread, createItemCommandFunction<SignatureSandwich>(ViewStateNumber.Filling));
            menuCommandFunctions.Add(ViewStateNumber.Filling, createItemCommandFunction<SignatureSandwich>(ViewStateNumber.Cheese));
            menuCommandFunctions.Add(ViewStateNumber.Cheese, createItemCommandFunction<SignatureSandwich>(ViewStateNumber.Vegetable));
            menuCommandFunctions.Add(ViewStateNumber.Vegetable, createItemCommandFunction<SignatureSandwich>(ViewStateNumber.Condiment));
            menuCommandFunctions.Add(ViewStateNumber.Condiment, createItemCommandFunction<SignatureSandwich>(ViewStateNumber.Drink));
            menuCommandFunctions.Add(ViewStateNumber.Drink, createItemCommandFunction<SignatureSandwich>(ViewStateNumber.Chips));
            menuCommandFunctions.Add(ViewStateNumber.Chips, createItemCommandFunction<SignatureSandwich>(ViewStateNumber.Review));


            menuCommandFunctions.Add(ViewStateNumber.Display, returnQuitCommandFunctions);
            menuCommandFunctions.Add(ViewStateNumber.Cancel, returnQuitCommandFunctions);
            menuCommandFunctions.Add(ViewStateNumber.Pay, returnQuitCommandFunctions);

            commandFunctionDict = new Dictionary<string, Action>();

            menuCommandFunctions.Add(ViewStateNumber.Quit, commandFunctionDict);
        }

        private IEnumerable<string> createReturnQuitCommands()
        {
            var commandList = new List<string>();
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_RETURN, VIEW_STATE_RETURN_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));
            return commandList;
        }

        private IEnumerable<string> createItemCommandList<T>() where T : class, IItem
        {
            var commandList = new List<string>();
            commandList.AddRange(viewModel.GetItemCommandMenu<T>());
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, CANCEL_COMMAND, ADD_STATE_CANCEL_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));
            return commandList;
        }

        private Dictionary<string, Action> createReturnQuitCommandFunctions()
        {
            var commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(VIEW_STATE_COMMAND_RETURN, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);
            return commandFunctionDict;
        }

        private Dictionary<string, Action> createItemCommandFunction<T>(ViewStateNumber nextState) where T : class, IItem
        {
            var commandFunctionDict = new Dictionary<string, Action>();
            var itemMenuCommands = viewModel.GetItemCommands<T>();

            foreach (string command in itemMenuCommands)
            {
                commandFunctionDict.Add(command, () => context.ViewNumber = nextState);
            }

            commandFunctionDict.Add(CANCEL_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            return commandFunctionDict;
        }
    }
}
