using UnityEngine;

namespace Code.Levels.Clicker
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField][Range(0, 500f)] private float _rotationSpeed = 5f;
        [SerializeField] private Vector3 _rotationAxis = Vector3.up;
        private void Update()
        {
            RotateObject();
        }

        private void RotateObject()
        {
            var rotationSpeed = _rotationSpeed * Time.deltaTime;
            
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed, _rotationAxis);
        }
    }
}