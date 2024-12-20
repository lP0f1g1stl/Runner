using Core.Loading;

namespace Core.StateMachine.States
{
    public class LoadingState : IState
    {
        private StateMachineBase _stateMachine;

        private readonly SceneLoadingManager _sceneLoadingManager;

        public LoadingState(StateMachineBase stateMachine, SceneLoadingManager sceneLoadingManager) 
        {
            _stateMachine = stateMachine;
            this._sceneLoadingManager = sceneLoadingManager;
        }
        public async void Enter()
        {
            await _sceneLoadingManager.LoadScene((int)SceneType.Loading);
            await _sceneLoadingManager.LoadScene((int)SceneType.MainMenu);
            _stateMachine.EnterIn<PauseState>();
        }
        public void Exit()
        {
        }
    }
}
