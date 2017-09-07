using SandwichOrderSystem.ViewModels;
using SandwichOrderSystem.Views;
using System;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.ViewControllers
{
    public partial class ViewController : IViewController
    {
        private IViewState viewState;
        private IViewModel viewModel;
        private ViewContext viewContext;

        private string currentCommand = "";

        public ViewController(IViewState viewState, IViewModel viewModel)
        {
            this.viewState = viewState;
            this.viewModel = viewModel;

            viewContext = ViewContext.Main;
            initMenuSegueActions();
            initMenuCommands();
        }

        public void Start()
        {
            while (currentCommand != QUIT_COMMAND)
            {
                currentCommand = viewState.GetMenuCommand(MENU_TITLES[viewContext], menuCommands[viewContext]);

                segue();
            }
        }

        private void segue()
        {
            var segueAction = getSegueAction();
            if (segueAction != null)
            {
                segueAction();
            }
            else
            {
                viewState.PromptInvalidCommand();
            }
        }

        private Action getSegueAction()
        {
            if (menuSegueActions[viewContext].ContainsKey(currentCommand))
            {
                return menuSegueActions[viewContext][currentCommand];
            }

            return null;
        }
    }
}
