namespace SandwichOrderSystem.States.Level1
{
    public interface ILevel1Context
    {
        Level1State MainState { get; }
        Level1State CancelOrderState { get; }
        Level1State DisplayOrderState { get; }
        Level1State AddOrderState { get; }
        Level1State FinishOrderState { get; }
        Level1State State { set; }

        void Action();
        string MenuCommands();
    }
}