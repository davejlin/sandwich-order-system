using System;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController
    {
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
            commandFunctionDict.Add(ADD_MEAL_COMMAND_ADD_SIGNATURE_SANDWICH, () => { });
            commandFunctionDict.Add(ADD_MEAL_COMMAND_ADD_CUSTOM_SANDWICH, () => { });
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

        private Dictionary<ViewStateNumber, IEnumerable<string>> menuCommands;

        private void initMenuCommands()
        {
            string format = " {0} - {1} ";
            string blank = "";
            menuCommands = new Dictionary<ViewStateNumber, IEnumerable<string>>();

            var commandList = new List<string>();
            commandList.Add(string.Format(format, MAIN_STATE_COMMAND_ADD, ADD_MEAL_STATE_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(format, MAIN_STATE_COMMAND_DISPLAY, DISPLAY_ORDER_STATE_COMMAND_TITLE));
            commandList.Add(string.Format(format, MAIN_STATE_COMMAND_CANCEL, CANCEL_ORDER_STATE_COMMAND_TITLE));
            commandList.Add(string.Format(format, MAIN_STATE_COMMAND_FINISH, FINISH_ORDER_STATE_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(format, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Main, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(format, ADD_MEAL_COMMAND_ADD_SIGNATURE_SANDWICH, ADD_MEAL_STATE_SIGNATURE_SANDWICH_COMMAND_TITLE));
            commandList.Add(string.Format(format, ADD_MEAL_COMMAND_ADD_CUSTOM_SANDWICH, ADD_MEAL_STATE_CUSTOM_SANDWICH_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(format, VIEW_STATE_COMMAND_RETURN, VIEW_STATE_RETURN_COMMAND_TITLE));
            commandList.Add(string.Format(format, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Add, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(format, DISPLAY_ORDER_COMMAND_DISPLAY, DISPLAY_ORDER_STATE_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(format, VIEW_STATE_COMMAND_RETURN, VIEW_STATE_RETURN_COMMAND_TITLE));
            commandList.Add(string.Format(format, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Display, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(format, CANCEL_ORDER_COMMAND_CONFIRM, CANCEL_ORDER_STATE_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(format, VIEW_STATE_COMMAND_RETURN, VIEW_STATE_RETURN_COMMAND_TITLE));
            commandList.Add(string.Format(format, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Cancel, commandList);

            commandList = new List<string>();
            commandList.Add(string.Format(format, FINISH_ORDER_COMMAND_FINISH, FINISH_ORDER_STATE_COMMAND_TITLE));
            commandList.Add(blank);
            commandList.Add(string.Format(format, VIEW_STATE_COMMAND_RETURN, VIEW_STATE_RETURN_COMMAND_TITLE));
            commandList.Add(string.Format(format, VIEW_STATE_COMMAND_QUIT, VIEW_STATE_QUIT_COMMAND_TITLE));

            menuCommands.Add(ViewStateNumber.Finish, commandList);

            commandList = new List<string>();

            menuCommands.Add(ViewStateNumber.Quit, commandList);
        }
    }
}
