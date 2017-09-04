using System;
using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.States.Level1States
{
    public class MainState : Level1State
    {
        public MainState(IConsoleWrapper console) : base(console)
        {
        }

        public override void Action()
        {
            // no action
        }

        public override void MenuCommands()
        {
            console.OutputLine("Main state");
        }

        public override void ReturnToMain()
        {
            // already in Main
        }
    }
}
