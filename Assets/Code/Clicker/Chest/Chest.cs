using System;
using System.Collections;
using UnityEngine;

namespace Code.Clicker
{
    public class Chest : MonoBehaviour, IClickable
    {
        [SerializeField] private ChestAnimator _animator;
        [SerializeField] private ChestMaterial _material;

        private Coroutine _selectReactionCoroutine;
        
        [ContextMenu("React")]
        public void React()
        {
            _animator.StartClickAnimation();
            
            if(_selectReactionCoroutine != null)
                StopCoroutine(_selectReactionCoroutine);

            _selectReactionCoroutine = StartCoroutine(SelectReaction());
        }

        private IEnumerator SelectReaction()
        {
            _material.SetSelected();
            yield return new WaitForSeconds(0.1f);
            _material.SetDeselected();
        }
    }
}