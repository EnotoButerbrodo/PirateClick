using System;
using System.Collections;
using EnotoButebrodo;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class ValuableAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SelectableMaterial selectableMaterial;
        [SerializeField] private string _clickBoolName = "Click";
        [SerializeField] private string _spawnName = "Spawn";
        [SerializeField] private string _reloadingName = "Reloading";
        [SerializeField][Range(0f, 10f)] private float _clickAnimationCancelTime;
        [SerializeField][Range(0f, 10f)] private float _materialAnimationTime = 0.1f;

        private int _clickHash;
        private int _spawnHash;
        private int _reloadingHash;

        private Coroutine _clickAnimation;


        public void StartClickAnimation()
        {
            if (_clickAnimation != null)
                StopCoroutine(_clickAnimation);
            _clickAnimation =  StartCoroutine(ClickAniamation());
            
            StartCoroutine(MaterialAnimation());
        }

        public void SetReloading(bool state)
        {
            _animator.SetBool(_reloadingHash, state);
        }

        private IEnumerator ClickAniamation()
        {
            _animator.SetBool(_clickHash, true);
            yield return new WaitForSeconds(_clickAnimationCancelTime);
            _animator.SetBool(_clickHash, false);
            
        }

        private IEnumerator MaterialAnimation()
        {
            selectableMaterial.SetSelected();
            yield return new WaitForSeconds(_materialAnimationTime);
            selectableMaterial.SetDeselected();
        }
 
        public void PlaySpawnAnimation()
        {
            _animator.SetTrigger(_spawnHash);
        }
        
        
        private void Awake()
        {
            CalculateAnimationsHash();
        }

        private IEnumerator SelectReaction()
        {
            selectableMaterial.SetSelected();
            yield return new WaitForSeconds(0.1f);
            selectableMaterial.SetDeselected();
        }

        private void CalculateAnimationsHash()
        {
            _clickHash = Animator.StringToHash(_clickBoolName);
            _spawnHash = Animator.StringToHash(_spawnName);
            _reloadingHash = Animator.StringToHash(_reloadingName);
        }
    }
}