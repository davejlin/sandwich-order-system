namespace SandwichOrderSystem.Views.ViewState
{
    public interface IViewState
    {
        void Action();
        string MenuCommands();
        void SetContext(IViewContext context);
    }
}
