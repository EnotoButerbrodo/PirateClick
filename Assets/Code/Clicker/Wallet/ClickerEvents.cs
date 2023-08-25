using System;
using UnityEngine;

namespace Code.Clicker
{
    public class ClickerEvents 
    {
        public delegate void CoinEarnedDelegate(int count, ICoinsSource source);
        public delegate void ClickableClickDelegate(Vector3 clickWorldPosition, IClickable clickable);
        public delegate void ValuableUnlockDelegate(int cost, ILockedObject unlockedObject);
        
        public event CoinEarnedDelegate CoinEarned;
        public event Action<Coin> CoinPicked;
        public ClickableClickDelegate ClickableClicked;
        public ValuableUnlockDelegate ValuableUnlocked;
        
        public void CallCoinEarned(int count, ICoinsSource source) 
            => CoinEarned?.Invoke(count, source);

        public void CallCoinPicked(Coin coin)
            => CoinPicked?.Invoke(coin);
        
        public void CallClickableClicked(Vector3 clickWorldPosition, IClickable clickable)
            => ClickableClicked?.Invoke(clickWorldPosition, clickable);

        public void CallValuableUnlock(int cost, ILockedObject unlockedObject)
            => ValuableUnlocked?.Invoke(cost, unlockedObject);
    }
}