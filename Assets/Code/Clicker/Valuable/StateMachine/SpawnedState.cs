namespace Code.Clicker
{
    public class SpawnedState : ValuableState
    {
        public SpawnedState(ValuableStateMachine context) : base(context)
        {
        }

        public override void Enter()
        {
            Animator.PlaySpawnAnimation();
            Context.Enter(Context.HasCoinsState);
        }

        public override void Exit()
        {
            
        }

        public override void React()
        {
            
        }
    }
}