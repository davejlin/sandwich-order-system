using System;
using System.Collections.Generic;
using SandwichOrderSystemShared.Models;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController
    {
        private Dictionary<ViewStateNumber, IEnumerable<string>> menuCommands;

        private void initMenuCommands()
        {
            string menuCommandFormat = " {0} - {1} ";
            string blank = "";
            menuCommands = new Dictionary<ViewStateNumber, IEnumerable<string>>();

            var commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, MAIN_STATE_COMMAND_ADD, ADD_MEAL_STATE_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, MAIN_STATE_COMMAND_DISPLAY, DISPLAY_STATE_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, MAIN_STATE_COMMAND_CANCEL, CANCEL_STATE_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, MAIN_STATE_COMMAND_FINISH, FINISH_STATE_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Main, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, ADD_MEAL_COMMAND_ADD_SIGNATURE_SANDWICH, ADD_MEAL_STATE_SIGNATURE_SANDWICH_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, ADD_MEAL_COMMAND_ADD_CUSTOM_SANDWICH, ADD_MEAL_STATE_CUSTOM_SANDWICH_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_RETURN, VIEW_STATE_RETURN_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Add, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_RETURN, VIEW_STATE_RETURN_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Display, commandList);
            menuCommands.Add(ViewStateNumber.Cancel, commandList);
            menuCommands.Add(ViewStateNumber.Finish, commandList);
            menuCommands.Add(ViewStateNumber.CustomSandwich, commandList);

            commandList = new List<string>();
            commandList.AddRange(viewModel.GetItemForMenuCommands<SignatureSandwich>());
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, CANCEL_COMMAND, ADD_STATE_CANCEL_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.SignatureSandwich, commandList);

            commandList = new List<string>();
            commandList.AddRange(viewModel.GetItemForMenuCommands<Bread>());
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, CANCEL_COMMAND, ADD_STATE_CANCEL_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Bread, commandList);

            commandList = new List<string>();
            commandList.AddRange(viewModel.GetItemForMenuCommands<Filling>());
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, CANCEL_COMMAND, ADD_STATE_CANCEL_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Filling, commandList);

            commandList = new List<string>();
            commandList.AddRange(viewModel.GetItemForMenuCommands<Cheese>());
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, CANCEL_COMMAND, ADD_STATE_CANCEL_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Cheese, commandList);

            commandList = new List<string>();
            commandList.AddRange(viewModel.GetItemForMenuCommands<Vegetable>());
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, CANCEL_COMMAND, ADD_STATE_CANCEL_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Vegetable, commandList);

            commandList = new List<string>();
            commandList.AddRange(viewModel.GetItemForMenuCommands<Condiment>());
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, CANCEL_COMMAND, ADD_STATE_CANCEL_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Condiment, commandList);

            commandList = new List<string>();
            commandList.AddRange(viewModel.GetItemForMenuCommands<Drink>());
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, CANCEL_COMMAND, ADD_STATE_CANCEL_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Drink, commandList);

            commandList = new List<string>();
            commandList.AddRange(viewModel.GetItemForMenuCommands<Chips>());
            commandList.Add(blank);
            commandList.Add(string.Format(menuCommandFormat, CANCEL_COMMAND, ADD_STATE_CANCEL_COMMAND_TITLE));
            commandList.Add(string.Format(menuCommandFormat, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Chips, commandList);

            commandList = new List<string>();

            menuCommands.Add(ViewStateNumber.Quit, commandList);
        }

        private Dictionary<ViewStateNumber, Dictionary<string, Action>> menuCommandFunctions;

        private void initMenuCommandFunctions()
        {
            menuCommandFunctions = new Dictionary<ViewStateNumber, Dictionary<string, Action>>();

            var commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(MAIN_STATE_COMMAND_ADD, () => context.ViewNumber = ViewStateNumber.Add);
            commandFunctionDict.Add(MAIN_STATE_COMMAND_CANCEL, () => context.ViewNumber = ViewStateNumber.Cancel);
            commandFunctionDict.Add(MAIN_STATE_COMMAND_DISPLAY, () => context.ViewNumber = ViewStateNumber.Display);
            commandFunctionDict.Add(MAIN_STATE_COMMAND_FINISH, () => context.ViewNumber = ViewStateNumber.Finish);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Main, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(ADD_MEAL_COMMAND_ADD_SIGNATURE_SANDWICH, () => context.ViewNumber = ViewStateNumber.SignatureSandwich);
            commandFunctionDict.Add(ADD_MEAL_COMMAND_ADD_CUSTOM_SANDWICH, () => context.ViewNumber = ViewStateNumber.Bread);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_RETURN, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Add, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(VIEW_STATE_COMMAND_RETURN, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Display, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(VIEW_STATE_COMMAND_RETURN, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Cancel, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(VIEW_STATE_COMMAND_RETURN, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Finish, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(CANCEL_COMMAND, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.SignatureSandwich, commandFunctionDict);
            menuCommandFunctions.Add(ViewStateNumber.CustomSandwich, commandFunctionDict);
            menuCommandFunctions.Add(ViewStateNumber.Bread, commandFunctionDict);
            menuCommandFunctions.Add(ViewStateNumber.Filling, commandFunctionDict);
            menuCommandFunctions.Add(ViewStateNumber.Cheese, commandFunctionDict);
            menuCommandFunctions.Add(ViewStateNumber.Vegetable, commandFunctionDict);
            menuCommandFunctions.Add(ViewStateNumber.Condiment, commandFunctionDict);
            menuCommandFunctions.Add(ViewStateNumber.Drink, commandFunctionDict);
            menuCommandFunctions.Add(ViewStateNumber.Chips, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();

            menuCommandFunctions.Add(ViewStateNumber.Quit, commandFunctionDict);
        }
    }
}
