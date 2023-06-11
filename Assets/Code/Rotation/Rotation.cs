using UnityEngine;

namespace Code.Levels.Clicker
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField][Range(0, 500f)] private float _rotationSpeed = 5f;
        
        private void Update()
        {
            RotateObject();
        }

        private void RotateObject()
        {
            var rotationSpeed = _rotationSpeed * Time.deltaTime;
            
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed, Vector3.up);
        }
    }
}