using System;
using UnityEngine;

namespace Code.Clicker
{
    public class Wallet : IWallet
    {
        public event Action<int> ValueChanged;
        
        private int _moneys = 0;

        public void Add(int value)
        {
            _moneys += value;
            ValueChanged?.Invoke(_moneys);
        }

        public bool TrySpend(int amount)
        {
            if (_moneys >= amount)
            {
                _moneys -= amount;
                ValueChanged?.Invoke(_moneys);
                return true;
            }

            return false;
        }
        
    }
}