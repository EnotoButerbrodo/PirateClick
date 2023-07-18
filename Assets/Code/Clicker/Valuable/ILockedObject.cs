using System;

namespace Code.Clicker
{
    public interface ILockedObject
    {
        public event Action Unlocked;
        public event Action FailedUnlock;
        
        public int Cost { get; }
        public void Unlock();
    }
}