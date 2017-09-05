using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.Views.ViewState
{
    public interface IViewContext
    {
        ViewStateNumber ViewNumber { get; set; }

        void Action();
        string MenuCommands();
    }
}