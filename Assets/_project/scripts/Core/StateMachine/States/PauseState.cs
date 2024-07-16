namespace Core.StateMachine.States
{
    public class PauseState : IState
    {
        private StateMachineBase stateMachine;

        public PauseState(StateMachineBase stateMachine) 
        {
            this.stateMachine = stateMachine;
        }
        public void Enter()
        {
            //stateMachine.EnterIn<LoopState>();
        }
        public void Exit()
        {

        }
    }
}
