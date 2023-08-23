using UnityEngine;

namespace Code.Clicker.HUD
{
    public class ValuableHUD : MonoBehaviour, IValuableHUD
    {

        [SerializeField] private ReloadBar _coinsReloadBar;

        public void ShowReloadBar()
        {
            _coinsReloadBar.Show();
        }

        public void HideReloadBar()
        {
            _coinsReloadBar.Hide();
        }
        
        public void UpdateReloadBar(float percent)
        {
            _coinsReloadBar.SetPercent(percent);
        }
    }
}