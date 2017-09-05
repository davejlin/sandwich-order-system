using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.Views.ViewState
{
    public class ViewContext : IViewContext
    {
        private IViewState viewState;
        public ViewStateNumber ViewNumber { get; set; }

        public ViewContext(IViewState viewState)
        {
            this.viewState = viewState;
            this.viewState.SetContext(this);
            ViewNumber = 0;
        }

        public void Action()
        {
            viewState.Action();
        }

        public string MenuCommands()
        {
            return viewState.MenuCommands();
        }
    }
}
