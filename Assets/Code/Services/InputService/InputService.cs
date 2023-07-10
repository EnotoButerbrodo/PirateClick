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
        public event Action CameraRotationBreak;


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

            _input.Clicker.CameraDragInitial.performed += EnableCameraDrag;
            _input.Clicker.CameraDragInitial.canceled += DisableCameraDrag;
            
            _input.Clicker.CameraDragDelta.performed += UpdateCameraDrag;

            _input.Clicker.CameraDragInitial.performed += UpdateCameraBreak;
        }

        private void UpdateCameraBreak(InputAction.CallbackContext obj)
            => CameraRotationBreak?.Invoke();

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

        private void OnScreenTouch(InputAction.CallbackContext context)
        {
            ScreenTouch?.Invoke(_input.Clicker.ScreenTouch.ReadValue<Vector2>());
        }
    }
}