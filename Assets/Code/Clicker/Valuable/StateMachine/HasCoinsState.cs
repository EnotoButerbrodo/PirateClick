using System.Collections;
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
            Valuable.AvailableCoins = Valuable.Stats.MaxAvailableCoinsCount;
        }

        public override void Exit()
        {
        }

        public override void React()
        {
            Animator.StartClickAnimation();
            int spendedMoney = SpendMoneyFromValuable();
            Context.StartCoroutine(ReactCoroutine(spendedMoney));
        }

        private int SpendMoneyFromValuable()
        {
            var coinsCount =  Mathf.Clamp(Valuable.Stats.CoinsValuable, 0, Valuable.AvailableCoins);
            Valuable.AvailableCoins -= coinsCount;
            
            if (Valuable.AvailableCoins == 0)
            {
                Context.Enter(Context.ReloadState);
            }

            return coinsCount;
        }

        private IEnumerator ReactCoroutine(int coinsCount)
        {
            var delayTime = 0.5f / coinsCount;
            var waiter = new WaitForSeconds(delayTime);
            
            for (int i = 0; i < coinsCount; i++)
            {
                ClickerEvents.CallCoinEarned(GetRandomCreatePoint());
                Animator.PlayEarnAnimation();

                yield return waiter;
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