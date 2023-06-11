using Code.Services.InputService;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class Clicker : MonoBehaviour
    {
        [SerializeField] private ClickService _clickService;
        
        [Inject] private IInputService _inputService;
        [Inject] private IWallet _wallet;


        private void OnEnable()
        {
            _inputService.ScreenTouch += HandleClick;
            _inputService.SetEnabled(isEnabled: true);
        }

        private void OnDisable()
        {
            _inputService.ScreenTouch -= HandleClick;
            _inputService.SetEnabled(isEnabled: false);
        }

        private void HandleClick(Vector2 touchPosition)
        {
            if (_clickService.CheckPosition(touchPosition, out IClickable clickable))
            {
                clickable.React();
            }
        }
    }
}