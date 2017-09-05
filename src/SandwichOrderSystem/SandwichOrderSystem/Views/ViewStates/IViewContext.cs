namespace SandwichOrderSystem.Views.ViewStates
{
    public interface IViewContext
    {
        ViewState MainState { get; }
        ViewState CancelOrderState { get; }
        ViewState DisplayOrderState { get; }
        ViewState AddOrderState { get; }
        ViewState FinishOrderState { get; }
        ViewState State { set; }

        string MenuCommands();
    }
}