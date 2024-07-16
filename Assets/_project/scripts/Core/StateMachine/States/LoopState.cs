namespace Core.StateMachine.States
{
    public class LoopState : IStateTickable
    {
        private StateMachineBase stateMachine;

        public LoopState(StateMachineBase stateMachine) 
        {
            this.stateMachine = stateMachine;
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
