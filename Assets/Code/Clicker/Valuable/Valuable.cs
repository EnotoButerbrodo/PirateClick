using System;
using NaughtyAttributes;
using UnityEngine;

namespace Code.Clicker
{
    [Serializable]
    public class ValuableStats
    {
        public int CoinsValuable = 1;
        public int MaxAvailableCoinsCount = 20;
        public float CoinsRefreshTime = 1f;
    }
    
    public class Valuable : MonoBehaviour, IClickable
    {
        public event Action<int> AvailableCoinsChanged;

        public ValuableStats Stats;
        
        [field: SerializeField] public int AvailableCoins
        {
            get => _availableAvailableCoins;
            set
            {
                _availableAvailableCoins = value;
                AvailableCoinsChanged?.Invoke(_availableAvailableCoins);
            }
        }
        private int _availableAvailableCoins;
        
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
    }
}