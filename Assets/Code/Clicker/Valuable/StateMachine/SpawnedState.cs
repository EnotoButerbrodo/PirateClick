using Code.Clicker.HUD;

namespace Code.Clicker
{
    public class SpawnedState : ValuableState
    {
        private readonly IValuableHUD _hud;

        public SpawnedState(ValuableStateMachine context
        , IValuableHUD hud) : base(context)
        {
            _hud = hud;
        }

        public override void Enter()
        {
            Animator.PlaySpawnAnimation();
            _hud.Spawn();
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