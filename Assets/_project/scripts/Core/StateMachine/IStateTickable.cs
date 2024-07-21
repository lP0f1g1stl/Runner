namespace Core.StateMachine.States
{
    public interface IStateTickable : IState
    {
        void Tick();

        void FixedTick();
    }
}
