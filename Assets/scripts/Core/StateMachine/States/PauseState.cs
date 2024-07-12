namespace Core.StateMachine.States
{
    public class PauseState : IState
    {
        private StateMachineBase stateMachine;

        public PauseState(StateMachineBase _stateMachine) 
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
