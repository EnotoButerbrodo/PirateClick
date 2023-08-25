using System;
using NaughtyAttributes;
using UnityEngine;

namespace Code.Clicker
{
    public class Valuable : MonoBehaviour, IClickable
    {
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
    }
}