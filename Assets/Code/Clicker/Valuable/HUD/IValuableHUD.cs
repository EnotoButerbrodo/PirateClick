namespace Code.Clicker.HUD
{
    public interface IValuableHUD
    {
        void UpdateReloadBar(float percent);
        void ShowReloadBar();
        void HideReloadBar();
    }
}