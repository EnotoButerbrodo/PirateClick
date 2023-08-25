using System.Collections;
using UnityEngine;

namespace Code.Clicker
{
    public class HasCoinsState : ValuableState
    {

        public HasCoinsState(ValuableStateMachine context) : base(context)
        {
        }

        public override void Enter()
        {
            Valuable.AvailableCoins = Valuable.Stats.MaxAvailableCoinsCount;
        }

        public override void Exit()
        {
        }

        public override void React()
        {
            Animator.StartClickAnimation();
            SpendMoneyFromValuable();
        }

        private void SpendMoneyFromValuable()
        {
            var coinsCount =  Mathf.Clamp(Valuable.Stats.CoinsValuable, 0, Valuable.AvailableCoins);
            Valuable.AvailableCoins -= coinsCount;
            ClickerEvents.CallCoinEarned(coinsCount, Valuable);
            
            if (Valuable.AvailableCoins == 0)
            {
                Context.Enter(Context.ReloadState);
            }
            
        }

    }
}