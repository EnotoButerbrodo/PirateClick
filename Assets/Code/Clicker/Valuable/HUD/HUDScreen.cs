using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Code.Clicker.HUD
{
    public class HUDScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float hideTime = 0.1f;
        [SerializeField] private float showTime = 0.1f;
        [SerializeField] private bool hideInAwake = true;
        
        private TweenerCore<float, float, FloatOptions> _tween;

        private void Awake()
        {
            canvasGroup.alpha = hideInAwake ? 0 : 1f;
        }

        public void Show()
        {
            _tween?.Kill();
            _tween = canvasGroup.DOFade(1f, showTime).SetEase(Ease.OutQuad);
        }
        public void Hide()
        {
            _tween?.Kill();
            _tween = canvasGroup.DOFade(0f, hideTime).SetEase(Ease.OutQuad);
        }

        
    }
}