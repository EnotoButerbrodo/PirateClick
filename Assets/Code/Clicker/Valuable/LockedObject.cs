using System;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class LockedObject : MonoBehaviour, ILockedObject, IClickable
    {
        public event Action Unlocked;
        public event Action FailedUnlock;
        [field: SerializeField] public int Cost { get; private set; } = 50;
        [SerializeField] private ValuableType _type;

        [Inject] private IValuableFactory _factory;
        [Inject] private IWallet _wallet;
        
        [Button()]
        public void Unlock() 
        {
            if (_wallet.TrySpend(Cost))
            {
                var valuable = _factory.Get(_type, transform.position, transform.rotation);
                
                Unlocked?.Invoke();
                Destroy(gameObject);
                return;
            }
            
            FailedUnlock?.Invoke();
        }

        public void React()
        {
            Unlock();
        }
    }
}