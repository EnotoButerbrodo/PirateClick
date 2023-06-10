using Code.Services.InputService;
using UnityEngine;

namespace Code.Clicker
{
    public class Clicker : MonoBehaviour
    {
        public int ClickMoneyAmount = 1;
        
        [SerializeField] private ClickService _clickService;
        private IInputService _inputService;
        
        private Wallet _wallet;
        
        private void Awake()
        {
            _inputService = new InputService();
            _wallet = new Wallet();

        }
        
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
                _wallet.Add(ClickMoneyAmount);
            }
        }
    }
}