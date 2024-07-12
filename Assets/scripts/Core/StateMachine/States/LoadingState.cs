namespace Core.StateMachine.States
{
    public class LoadingState : IState
    {
        private StateMachineBase stateMachine;

        public LoadingState(StateMachineBase _stateMachine) 
        {
            stateMachine = _stateMachine;
        }
        public void Enter()
        {
            stateMachine.EnterIn<LoopState>();
        }
        public void Exit()
        {
        }
    }
}
