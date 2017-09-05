using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.Views.ViewStates
{
    public interface IViewContext
    {
        ViewStateNumber ViewNumber { get; set; }

        void Action();
        string MenuCommands();
    }
}