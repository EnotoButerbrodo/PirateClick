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
        [SerializeField] private string _reloadClickName = "ReloadClick";
        [SerializeField][Range(0f, 10f)] private float _clickAnimationCancelTime;
        [SerializeField][Range(0f, 10f)] private float _materialAnimationTime = 0.1f;

        private int _click;
        private int _spawn;
        private int _reloading;
        private int _reload;

        private Coroutine _clickAnimation;
        private Coroutine _earnAnimation;


        public void StartClickAnimation()
        {
            if (_clickAnimation != null)
                StopCoroutine(_clickAnimation);
            _clickAnimation =  StartCoroutine(ClickAnimation());
            
            //StartCoroutine(MaterialAnimation());
        }

        public void PlayEarnAnimation()
        {
            if (_earnAnimation != null)
                return;
            _earnAnimation = StartCoroutine(MaterialAnimation());
        }

        public void SetReloading(bool state)
        {
            _animator.SetBool(_reloading, state);
        }

        public void SetReloadClick()
        {
            _animator.SetTrigger(_reload);
        }

        private IEnumerator ClickAnimation()
        {
            _animator.SetBool(_click, true);
            yield return new WaitForSeconds(_clickAnimationCancelTime);
            _animator.SetBool(_click, false);
        }

        private IEnumerator MaterialAnimation()
        {
            selectableMaterial.SetSelected();
            yield return new WaitForSeconds(_materialAnimationTime);
            selectableMaterial.SetDeselected();
        }
 
        public void PlaySpawnAnimation()
        {
            _animator.SetTrigger(_spawn);
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
            _click = Animator.StringToHash(_clickBoolName);
            _spawn = Animator.StringToHash(_spawnName);
            _reloading = Animator.StringToHash(_reloadingName);
            _reload = Animator.StringToHash(_reloadClickName);
        }
    }
}