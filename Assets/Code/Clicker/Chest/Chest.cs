using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Clicker
{
    public class Chest : MonoBehaviour, IClickable
    {
        [SerializeField] private ChestAnimator _animator;
        [SerializeField] private ChestMaterialProvider chestMaterialProvider;

        private Coroutine _selectReactionCoroutine;

        public event Action Clicked;

        [ContextMenu("React")]
        public void React()
        {
            
            _animator.StartClickAnimation();
            
            if(_selectReactionCoroutine != null)
                StopCoroutine(_selectReactionCoroutine);

            _selectReactionCoroutine = StartCoroutine(SelectReaction());
            
            Clicked?.Invoke();
        }

        private IEnumerator SelectReaction()
        {
            chestMaterialProvider.SetSelected();
            yield return new WaitForSeconds(0.1f);
            chestMaterialProvider.SetDeselected();
        }
    }
}