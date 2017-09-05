namespace SandwichOrderSystem.Views.ViewStates
{
    public class ViewContext : IViewContext
    {
        public ViewState MainState { get; }
        public ViewState CancelOrderState { get; }
        public ViewState DisplayOrderState { get; }
        public ViewState AddItemsState { get; }
        public ViewState FinishOrderState { get; }

        private ViewState state;
        public ViewState State
        {
            set
            {
                state = value;
                state.SetContext(this);
            } 
       }

        public ViewContext(
            MainState mainMenuState,
            CancelOrderState cancelOrderState,
            DisplayOrderState displayOrderState,
            AddItemsState addOrderState,
            FinishOrderState finishOrderState)
        {
            MainState = mainMenuState;
            CancelOrderState = cancelOrderState;
            DisplayOrderState = displayOrderState;
            AddItemsState = addOrderState;
            FinishOrderState = finishOrderState;

            State = mainMenuState;
        }

        public void Action()
        {
            state.Action();
        }

        public string MenuCommands()
        {
            return state.MenuCommands();
        }
    }
}
