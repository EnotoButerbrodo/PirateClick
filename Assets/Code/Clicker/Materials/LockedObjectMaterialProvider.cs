using UnityEngine;

namespace Code.Clicker
{
    public class LockedObjectMaterialProvider : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;

        private Material _material;

        private float Opacity
        {
            get => _material.color.a;
            set
            {
                var color = _material.color;
                color.a = value;
                _material.color = color;
            }
        }
        private void Awake()
        {
            _material = _renderer.sharedMaterial;
        }
    
        public void Unlock()
        {
            Opacity = 1f;
        }

        public void Lock()
        {
            Opacity = 0.5f;
        }
    }
}