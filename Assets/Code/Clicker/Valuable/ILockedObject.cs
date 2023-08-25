using System;
using UnityEngine;

namespace Code.Clicker
{
    public interface ILockedObject
    {
        public event Action Unlocked;
        public event Action FailedUnlock;

        public Vector3 GetCoinsTarget();
        public int Cost { get; }
        public void Unlock();
        public void GetCoin();
    }
}