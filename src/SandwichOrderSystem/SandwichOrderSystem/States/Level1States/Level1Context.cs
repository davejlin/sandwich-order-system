using System;

namespace SandwichOrderSystem.States.Level1States
{
    public class Level1Context : ILevel1Context
    {
        public Level1State MainMenuState { get; }
        public Level1State CancelOrderState { get; }
        public Level1State DisplayOrderState { get; }
        public Level1State AddOrderState { get; }
        public Level1State CompleteOrderState { get; }

        private Level1State state;
        public Level1State State
        {
            set
            {
                state = value;
                state.SetContext(this);
            } 
       }

        public Level1Context(
            MainState mainMenuState,
            CancelOrderState cancelOrderState,
            DisplayOrderState displayOrderState,
            AddOrderState addOrderState,
            CompleteOrderState completeOrderState)
        {
            this.MainMenuState = mainMenuState;
            this.CancelOrderState = cancelOrderState;
            this.DisplayOrderState = displayOrderState;
            this.AddOrderState = addOrderState;
            this.CompleteOrderState = completeOrderState;

            State = mainMenuState;
        }

        public void Action()
        {
            state.Action();
        }

        public void MenuCommands()
        {
            state.MenuCommands();
        }

        public void ReturnToMain()
        {
            state.ReturnToMain();
        }
    }
}
