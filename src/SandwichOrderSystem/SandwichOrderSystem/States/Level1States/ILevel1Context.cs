namespace SandwichOrderSystem.States.Level1States
{
    public interface ILevel1Context
    {
        Level1State MainMenuState { get; }
        Level1State CancelOrderState { get; }
        Level1State DisplayOrderState { get; }
        Level1State AddOrderState { get; }
        Level1State CompleteOrderState { get; }
        Level1State State { set; }

        void Action();
        void MenuCommands();
        void ReturnToMain();
    }
}