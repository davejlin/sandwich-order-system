﻿using System;
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
            commandList.Add(string.Format(menuCommandFormat, SHOW_COMMAND, SHOW_COMMAND_TITLE));
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

            menuCommands.Add(ViewContext.Show, commandList);
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
    }
}
