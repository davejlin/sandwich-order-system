using System;
using System.Collections.Generic;
using SandwichOrderSystemShared.Models;
using static SandwichOrderSystem.Constants;
using System.Linq;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController
    {
        private Dictionary<ViewContext, Dictionary<string, Action>> menuSegueActions;

        private void initMenuSegueActions()
        {
            menuSegueActions = new Dictionary<ViewContext, Dictionary<string, Action>>();

            var returnQuitSegueActions = createReturnQuitSegueActions();
            var deleteQuitSegueActions = createDeleteQuitSegueActions();

            var segueActionDict = new Dictionary<string, Action>();
            segueActionDict.Add(ADD_COMMAND, () => viewContext = ViewContext.Add);
            segueActionDict.Add(DELETE_COMMAND, () => viewContext = ViewContext.Delete);
            segueActionDict.Add(SHOW_COMMAND, () => viewContext = ViewContext.Show);
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

            menuSegueActions.Add(ViewContext.Cheese, createItemSegueActions<Cheese>(ViewContext.Vegetable, true, false));
            menuSegueActions.Add(ViewContext.Vegetable, createItemSegueActions<Vegetable>(ViewContext.Condiment, true, false));
            menuSegueActions.Add(ViewContext.Condiment, createItemSegueActions<Condiment>(ViewContext.Drink, true, false));
            menuSegueActions.Add(ViewContext.Drink, createItemSegueActions<Drink>(ViewContext.Chips, true, false));
            menuSegueActions.Add(ViewContext.Chips, createItemSegueActions<Chips>(ViewContext.Review, true, false));

            menuSegueActions.Add(ViewContext.CustomSandwich, deleteQuitSegueActions);

            menuSegueActions.Add(ViewContext.Show, returnQuitSegueActions);
            menuSegueActions.Add(ViewContext.Delete, returnQuitSegueActions);
            menuSegueActions.Add(ViewContext.Pay, returnQuitSegueActions);

            segueActionDict = new Dictionary<string, Action>();

            menuSegueActions.Add(ViewContext.Quit, segueActionDict);
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

        private Dictionary<string, Action> createItemSegueActions<T>(ViewContext nextState, bool shouldNextForOptionalItem = false, bool shouldSegueToNextState = true) where T : class, IItem
        {
            var commandActionDict = new Dictionary<string, Action>();
            var itemMenuCommands = viewModel.GetItemCommands<T>();

            if (shouldSegueToNextState)
            {
                foreach (string command in itemMenuCommands)
                {
                    commandActionDict.Add(command, () => viewContext = nextState);
                }
            }
            else
            {
                foreach (string command in itemMenuCommands)
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
        }
    }
}
