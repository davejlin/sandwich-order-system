using System;
using SandwichOrderSystem.Views;

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
