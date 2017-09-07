using SandwichOrderSystem.ViewModels;
using SandwichOrderSystem.Views;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController : IViewController
    {
        private IViewModel viewModel;
        private IViewContext context;
        private string command;

        public ViewController(IViewModel viewModel)
        {
            this.viewModel = viewModel;

            initMenuSegueActions();
            initMenuCommands();
        }

        public void SetContext(IViewContext context)
        {
            this.context = context;
        }

        public string MenuTitle
        {
            get
            {
                return MENU_TITLES[context.ViewNumber];
            }
        }

        public IEnumerable<string> MenuCommands
        {
            get
            {
                return menuCommands[context.ViewNumber];
            }
        }

        public bool ExecuteUserCommand(string command)
        {
            this.command = command;

            if (menuSegueActions[context.ViewNumber].ContainsKey(command))
            {
                var segueFunction = menuSegueActions[context.ViewNumber][command];
                segueFunction();
                return true;
            }

            return false;
        }
    }
}
