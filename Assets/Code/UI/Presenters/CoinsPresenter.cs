using System;
using Code.Clicker;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI.Presenters
{
    public class CoinsPresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [Inject] private IWallet _wallet;

        private void OnEnable()
        {
            _wallet.ValueChanged += UpdateCoinsText;
        }

        private void OnDisable()
        {
            _wallet.ValueChanged -= UpdateCoinsText;
        }

        private void UpdateCoinsText(int newValue)
        {
            _text.SetText("{0}", newValue);
        }
    }
}