using System.Collections.Generic;
using System;
using Core.StateMachine.States;

namespace Core.StateMachine
{
    public class StateMachineBase
    {
        private readonly Dictionary<Type, IState> states;
        private IState curState;

        public StateMachineBase()
        {
            states = new Dictionary<Type, IState>()
            {
                [typeof(LoadingState)] = new LoadingState(this),
                [typeof(LoopState)] = new LoopState(this),
                [typeof(PauseState)] = new PauseState(this)
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
    }
}
