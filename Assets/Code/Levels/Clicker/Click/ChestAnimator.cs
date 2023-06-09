﻿using System;
using System.Collections;
using UnityEngine;

namespace Code.Levels.Clicker
{
    public class ChestAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _clickBoolName = "Click";
        [SerializeField][Range(0f, 10f)] private float _clickAnimationCancelTime;
        
        private int _clickHash;

        private float _clickAnimationTimer = 0f;
        public void StartClickAnimation()
        {
            _animator.SetBool(_clickHash, true);
            
            _clickAnimationTimer = 0f;
        }
        
        private void CancelClickAnimation()
        {
            _animator.SetBool(_clickHash, false);
        }
        
        private void Awake()
        {
            CalculateAnimationsHash();
        }

        private void Update()
        {
            
            if (_clickAnimationTimer >= _clickAnimationCancelTime)
            {
                _clickAnimationTimer = 0;
                CancelClickAnimation();
            }
            _clickAnimationTimer += Time.deltaTime;
                
        }

        private void CalculateAnimationsHash()
        {
            _clickHash = Animator.StringToHash(_clickBoolName);
        }
    }
}