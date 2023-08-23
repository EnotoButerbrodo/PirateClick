﻿using System;
using EnotoButerbrodo.StateMachine;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class ValuableStateMachine : MonoBehaviour
    {
        [SerializeField] private ValuableStateFactory _stateFactory;
        
        public ValuableState SpawnState { get; private set; }
        public ValuableState HasCoinsState { get; private set; }
        public ValuableState ReloadState { get; private set; }
        
        [field: SerializeField] public Valuable Valuable { get; private set; }
        [field: SerializeField] public ValuableAnimator Animator { get; private set; }
        
        [Inject] public ClickerEvents ClickerEvents { get; private set; }

        
        private void Awake()
        {
            SpawnState = _stateFactory.GetSpawnState(this);
            HasCoinsState = _stateFactory.GetHasCoinsState(this);
            ReloadState = _stateFactory.GetReloadState(this);
        }

        private ValuableState _currentState;
        
        public void React()
        {
            _currentState?.React();
        }

        public void EnterFirstState()
        {
            Enter(SpawnState);
        }
        
        public void Enter(ValuableState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}