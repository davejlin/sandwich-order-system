using System;
using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.States.Level1
{
    public class FinishOrderState : Level1State
    {
        public FinishOrderState(IConsoleWrapper console) : base(console)
        {
        }

        public override void Action()
        {
            throw new NotImplementedException();
        }

        public override string MenuCommands()
        {
            throw new NotImplementedException();
        }
    }
}
