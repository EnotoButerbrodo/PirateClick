using System;
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
        private RectTransform _coinPickupPosition;

        private float _speed;
        private Action<Coin> _onPicked;
        private Func<Vector3> _targetPositionSource;

        public void SetTarget(Func<Vector3> positionSource, Action<Coin> onPicked)
        {
            _targetPositionSource = positionSource;
            _onPicked = onPicked;
            _speed = StartSpeed;
        }
        
        private void Update()
        {
            Vector3 targetWorldPosition = _targetPositionSource.Invoke();
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
                _onPicked.Invoke(this);
                Destroy(gameObject);
            }

            _speed += AccelerationPerSecond * Time.deltaTime;
            _rigidbody.AddTorque(transform.up * RotationSpeed * Time.deltaTime);
        }
    }
}