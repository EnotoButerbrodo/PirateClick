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
        public int CoinsValuable = 1;
        public int MaxCoinsCount = 20;
        public float CoinsRefreshTime = 1f;
        public int CoinsCount = 20;

        [SerializeField] private ValuableStateMachine _stateMachine;

        private void Start()
        {
            _stateMachine.EnterDefaultState();
        }

        [Button()]
        public void React()
        {
            _stateMachine.React();
        }
    }
}