using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Services.InputService
{
    public class InputService : IInputService
    {
        public event Action<Vector2> ScreenTouch;

        private InputScheme _input;

        public void SetEnabled(bool isEnabled)
        {
            if (isEnabled)
                _input.Clicker.Enable();
            else
                _input.Clicker.Disable();
        }

        public InputService()
        {
            _input = new InputScheme();

            _input.Clicker.ScreenTouch.performed += OnScreenTouch;
            _input.Clicker.MouseClick.started += OnMouse; 
        }

        private void OnMouse(InputAction.CallbackContext obj)
        {
            ScreenTouch?.Invoke(_input.Clicker.MousePosition.ReadValue<Vector2>());
        }

        private void OnScreenTouch(InputAction.CallbackContext context)
        {
            ScreenTouch?.Invoke(_input.Clicker.ScreenTouch.ReadValue<Vector2>());
        }
    }
}