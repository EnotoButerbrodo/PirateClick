using Code.Services.InputService;
using UnityEngine;

namespace Code.Clicker
{
    public class Clicker : MonoBehaviour
    {
        [SerializeField] private LayerMask _clickableLayer;
        [SerializeField][Range(0f, 500f)] private float _raycastLenght = 10f;

        private RaycastHit[] _clickCastResults = new RaycastHit[1];
        private Camera _camera;
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = new InputService();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _inputService.ScreenTouch += Click;
            _inputService.SetClickerInputState(isEnabled: true);
        }

        private void OnDisable()
        {
            _inputService.ScreenTouch -= Click;
            _inputService.SetClickerInputState(isEnabled: false);
        }

        private void Click(Vector2 touchPosition)
        {
            Ray clickRay = _camera.ScreenPointToRay(touchPosition);
            
            int clickedObjectCount = Physics.RaycastNonAlloc(
                ray: clickRay
                , results: _clickCastResults
                , maxDistance: _raycastLenght
                , layerMask: _clickableLayer);

            if (clickedObjectCount > 0)
            {
                if (_clickCastResults[0].collider.TryGetComponent<IClickable>(out var clicable))
                {
                    clicable.React();
                }
            }
        }
    }
}