namespace Core.StateMachine.States
{
    public class LoopState : IStateTickable
    {
        private StateMachineBase stateMachine;

        public LoopState(StateMachineBase _stateMachine) 
        {
            stateMachine = _stateMachine;
        }
        public void Enter()
        {
            stateMachine.EnterIn<PauseState>();
        }

        public void Exit()
        {
        }

        public void Tick()
        {

        }
    }
}
