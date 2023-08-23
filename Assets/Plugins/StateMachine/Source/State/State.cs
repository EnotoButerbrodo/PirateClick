namespace EnotoButerbrodo.StateMachine
{
    public abstract class State : IState
    {
        protected StateMachine Context;

        public State(StateMachine context)
        {
            Context = context;
        }

        public abstract void Enter();

        public virtual void Exit()
        {
            return;
        }
    }
}