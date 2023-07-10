using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Services.InputService
{
    public class InputService : IInputService
    {
        public event Action<Vector2> ScreenTouch;
        public event Action<Vector2> CameraDrag;

        private InputScheme _input;
        private bool _dragInital;

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

            _input.Clicker.CameraDragInitial.performed += (c) => _dragInital = true;
            _input.Clicker.CameraDragInitial.canceled += (c) => _dragInital = false;
            _input.Clicker.CameraDragDelta.performed += UpdateCameraDrag;
        }

        private void UpdateCameraDrag(InputAction.CallbackContext obj)
        {
            if(_dragInital == false)
                return;
            
            var mouseDrag = _input.Clicker.CameraDragDelta.ReadValue<Vector2>();
            CameraDrag?.Invoke(mouseDrag);
            Debug.Log("Rotation " + mouseDrag);

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