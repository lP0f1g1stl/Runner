using Core.Loading;

namespace Core.StateMachine.States
{
    public class LoadingState : IState
    {
        private StateMachineBase stateMachine;

        private SceneLoadingManager sceneLoadingManager;

        public LoadingState(StateMachineBase stateMachine, SceneLoadingManager sceneLoadingManager) 
        {
            this.stateMachine = stateMachine;
            this.sceneLoadingManager = sceneLoadingManager;
        }
        public async void Enter()
        {
            await sceneLoadingManager.LoadScene((int)SceneType.Loading);
            await sceneLoadingManager.LoadScene((int)SceneType.MainMenu);
            stateMachine.EnterIn<PauseState>();
        }
        public void Exit()
        {
        }
    }
}
