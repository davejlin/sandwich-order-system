using System;
using System.Collections.Generic;
using SandwichOrderSystemShared.Models;
using static SandwichOrderSystem.Constants;
using System.Linq;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController
    {
        private Dictionary<ViewContext, Func<Dictionary<string, Action>>> menuSegueFuncs;

        private void initMenuSegueFuncs()
        {
            menuSegueFuncs = new Dictionary<ViewContext, Func<Dictionary<string, Action>>>();

            var returnQuitSegueActions = createReturnQuitSegueActions();
            var deleteQuitSegueActions = createDeleteQuitSegueActions();

            // Main

            Func<Dictionary<string, Action>> func = () =>
            {
                var segueActionDict = new Dictionary<string, Action>();
                segueActionDict.Add(ADD_COMMAND, () => viewContext = ViewContext.Add);
                if (viewModel.GetOrdersCount() > 0)
                {
                    segueActionDict.Add(SHOW_COMMAND, () => viewContext = ViewContext.Show);
                    segueActionDict.Add(FINISH_COMMAND, () => viewContext = ViewContext.Finish);
                    segueActionDict.Add(DELETE_COMMAND, () => viewContext = ViewContext.Delete);
                }
                segueActionDict.Add(QUIT_COMMAND, () => viewContext = ViewContext.Quit);
                return segueActionDict;
            };


            menuSegueFuncs.Add(ViewContext.Main, func);

            // Add

            func = () =>
            {
                var segueActionDict = new Dictionary<string, Action>();
                segueActionDict.Add(SIGNATURE_SANDWICH_COMMAND, () => viewContext = ViewContext.SignatureSandwich);
                segueActionDict.Add(CUSTOM_SANDWICH_COMMAND, () => viewContext = ViewContext.Bread);
                segueActionDict = segueActionDict.Concat(returnQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);
                return segueActionDict;
            };

            menuSegueFuncs.Add(ViewContext.Add, func);

            // Review

            func = () => 
            {
                var segueActionDict = new Dictionary<string, Action>();
                segueActionDict.Add(FINISH_COMMAND, () => viewContext = ViewContext.Main);
                segueActionDict = segueActionDict.Concat(deleteQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);
                return segueActionDict;
            };

            menuSegueFuncs.Add(ViewContext.Review, func);

            // Finish

            func = () =>
            {
                var segueActionDict = new Dictionary<string, Action>();
                segueActionDict.Add(PAY_CREDIT_CARD_COMMAND, () => viewContext = ViewContext.Pay);
                segueActionDict.Add(PAY_CASH_COMMAND, () => viewContext = ViewContext.Pay);
                segueActionDict = segueActionDict.Concat(returnQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);
                return segueActionDict;
            };

            menuSegueFuncs.Add(ViewContext.Finish, func);

            // Delete

            func = () =>
            {
                var segueActionDict = new Dictionary<string, Action>();
                segueActionDict.Add(DELETE_COMMAND, () => viewContext = ViewContext.Main);
                segueActionDict = segueActionDict.Concat(returnQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);
                return segueActionDict;
            };

            menuSegueFuncs.Add(ViewContext.Delete, func);

            // Show, Pay, Quit
            // CustomSandwich (no direct segues from Custom Sandwich, since we land first in Bread upon user choosing Custom Sandwich)

            func = () => {
                var segueActionDict = new Dictionary<string, Action>();
                segueActionDict = segueActionDict.Concat(returnQuitSegueActions).ToDictionary(x => x.Key, x => x.Value);
                return segueActionDict;
            };

            menuSegueFuncs.Add(ViewContext.Show, func);
            menuSegueFuncs.Add(ViewContext.Pay, func);
            menuSegueFuncs.Add(ViewContext.CustomSandwich, func);
            menuSegueFuncs.Add(ViewContext.Quit, func);

            // Items

            menuSegueFuncs.Add(ViewContext.SignatureSandwich, createItemSegueFuncs<SignatureSandwich>(ViewContext.Drink));

            menuSegueFuncs.Add(ViewContext.Bread, createItemSegueFuncs<Bread>(ViewContext.Filling));
            menuSegueFuncs.Add(ViewContext.Filling, createItemSegueFuncs<Filling>(ViewContext.Cheese));

            menuSegueFuncs.Add(ViewContext.Cheese, createItemSegueFuncs<Cheese>(ViewContext.Vegetable, true));
            menuSegueFuncs.Add(ViewContext.Vegetable, createItemSegueFuncs<Vegetable>(ViewContext.Condiment, true, false));
            menuSegueFuncs.Add(ViewContext.Condiment, createItemSegueFuncs<Condiment>(ViewContext.Drink, true, false));
            menuSegueFuncs.Add(ViewContext.Drink, createItemSegueFuncs<Drink>(ViewContext.Chips, true));
            menuSegueFuncs.Add(ViewContext.Chips, createItemSegueFuncs<Chips>(ViewContext.Review, true));
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

        private Func<Dictionary<string, Action>> createItemSegueFuncs<T>(ViewContext nextState, bool shouldNextForOptionalItem = false, bool shouldSegueToNextState = true) where T : class, IItem
        {
            return () =>
            {
                var commandActionDict = new Dictionary<string, Action>();
                var menuItemCommands = viewModel.GetMenuItemCommands<T>();

                if (shouldSegueToNextState)
                {
                    foreach (string command in menuItemCommands)
                    {
                        commandActionDict.Add(command, () => viewContext = nextState);
                    }
                }
                else
                {
                    foreach (string command in menuItemCommands)
                    {
                        commandActionDict.Add(command, () => { });
                    }
                }

                if (shouldNextForOptionalItem)
                {
                    commandActionDict.Add(NEXT_COMMAND, () => viewContext = nextState);
                }

                commandActionDict = commandActionDict.Concat(createDeleteQuitSegueActions()).ToDictionary(x => x.Key, x => x.Value);

                return commandActionDict;
            };
        }
    }
}
