namespace SandwichOrderSystem.Views.ViewStates
{
    public interface IViewState
    {
        void Action();
        string MenuCommands();
        void SetContext(IViewContext context);
    }
}
