using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class Coin : MonoBehaviour
    {
        public float StartSpeed = 2.5f;
        public float AccelerationPerSecond = 1f;
        public float RotationSpeed = 300f;
        
        [SerializeField] private float _smallerDistance = 0.1f;
        [SerializeField] private float _smallerSpeed = 0.5f;

        [SerializeField] private Rigidbody _rigidbody;
        [Inject] private ClickerEvents _events;
        private RectTransform _coinPickupPosition;
        private Camera _camera;

        private float _speed;

        public void Initialize(Camera camera)
        {
            _camera = camera;
        }

        public void SetTarget(RectTransform target)
        {
            _coinPickupPosition = target;
            _speed = StartSpeed;
        }
        
        private void Update()
        {
            Vector3 targetWorldPosition = GetTargetWorldPosition();
            Vector3 coinPosition = transform.position;
                
            Vector3 newCoinPosition = Vector3.MoveTowards(coinPosition
                , targetWorldPosition
                , _speed * Time.deltaTime);
                
            _rigidbody.MovePosition(newCoinPosition);

            var distanceToTarget = Vector3.Distance(targetWorldPosition, coinPosition);

            if (distanceToTarget <= _smallerDistance)
            {
                transform
                    .DOScale(Vector3.zero, _smallerSpeed)
                    .SetLink(gameObject);
            }
            if (distanceToTarget <= 0.05f)
            {
                Pickuped();
            }

            _speed += AccelerationPerSecond * Time.deltaTime;
            _rigidbody.AddTorque(transform.up * RotationSpeed * Time.deltaTime);
        }

        private void Pickuped()
        {
            _events.CallCoinPicked(this);
            Destroy(gameObject);
        }

        private Vector3 GetTargetWorldPosition()
        {
            var targetPivot = _coinPickupPosition.pivot;
                
            var targetViewportPosition = new Vector3(
                targetPivot.x
                , targetPivot.y
                , _camera.nearClipPlane);

            Vector3 targetWorldPosition = _camera.ViewportToWorldPoint(targetViewportPosition);
            
            return targetWorldPosition;
        }
    }
}