using System;
using NaughtyAttributes;
using Unity.Collections;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class LockedObject : MonoBehaviour, ILockedObject, IClickable
    {
        public event Action Unlocked;
        public event Action FailedUnlock;

        [field: SerializeField] public int Cost { get; private set; } = 50;
        [SerializeField] private Vector3 _positionOffset;
        public Vector3 Position => transform.position + _positionOffset;
        
        [SerializeField] private ValuableType _type;

        [Inject] private IValuableFactory _factory;
        [Inject] private IWallet _wallet;
        [Inject] private ClickerEvents _clickerEvents;

        [NaughtyAttributes.ReadOnly]
        [SerializeField] private int _currentCoins;

        private bool _unlocked;

        [Button()]
        public void Unlock()
        {
            var valuable = _factory.Get(_type, transform.position, transform.rotation);
            Unlocked?.Invoke();
            Destroy(gameObject);
        }

        public void GetCoin()
        {
            _currentCoins++;
            if(_currentCoins >= Cost)
                Unlock();
        }

        private void TryUnlock()
        {
            if(_unlocked)
                return;
            
            if (_wallet.TrySpend(Cost))
            {
                _clickerEvents.CallValuableUnlock(Cost, this);
                _unlocked = true;
                return;
            }
            
            FailedUnlock?.Invoke();
        }

        public void React()
        {
            TryUnlock();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawSphere(Position, 0.1f);
        }
    }
}