using SandwichOrderSystem.Views.ViewStates;
using System;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.ViewControllers
{
    public class ViewController : IViewController
    {
        private IViewContext context;
        private string command;

        public ViewController()
        {
            initMenuCommandFunctions();
        }

        public void SetContext(IViewContext context)
        {
            this.context = context;
        }

        public string MenuTitle
        {
            get
            {
                return Constants.MENU_TITLES[context.ViewNumber];
            }
        }

        public string MenuCommands
        {
            get
            {
                return Constants.MENU_COMMANDS[context.ViewNumber];
            }
        }

        public bool ExecuteUserCommand(string command)
        {
            this.command = command;

            if (menuCommandFunctions[context.ViewNumber].ContainsKey(command))
            {
                var commandFunction = menuCommandFunctions[context.ViewNumber][command];
                commandFunction();
                return true;
            }

            return false;
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
            commandFunctionDict.Add(VIEW_STATE_COMMAND_RETURN, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Main, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(ADD_ITEMS_COMMAND_ADD_SIGNATURE_SANDWICH, () => { });
            commandFunctionDict.Add(ADD_ITEMS_COMMAND_ADD_CUSTOM_SANDWICH, () => { });
            commandFunctionDict.Add(ADD_ITEMS_COMMAND_ADD_CHIPS, () => { });
            commandFunctionDict.Add(ADD_ITEMS_COMMAND_ADD_DRINK, () => { });
            commandFunctionDict.Add(VIEW_STATE_COMMAND_RETURN, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Add, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(DISPLAY_ORDER_COMMAND_DISPLAY, () => { });
            commandFunctionDict.Add(VIEW_STATE_COMMAND_RETURN, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Display, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(CANCEL_ORDER_COMMAND_CONFIRM, () => { });
            commandFunctionDict.Add(VIEW_STATE_COMMAND_RETURN, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Cancel, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();
            commandFunctionDict.Add(FINISH_ORDER_COMMAND_FINISH, () => { });
            commandFunctionDict.Add(VIEW_STATE_COMMAND_RETURN, () => context.ViewNumber = ViewStateNumber.Main);
            commandFunctionDict.Add(VIEW_STATE_COMMAND_QUIT, () => context.ViewNumber = ViewStateNumber.Quit);

            menuCommandFunctions.Add(ViewStateNumber.Finish, commandFunctionDict);

            commandFunctionDict = new Dictionary<string, Action>();

            menuCommandFunctions.Add(ViewStateNumber.Quit, commandFunctionDict);
        }
    }
}
