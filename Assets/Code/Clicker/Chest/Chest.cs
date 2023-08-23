using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Clicker
{
    public class Chest : Valuable
    {
        [SerializeField] private ValuableAnimator animator;
        [FormerlySerializedAs("chestMaterialProvider")] 
        [SerializeField] private SelectableMaterial selectableMaterial;

        private Coroutine _selectReactionCoroutine;


        protected void OnSpawn()
        {
            animator.PlaySpawnAnimation();
        }

        protected void OnReact()
        {
            animator.StartClickAnimation();
            
            if(_selectReactionCoroutine != null)
                StopCoroutine(_selectReactionCoroutine);

            _selectReactionCoroutine = StartCoroutine(SelectReaction());
        }

        private IEnumerator SelectReaction()
        {
            selectableMaterial.SetSelected();
            yield return new WaitForSeconds(0.1f);
            selectableMaterial.SetDeselected();
        }
    }
}