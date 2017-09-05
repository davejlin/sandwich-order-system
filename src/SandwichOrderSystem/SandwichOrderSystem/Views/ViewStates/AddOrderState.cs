using System;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class AddOrderState : ViewState
    {
        public AddOrderState(IConsoleWrapper console) : base(console)
        {
        }

        public override string MenuCommands()
        {
            return "";
        }
    }
}
