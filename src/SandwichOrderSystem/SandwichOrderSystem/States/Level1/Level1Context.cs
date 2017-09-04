using System;

namespace SandwichOrderSystem.States.Level1
{
    public class Level1Context : ILevel1Context
    {
        public Level1State MainState { get; }
        public Level1State CancelOrderState { get; }
        public Level1State DisplayOrderState { get; }
        public Level1State AddOrderState { get; }
        public Level1State FinishOrderState { get; }

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
            FinishOrderState finishOrderState)
        {
            MainState = mainMenuState;
            CancelOrderState = cancelOrderState;
            DisplayOrderState = displayOrderState;
            AddOrderState = addOrderState;
            FinishOrderState = finishOrderState;

            State = mainMenuState;
        }

        public void Action()
        {
            state.Action();
        }

        public string MenuCommands()
        {
            return state.MenuCommands();
        }
    }
}
