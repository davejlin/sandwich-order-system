namespace SandwichOrderSystem.Views
{
    public interface IViewState
    {
        void Action();
        string MenuCommands();
        void SetContext(IViewContext context);
    }
}
