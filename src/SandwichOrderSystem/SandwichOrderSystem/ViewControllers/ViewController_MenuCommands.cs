using System;
using System.Collections.Generic;
using SandwichOrderSystemShared.Models;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController
    {
        private Dictionary<ViewContext, Func<IEnumerable<string>>> menuCommandsFuncs;

        private void initMenuCommands()
        {
            menuCommandsFuncs = new Dictionary<ViewContext, Func<IEnumerable<string>>>();

            var returnQuitCommands = createReturnQuitCommands();

            // Main

            Func<IEnumerable<string>> func = () =>
            {
                var commandList = new List<string>();
                commandList.Add(string.Format(ITEM_LIST_FORMAT, ADD_COMMAND, ADD_COMMAND_TITLE));
                if (viewModel.GetOrdersCount() > 0)
                {
                    commandList.Add(EMPTY_STRING);
                    commandList.Add(string.Format(ITEM_LIST_FORMAT, SHOW_COMMAND, SHOW_COMMAND_TITLE));
                    commandList.Add(string.Format(ITEM_LIST_FORMAT, DELETE_COMMAND, DELETE_COMMAND_TITLE));
                    commandList.Add(string.Format(ITEM_LIST_FORMAT, FINISH_COMMAND, FINISH_COMMAND_TITLE));
                }
                commandList.Add(EMPTY_STRING);
                commandList.Add(string.Format(ITEM_LIST_FORMAT, QUIT_COMMAND, QUIT_COMMAND_TITLE));
                return commandList;
            };

            menuCommandsFuncs.Add(ViewContext.Main, func);

            // Add

            func = () =>
            {
                var commandList = new List<string>();
                commandList.Add(string.Format(ITEM_LIST_FORMAT, SIGNATURE_SANDWICH_COMMAND, SIGNATURE_SANDWICH_COMMAND_TITLE));
                commandList.Add(string.Format(ITEM_LIST_FORMAT, CUSTOM_SANDWICH_COMMAND, CUSTOM_SANDWICH_COMMAND_TITLE));
                commandList.AddRange(returnQuitCommands);
                return commandList;
            };

            menuCommandsFuncs.Add(ViewContext.Add, func);

            // Review

            func = () =>
            {
                var commandList = new List<string>();
                commandList.Add(string.Format(ITEM_LIST_FORMAT, FINISH_COMMAND, REVIEW_FINISH_COMMAND_TITLE));
                commandList.AddRange(createDeleteQuitCommands());
                return commandList;
            };

            menuCommandsFuncs.Add(ViewContext.Review, func);

            // Finish

            func = () =>
            {
                var commandList = new List<string>();
                commandList.Add(string.Format(ITEM_LIST_FORMAT, PAY_COMMAND, FINISH_PAY_COMMAND_TITLE));
                commandList.AddRange(returnQuitCommands);

                return commandList;
            };

            menuCommandsFuncs.Add(ViewContext.Finish, func);

            // Delete

            func = () =>
            {
                var commandList = new List<string>();
                commandList.Add(string.Format(ITEM_LIST_FORMAT, DELETE_COMMAND, DELETE_COMMAND_TITLE));
                commandList.AddRange(returnQuitCommands);
                return commandList;
            };

            menuCommandsFuncs.Add(ViewContext.Delete, func);

            // Show, Pay, Custom Sandwich

            func = () =>
            {
                var commandList = new List<string>();
                commandList.AddRange(returnQuitCommands);
                return commandList;
            };

            menuCommandsFuncs.Add(ViewContext.Show, func);
            menuCommandsFuncs.Add(ViewContext.Pay, func);
            menuCommandsFuncs.Add(ViewContext.CustomSandwich, func);
            menuCommandsFuncs.Add(ViewContext.Quit, func);

            // Items

            menuCommandsFuncs.Add(ViewContext.SignatureSandwich, createItemCommandList<SignatureSandwich>());
            menuCommandsFuncs.Add(ViewContext.Bread, createItemCommandList<Bread>());
            menuCommandsFuncs.Add(ViewContext.Filling, createItemCommandList<Filling>());

            menuCommandsFuncs.Add(ViewContext.Cheese, createItemCommandList<Cheese>(true));
            menuCommandsFuncs.Add(ViewContext.Vegetable, createItemCommandList<Vegetable>(true));
            menuCommandsFuncs.Add(ViewContext.Condiment, createItemCommandList<Condiment>(true));
            menuCommandsFuncs.Add(ViewContext.Drink, createItemCommandList<Drink>(true));
            menuCommandsFuncs.Add(ViewContext.Chips, createItemCommandList<Chips>(true));
        }

        private IEnumerable<string> createReturnQuitCommands()
        {
            var commandList = new List<string>();
            commandList.Add(EMPTY_STRING);
            commandList.Add(string.Format(ITEM_LIST_FORMAT, RETURN_COMMAND, RETURN_COMMAND_TITLE));
            commandList.Add(string.Format(ITEM_LIST_FORMAT, QUIT_COMMAND, QUIT_COMMAND_TITLE));
            return commandList;
        }

        private IEnumerable<string> createDeleteQuitCommands()
        {
            var commandList = new List<string>();
            commandList.Add(EMPTY_STRING);
            commandList.Add(string.Format(ITEM_LIST_FORMAT, DELETE_COMMAND, REVIEW_DELETE_COMMAND_TITLE));
            commandList.Add(string.Format(ITEM_LIST_FORMAT, QUIT_COMMAND, QUIT_COMMAND_TITLE));
            return commandList;
        }

        private Func<IEnumerable<string>> createItemCommandList<T>(bool addNextForOptionalItem = false) where T : class, IItem
        {
            return () =>
            {
                var commandList = new List<string>();
                commandList.AddRange(viewModel.GetItemCommandMenu<T>());

                if (addNextForOptionalItem)
                {
                    commandList.Add(EMPTY_STRING);
                    commandList.Add(string.Format(ITEM_LIST_FORMAT, NEXT_COMMAND, NEXT_COMMAND_TITLE));
                }

                commandList.AddRange(createDeleteQuitCommands());
                return commandList;
            };
        }
    }
}
