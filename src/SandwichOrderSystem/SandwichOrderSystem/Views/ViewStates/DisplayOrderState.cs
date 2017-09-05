using System;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class DisplayOrderState : ViewState
    {
        public DisplayOrderState(IConsoleWrapper console) : base(console)
        {
        }

        public override string MenuCommands()
        {
            throw new NotImplementedException();
        }
    }
}
