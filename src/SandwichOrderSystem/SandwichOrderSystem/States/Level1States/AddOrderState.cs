using System;
using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.States.Level1States
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

        public override void MenuCommands()
        {
            console.Output("Add order state");
        }

        public override void ReturnToMain()
        {
            throw new NotImplementedException();
        }
    }
}
