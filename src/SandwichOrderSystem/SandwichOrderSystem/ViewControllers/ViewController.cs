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

            viewState.SetViewController(this);

            initMenuSegueActions();
            initMenuCommands();
        }

        public void Start()
        {
            while (currentCommand != QUIT_COMMAND)
            {
                currentCommand = viewState.GetMenuCommand(MENU_TITLES[viewContext], menuCommands[viewContext]);
                viewState.Action();
            }
        }

        public Action GetSegueAction()
        {
            if (menuSegueActions[viewContext].ContainsKey(currentCommand))
            {
                return menuSegueActions[viewContext][currentCommand];
            }

            return null;
        }
    }
}
