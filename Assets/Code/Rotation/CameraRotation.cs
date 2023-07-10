using System;
using Code.Services.InputService;
using UnityEngine;
using Zenject;

namespace Code.Levels.Clicker
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField][Range(100f, 1000000f)] private float _sensivity = 1f;
        [SerializeField][Range(0, 0.01f)] private float _rotationDeadZone = 1f;
        [SerializeField] private float _brakeForce = 5f;
        [SerializeField] private Rigidbody _rigidbody;
        [Inject] private IInputService _input;

        private Camera _camera;

        private float _defaultDrag;

        private void Start()
        {
            _camera = Camera.main;
            _defaultDrag = _rigidbody.angularDrag;
        }

        private void OnEnable()
        {
            _input.CameraDrag += RotateCamera;
        }

        private void Update()
        {
            _rigidbody.angularDrag = _input.CameraDragButtonPressed
                ? _brakeForce
                : _defaultDrag;
        }

        private void OnDisable()
        {
            _input.CameraDrag += RotateCamera;
        }

        private void RotateCamera(Vector2 rotation)
        {
            var normalizedDrag = rotation.x / _camera.pixelWidth;

            if(Mathf.Abs(normalizedDrag) <= _rotationDeadZone)
                return;
            
            var rotationOffset = normalizedDrag * Time.deltaTime * _sensivity;
            _rigidbody.AddTorque(Vector3.up * rotationOffset, ForceMode.VelocityChange);  
        }
    }
}