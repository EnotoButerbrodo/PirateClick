using System;
using System.Collections.Generic;

namespace EnotoButerbrodo.StateMachine
{
    public abstract class StateMachine
    {
        protected Dictionary<Type, IExitableState> _states = new Dictionary<Type, IExitableState>();
        private IExitableState _currentState;

        public bool HasState<TState>() where TState : class, IExitableState 
            => _states.ContainsKey(typeof(TState));

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> state = ChangeState<TState>();
            state.Enter(payload);
        }

        public void UpdateStates()
        {
            var updateState = _currentState as IUpdateableState;
            updateState?.UpdateState();
        }

        public void FixedUpdateStates()
        {
            var fixedUpdateState = _currentState as IFixedUpdateState;
            fixedUpdateState?.FixedUpdateState();
        }
        
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState 
            => _states[typeof(TState)] as TState;
    }
    

}