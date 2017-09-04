using System;
using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.States.Level1
{
    public class DisplayOrderState : Level1State
    {
        public DisplayOrderState(IConsoleWrapper console) : base(console)
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
