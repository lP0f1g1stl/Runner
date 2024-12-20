using Core.InputHandling;
using Core.Loading;

namespace Core.StateMachine.States
{
    public class LoopState : IStateTickable
    {
        private StateMachineBase _stateMachine;

        private IInputHandler _inputHandler;
        private SceneLoadingManager _sceneLoadingManager;

        public LoopState(StateMachineBase stateMachine, IInputHandler inputHandler, SceneLoadingManager sceneLoadingManager) 
        {
            _stateMachine = stateMachine;
            _inputHandler = inputHandler;
            _sceneLoadingManager = sceneLoadingManager;
        }

        public void Enter()
        {
            //stateMachine.EnterIn<PauseState>();
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            _inputHandler.CheckInputLoop();
        }
    }
}
