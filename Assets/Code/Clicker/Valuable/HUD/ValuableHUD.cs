using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Clicker.HUD
{
    public class ValuableHUD : MonoBehaviour, IValuableHUD
    {
        [SerializeField] private Valuable _valuable;
        [SerializeField] private ValuableUpgrates _upgrates;
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
            _reloadUpgrateButton.onClick.AddListener(OnReloadUpgrade);
        }

        private void OnReloadUpgrade()
        {
            if(_upgrates.HasReloadUpgrade())
                _upgrates.UpgrateReload();
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