using Code.Services.InputService;
using UnityEngine;
using Zenject;

namespace Code.Levels.Clicker
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField][Range(1f, 100f)] private float _sensivity = 1f;
        [SerializeField] private float _rotationDeadZone = 1f;
        [Inject] private IInputService _input;

        private void OnEnable()
        {
            _input.CameraDrag += RotateCamera;
        }

        private void OnDisable()
        {
            _input.CameraDrag += RotateCamera;
        }

        private void RotateCamera(Vector2 rotation)
        {
            if(Mathf.Abs(rotation.x) <= _rotationDeadZone)
                return;
            
            var rotationOffset = rotation.x * Time.deltaTime * _sensivity;
            transform.rotation *= Quaternion.AngleAxis(rotationOffset, Vector3.up);
        }
    }
}