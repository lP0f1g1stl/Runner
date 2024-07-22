using Core.InputHandling;
using Core.Loading;

namespace Core.StateMachine.States
{
    public class LoopState : IStateTickable
    {
        private StateMachineBase stateMachine;

        private IInputHandler inputHandler;
        private SceneLoadingManager sceneLoadingManager;

        public LoopState(StateMachineBase stateMachine, IInputHandler inputHandler, SceneLoadingManager sceneLoadingManager) 
        {
            this.stateMachine = stateMachine;
            this.inputHandler = inputHandler;
            this.sceneLoadingManager = sceneLoadingManager;
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
            inputHandler.CheckInputLoop();
        }
    }
}
