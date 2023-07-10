using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Services.InputService
{
    public class InputService : IInputService
    {
        public event Action<Vector2> ScreenTouch;
        public event Action<Vector2> CameraDrag;


        public bool CameraDragButtonPressed
            => _input.Clicker.CameraDragInitial.IsPressed();
        

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

            _input.Clicker.ScreenTouch.started += OnScreenTouch;
            _input.Clicker.MouseClick.started += OnMouse;

            _input.Clicker.CameraDragInitial.performed += EnableCameraDrag;
            _input.Clicker.CameraDragInitial.canceled += DisableCameraDrag;
            
            _input.Clicker.CameraDragDelta.performed += UpdateCameraDrag;
        }


        private void OnScreenTouch(InputAction.CallbackContext context)
        {
            ScreenTouch?.Invoke(_input.Clicker.ScreenTouchPosition.ReadValue<Vector2>());
        }

        private void UpdateCameraDrag(InputAction.CallbackContext obj)
        {
            var drag = _dragInital
                ? _input.Clicker.CameraDragDelta.ReadValue<Vector2>()
                : Vector2.zero;

            CameraDrag?.Invoke(drag);
        }

        private void DisableCameraDrag(InputAction.CallbackContext obj) 
            => _dragInital = false;

        private void EnableCameraDrag(InputAction.CallbackContext obj) 
            => _dragInital = true;

        private void OnMouse(InputAction.CallbackContext obj)
        {
            ScreenTouch?.Invoke(_input.Clicker.MousePosition.ReadValue<Vector2>());
        }
    }
}