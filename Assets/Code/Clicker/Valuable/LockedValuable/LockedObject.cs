using System;
using NaughtyAttributes;
using Unity.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Clicker
{
    public class LockedObject : MonoBehaviour, ILockedObject, IClickable
    {
        public event Action Unlocked;
        public event Action FailedUnlock;
        public event Action<int> CoinsToUnlockChanged;

        public Vector3 GetCoinsTarget() 
            => GetRandomEarnPosition();

        [field: SerializeField] public int Cost { get; private set; } = 50;
        [SerializeField] private ValuableStats _stats;
        
        [SerializeField] private Vector3 _positionOffset;
        [SerializeField] private BoxCollider _coinsTargetArea;

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
            valuable.Stats = _stats;
            Unlocked?.Invoke();
            Destroy(gameObject);
        }

        public void AcceptCoin()
        {
            _currentCoins++;
            CoinsToUnlockChanged?.Invoke(Cost - _currentCoins);
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
        
        public Vector3 GetRandomEarnPosition()
        {
            var bounds = _coinsTargetArea.bounds;
            
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }
    }
}