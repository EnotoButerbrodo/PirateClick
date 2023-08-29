using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class Coin : MonoBehaviour
    {
        public float StartSpeed = 2.5f;
        public float AccelerationPerSecond = 1f;
        public float RotationSpeed = 300f;
        public float MaxLiveTime = 10f;
        
        [SerializeField] private float _smallerDistance = 0.1f;
        [SerializeField] private float _smallerSpeed = 0.5f;

        [SerializeField] private Rigidbody _rigidbody;
        private RectTransform _coinPickupPosition;

        private float _speed;
        private Action<Coin> _onPicked;
        private Func<Vector3> _targetPositionSource;
        private TweenerCore<Vector3, Vector3, VectorOptions> _changeSizeTween;
        private TweenerCore<Vector3, Vector3, VectorOptions> _pickupTween;
        private float _liveTimer;
        private bool _enabled;
        

        public void SetTarget(Func<Vector3> positionSource, Action<Coin> onPicked)
        {
            _targetPositionSource = positionSource;
            _onPicked = onPicked;
            _speed = StartSpeed;
            
            transform.localScale = Vector3.zero;
            _changeSizeTween?.Kill();
            _changeSizeTween = transform
                .DOScale(Vector3.one, _smallerSpeed)
                .SetLink(gameObject);

            _liveTimer = MaxLiveTime;
            _enabled = true;
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

            if ((distanceToTarget <= _smallerDistance || _liveTimer <= 0) 
                && !_pickupTween.IsActive())
            {
                _pickupTween?.Kill();
                _pickupTween = transform
                    .DOScale(Vector3.zero, _smallerSpeed)
                    .SetLink(gameObject)
                    .OnKill(Pickup);
            }

            _speed += AccelerationPerSecond * Time.deltaTime;
            _liveTimer -= Time.deltaTime;
            _rigidbody.AddTorque(transform.up * RotationSpeed * Time.deltaTime);
        }

        private void Pickup()
        {
            _onPicked.Invoke(this);
            Destroy(gameObject);
        }
    }
}