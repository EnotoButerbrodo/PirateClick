using System;
using EnotoButebrodo;
using NaughtyAttributes;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Clicker
{
    public class Valuable : MonoBehaviour, IClickable
    {
        public event Action<int> AvailableCoinsChanged;
        
        public int CoinsValuable = 1;
        public int MaxAvailableCoinsCount = 20;
        public float CoinsRefreshTime = 1f;
        
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