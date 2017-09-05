using System;

namespace SandwichOrderSystem.Views.ViewStates
{
    public class FinishOrderState : ViewState
    {
        public FinishOrderState(IConsoleWrapper console) : base(console)
        {
        }

        public override string MenuCommands()
        {
            throw new NotImplementedException();
        }
    }
}
