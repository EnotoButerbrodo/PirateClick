using Code.Clicker;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenters
{
    public class CoinsPresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Color _pickupColor;
        private Color _defaultColor;

        [Inject] private IWallet _wallet;

        private Sequence _currentSequence;

        private void OnEnable()
        {
            _wallet.ValueChanged += UpdateCoinsText;
            _defaultColor = _text.color;
        }

        private void OnDisable()
        {
            _wallet.ValueChanged -= UpdateCoinsText;
        }

        private void UpdateCoinsText(int newValue)
        {
            _text.SetText("{0}", newValue);
            PlayAnimation();
        }

        private void PlayAnimation()
        {
            _currentSequence?.Restart();

            _currentSequence = DOTween.Sequence()
                .Append(_text.transform.DOScale(endValue: Vector3.one * 1.1f
                    , duration: 0.1f))
                .Append(_text.transform.DOScale(endValue: Vector3.one
                    , duration: 0.1f));
        }
    }
}