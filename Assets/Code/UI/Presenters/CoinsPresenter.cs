using System.Collections;
using Code.Clicker;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenters
{
    public class CoinsPresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Color _pickupColor;
        [SerializeField] private float _reduceTickDelay = 0.1f;

        [Inject] private IWallet _wallet;

        private Color _defaultColor;
        private int _currentMoney;

        private Sequence _currentSequence;
        private TweenerCore<int, int, NoOptions> _reduceTween;

        private int Moneys
        {
            get => _currentMoney;
            set
            {
                _currentMoney = value;
                _text.SetText("{0}", _currentMoney);
            }
        }

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
            var difference = newValue - Moneys;
            if (difference > 0)
            {
                Moneys = newValue;
                PlayRaiseAnimation();    
            }
            else
            {
                PlayReductionAnimation(newValue);
            }
        }

        private void PlayReductionAnimation(int reducedValue)
        {
            _currentSequence?.Kill();
            
            _currentSequence = DOTween.Sequence()
                .Append(_text.transform.DOScale(endValue: Vector3.one * 0.8f
                    , duration: 0.1f))
                .Append(DOTween.To
                (
                    ()=> Moneys
                    , x => Moneys = x
                    , reducedValue
                    , _reduceTickDelay
                ))
                .Append(_text.transform.DOScale(endValue: Vector3.one
                    , duration: 0.1f));
        }
        

        private void PlayRaiseAnimation()
        {
            _currentSequence?.Kill();

            _currentSequence = DOTween.Sequence()
                .Append(_text.transform.DOScale(endValue: Vector3.one * 1.1f
                    , duration: 0.1f))
                .Append(_text.transform.DOScale(endValue: Vector3.one
                    , duration: 0.1f));
        }
    }
}