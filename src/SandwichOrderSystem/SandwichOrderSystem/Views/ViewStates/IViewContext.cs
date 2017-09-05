namespace SandwichOrderSystem.Views.ViewStates
{
    public interface IViewContext
    {
        ViewState MainState { get; }
        ViewState CancelOrderState { get; }
        ViewState DisplayOrderState { get; }
        ViewState AddItemsState { get; }
        ViewState FinishOrderState { get; }
        ViewState State { set; }

        void Action();
        string MenuCommands();
    }
}