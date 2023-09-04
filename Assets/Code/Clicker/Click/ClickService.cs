using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Code.Clicker
{
    public class ClickService : MonoBehaviour
    {
        [SerializeField] private LayerMask _clickableLayer;
        [SerializeField][Range(0f, 500f)] private float _raycastLenght = 10f;
        
        [Inject] private ClickerEvents _events;
        
        private readonly RaycastHit[] _clickCheckResults = new RaycastHit[1];
        private Camera _camera;
        
        private void Start()
        {
            _camera = Camera.main;
        }

        public bool TryFindClickableObjectAtPosition(Vector2 touchPosition, out IClickable clickableObject)
        {
            
            clickableObject = null;
            
           
            
            Ray clickRay = _camera.ScreenPointToRay(touchPosition);
            
            int findedObjectsCount = Physics.RaycastNonAlloc(
                ray: clickRay
                , results: _clickCheckResults
                , maxDistance: _raycastLenght
                , layerMask: _clickableLayer.value);

            if (findedObjectsCount == 0)
                return false;

            var potentialClickableObject = _clickCheckResults[0];

            if (potentialClickableObject.collider.TryGetComponent<IClickable>(out clickableObject))
            {
                _events.CallClickableClicked(potentialClickableObject.point, clickableObject);
                return true;
            }

            return false;
        }
    }
}