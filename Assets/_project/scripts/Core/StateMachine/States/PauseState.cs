using Core.Loading;

namespace Core.StateMachine.States
{
    public class PauseState : IState
    {
        private StateMachineBase _stateMachine;

        private SceneLoadingManager _sceneLoadingManager;

        public PauseState(StateMachineBase stateMachine, SceneLoadingManager sceneLoadingManager) 
        {
            _stateMachine = stateMachine;
            _sceneLoadingManager = sceneLoadingManager;
        }
        public async void Enter()
        {
            await _sceneLoadingManager.LoadScene((int)SceneType.GameLoop);
            _stateMachine.EnterIn<LoopState>();
        }
        public void Exit()
        {

        }
    }
}
