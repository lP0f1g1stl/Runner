using Core.Loading;

namespace Core.StateMachine.States
{
    public class PauseState : IState
    {
        private StateMachineBase stateMachine;

        private SceneLoadingManager sceneLoadingManager;

        public PauseState(StateMachineBase stateMachine, SceneLoadingManager sceneLoadingManager) 
        {
            this.stateMachine = stateMachine;
            this.sceneLoadingManager = sceneLoadingManager;
        }
        public async void Enter()
        {
            await sceneLoadingManager.LoadScene((int)SceneType.GameLoop);
            stateMachine.EnterIn<LoopState>();
        }
        public void Exit()
        {

        }
    }
}
