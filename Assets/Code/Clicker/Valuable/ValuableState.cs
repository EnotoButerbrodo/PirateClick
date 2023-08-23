using EnotoButerbrodo.StateMachine;

namespace Code.Clicker
{
    public abstract class ValuableState
    {
        protected ValuableStateMachine Context;

        protected Valuable Valuable => Context.Valuable;
        protected ValuableAnimator Animator => Context.Animator;
        protected ClickerEvents ClickerEvents => Context.ClickerEvents;
        
        public ValuableState(ValuableStateMachine context)
        {
            Context = context;
        }

        public abstract void Enter();
        public abstract void Exit();
        
        public abstract void React();
    }
}