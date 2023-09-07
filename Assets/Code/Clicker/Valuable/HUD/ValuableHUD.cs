using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Clicker.HUD
{
    public class ValuableHUD : HUDScreen, IValuableHUD
    {
        [SerializeField] private Valuable _valuable;
        [SerializeField] private ReloadBar _coinsReloadBar;
        [SerializeField] private TextMeshProUGUI _availableCoins;
        [SerializeField] private Animation _spawnAnimation;
        [SerializeField] private Button _reloadUpgrateButton;
    
        public ReloadBar CoinsReloadBar => _coinsReloadBar;

        public void Spawn()
        {
            _spawnAnimation.Play();
        }
        
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