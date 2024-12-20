using System.Collections.Generic;
using System;
using Core.StateMachine.States;
using Core.InputHandling;
using Core.Loading;

namespace Core.StateMachine
{
    public class StateMachineBase
    {
        private readonly Dictionary<Type, IState> states;
        private IState _curState;

        public StateMachineBase(SceneLoadingManager sceneLoadingManager, IInputHandler inputHandler)
        {
            states = new Dictionary<Type, IState>()
            {
                [typeof(LoadingState)] = new LoadingState(this, sceneLoadingManager),
                [typeof(LoopState)] = new LoopState(this, inputHandler, sceneLoadingManager),
                [typeof(PauseState)] = new PauseState(this, sceneLoadingManager)
            };
        }

        public void EnterIn<TState>() where TState : IState
        {
            if (states.TryGetValue(typeof(TState), out IState state))
            {
                _curState?.Exit();
                _curState = state;
                _curState.Enter();
            }
        }
        public void TickIn()
        {
            if (_curState is IStateTickable)
            {
                IStateTickable state = (IStateTickable)_curState;
                state.Tick();
            }
        }
    }
}
