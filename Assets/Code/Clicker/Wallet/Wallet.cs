using System;

namespace Code.Clicker
{
    public class Wallet : IWallet
    {
        public event Action<int> ValueChanged;

        private int Moneys
        {
            get => _moneys;
            set
            {
                _moneys = value;
                ValueChanged?.Invoke(value);
            }
        }
        private int _moneys;

        public void Add(int value)
        {
            Moneys += value;
        }

        public bool TrySpend(int amount)
        {
            if (Moneys >= amount)
            {
                Moneys -= amount;
                return true;
            }

            return false;
        }
        
    }
}