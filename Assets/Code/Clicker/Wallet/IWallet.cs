using System;

namespace Code.Clicker
{
    public interface IWallet
    {
        event Action<int> ValueChanged;
        void Add(int value);
        bool TrySpend(int amount);
    }
}