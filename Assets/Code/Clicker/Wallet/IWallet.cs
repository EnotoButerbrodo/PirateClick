using System;

namespace Code.Clicker
{
    public interface IWallet
    {
        public event Action<int> ValueChanged;
        void Add(int value);
        bool TrySpend(int amount);
    }
}