using EnotoButerbrodo.StateMachine;

namespace Infrastructure
{
    public class InitialState : IState
    {
        private readonly GameStateMachine _context;

        public InitialState(GameStateMachine context)
        {
            _context = context;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}