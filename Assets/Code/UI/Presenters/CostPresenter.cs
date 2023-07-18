using System;
using Code.Clicker;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Code.UI.Presenters
{
    public class CostPresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private LockedObject _lockedObject;
        private Sequence _currentSequence;

        private void Awake()
        {
            _text.text = _lockedObject.Cost.ToString();
        }

        private void OnEnable()
        {
            _lockedObject.FailedUnlock += OnFailUnlock;
        }

        private void OnDisable()
        {
            _lockedObject.FailedUnlock -= OnFailUnlock;
        }

        private void OnFailUnlock()
        {
            PlayAnimation();
        }
        
        private void PlayAnimation()
        {
            _currentSequence?.Restart();

            _currentSequence = DOTween.Sequence()
                .Append(_text.transform.DOScale(endValue: Vector3.one * 1.2f
                    , duration: 0.1f))
                .Append(_text.transform.DOScale(endValue: Vector3.one
                    , duration: 0.1f));
        }
    }
}