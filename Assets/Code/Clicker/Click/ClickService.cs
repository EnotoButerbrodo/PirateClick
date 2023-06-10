using System;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class ClickService : MonoBehaviour
    {
        [SerializeField] private LayerMask _clickableLayer;
        [SerializeField][Range(0f, 500f)] private float _raycastLenght = 10f;

        private RaycastHit[] _clickCastResults = new RaycastHit[1];
        private Camera _camera;
        
        private void Start()
        {
            _camera = Camera.main;
        }

        public bool CheckPosition(Vector2 touchPosition, out IClickable clickable)
        {
            clickable = null;
            
            Ray clickRay = _camera.ScreenPointToRay(touchPosition);
            
            int clickedObjectCount = Physics.RaycastNonAlloc(
                ray: clickRay
                , results: _clickCastResults
                , maxDistance: _raycastLenght
                , layerMask: _clickableLayer);
            
            if (clickedObjectCount > 0  
                && _clickCastResults[0].collider.TryGetComponent<IClickable>(out var result))
            {
                clickable = result;
                return true;
            }

            return false;
        }
    }
}