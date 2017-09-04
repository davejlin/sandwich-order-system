using System;
using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.States.Level1
{
    public class AddOrderState : Level1State
    {
        public AddOrderState(IConsoleWrapper console) : base(console)
        {
        }

        public override void Action()
        {
            throw new NotImplementedException();
        }

        public override string MenuCommands()
        {
            return "";
        }
    }
}
