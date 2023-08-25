using System;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Clicker
{
    public class Valuable : MonoBehaviour, IClickable, ICoinsSource
    {
        [SerializeField] private BoxCollider _coinsCreateArea;
        
        public event Action<int> AvailableCoinsChanged;

        public ValuableStats Stats;
        
        public int AvailableCoins
        {
            get => _availableAvailableCoins;
            set
            {
                _availableAvailableCoins = value;
                AvailableCoinsChanged?.Invoke(_availableAvailableCoins);
            }
        }
        [ReadOnly][SerializeField]private int _availableAvailableCoins;
        
        [SerializeField] private ValuableStateMachine _stateMachine;

        private void Start()
        {
            _stateMachine.EnterFirstState();
        }

        [Button()]
        public void React()
        {
            _stateMachine.React();
        }

        public Vector3 GetRandomEarnPosition()
        {
            var bounds = _coinsCreateArea.bounds;
            
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }
    }
}