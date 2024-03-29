﻿using System;
using UnityEngine;

namespace Code.Clicker
{
    public class ClickerEvents
    {
        public delegate void CoinEarnedDelegate(Vector3 earnWorldPosition);
        public event CoinEarnedDelegate CoinEarned;

        public void CallCoinEarned(Vector3 earnPosition) 
            => CoinEarned?.Invoke(earnPosition);

        public event Action<Coin> CoinPicked;
        
        public void CallCoinPicked(Coin coin)
            => CoinPicked?.Invoke(coin);
        
        public delegate void ClickableClickDelegate(Vector3 clickWorldPosition, IClickable clickable);

        public ClickableClickDelegate ClickableClicked;

        public void CallClickableClicked(Vector3 clickWorldPosition, IClickable clickable)
            => ClickableClicked?.Invoke(clickWorldPosition, clickable);
    }
}