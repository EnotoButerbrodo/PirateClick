using System;
using System.Collections;
using UnityEngine;

namespace Code.Levels.Clicker
{
    public class Chest : MonoBehaviour, IClickable
    {
        [SerializeField] private ChestAnimator _animator;
        
        [ContextMenu("React")]
        public void React()
        {
            _animator.StartClickAnimation();
        }
    }
}