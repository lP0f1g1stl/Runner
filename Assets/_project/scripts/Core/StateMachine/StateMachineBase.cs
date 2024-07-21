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
        private IState curState;

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
                curState?.Exit();
                curState = state;
                curState.Enter();
            }
        }
        public void TickIn()
        {
            if (curState is IStateTickable)
            {
                IStateTickable state = (IStateTickable)curState;
                state.Tick();
            }
        }
        public void FixedTickIn() 
        {
            if (curState is IStateTickable)
            {
                IStateTickable state = (IStateTickable)curState;
                state.FixedTick();
            }
        }
    }
}
