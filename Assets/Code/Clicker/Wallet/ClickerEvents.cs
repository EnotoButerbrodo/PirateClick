using System;
using UnityEngine;

namespace Code.Clicker
{
    public class ClickerEvents
    {
        public delegate void CoinEarnedDelegate(Vector3 earnWorldPosition);
        public event CoinEarnedDelegate CoinEarned;

        public void CallCoinEarned(Vector3 earnPosition) 
            => CoinEarned?.Invoke(earnPosition);

        public event Action CoinPicked;
        public void CallCoinPicked()
            => CoinPicked?.Invoke();
    }
}