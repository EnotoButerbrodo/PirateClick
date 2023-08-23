using UnityEngine;

namespace Code.Clicker
{
    public class HasCoinsState : ValuableState
    {
        private readonly BoxCollider _coinsCreateArea;

        public HasCoinsState(ValuableStateMachine context
        , BoxCollider coinsCreateArea) : base(context)
        {
            _coinsCreateArea = coinsCreateArea;
        }

        public override void Enter()
        {
            Valuable.CoinsCount = Valuable.MaxCoinsCount;
        }

        public override void Exit()
        {
            
        }

        public override void React()
        {
            for (int i = 0; i < Valuable.CoinsValuable; i++)
            {
                if (Valuable.CoinsCount > 0)
                {
                    Valuable.CoinsCount--;
                    ClickerEvents.CallCoinEarned(GetRandomCreatePoint());
                    Animator.StartClickAnimation();
                }
                else
                {
                    Context.Enter(Context.ReloadState);
                    break;
                }
            }
        }
        

        private Vector3 GetRandomCreatePoint()
        {
            var bounds = _coinsCreateArea.bounds;
            
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }
    }
}