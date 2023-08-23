using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Code.Clicker.HUD
{
    public class ValuableHUD : MonoBehaviour, IValuableHUD
    {
        [SerializeField] private Valuable _valuable;
        [SerializeField] private ReloadBar _coinsReloadBar;
        [SerializeField] private TextMeshProUGUI _availableCoins;
        

        public ReloadBar CoinsReloadBar => _coinsReloadBar;

        private void OnEnable()
        {
            _valuable.AvailableCoinsChanged += OnCoinsChanged;
        }

        private void OnCoinsChanged(int coins)
        {
            _availableCoins.text = coins.ToString();
        }

        private void OnDisable()
        {
            _valuable.AvailableCoinsChanged -= OnCoinsChanged;
        }
    }
}