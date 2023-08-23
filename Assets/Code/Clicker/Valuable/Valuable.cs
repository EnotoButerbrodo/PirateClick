using System;
using EnotoButebrodo;
using NaughtyAttributes;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Clicker
{
    public abstract class Valuable : MonoBehaviour, IClickable
    {
        public int CoinsValuable = 1;
        public int CoinsMaxCount = 20;
        public float CoinsRefreshTime = 1f;
        [SerializeField] private BoxCollider _coinsCreateArea;

        [Inject] private ClickerEvents _clickerEvents;
        [Inject] private ITimersService _timersService;

        private Timer _timer;
        private void Start()
        {
            _timer = _timersService.GetTimer();
            OnSpawn();   
        }

        private void OnDestroy()
        {
            _timersService.DeleteTimer(_timer);
        }

        [Button()]
        public void React()
        {
            CallCoinsEarned();
            OnReact();
        }

        protected abstract void OnSpawn(); 
        
        private void CallCoinsEarned()
        {
            for (int i = 0; i < CoinsValuable; i++)
            {
                _clickerEvents.CallCoinEarned(GetRandomCreatePoint());
            }
        }

        private Vector3 GetRandomCreatePoint()
        {
            var bounds = _coinsCreateArea.bounds;
            
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        protected abstract void OnReact();
    }
}