using EnotoButerbrodo.StateMachine;

namespace Infrastructure
{
    public class GameStateMachine : StateMachine
    {
        private readonly IGameStateFactory _stateFactory;
        
        public GameStateMachine(IGameStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
            InitialStates();
        }

        private void InitialStates()
        {
            _states.Add(typeof(InitialState), _stateFactory.GetInitialState(this)); 
        }
    }
}