using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Clicker.HUD
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ReloadBar : MonoBehaviour
    {
        [SerializeField] private Image _reloadImage;
        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private float _showHideTime = 0.1f;
        [SerializeField] private float _attentionTime = 0.1f;
        private TweenerCore<float, float, FloatOptions> _showHideTween;
        private Sequence _attentionTween;

        public void Show()
        {
            _showHideTween?.Kill();
            _showHideTween = _canvasGroup.DOFade(1, _showHideTime)
                .SetLink(gameObject);
        }

        public void Hide()
        {
            _showHideTween?.Kill();
            _canvasGroup.DOFade(0, _showHideTime)
                .SetLink(gameObject);
        }

        public void SetPercent(float percent)
        {
            _reloadImage.fillAmount = percent;
        }

        public void DoAttention()
        {
            _attentionTween?.Kill();
            _attentionTween = DOTween.Sequence()
                .Append(transform.DOScale(Vector3.one * 1.3f, _attentionTime / 2))
                .Append(transform.DOScale(Vector3.one, _attentionTime / 2))
                .OnKill(() => transform.localScale = Vector3.one);
        }
    }
}