using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class CoinPicker : MonoBehaviour
    {
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private RectTransform _coinPickupPosition;
        [SerializeField] private float _coinSpeed;
            
        [Inject] private IWallet _wallet;
        [Inject] private ClickerEvents _clickerEvents;

        private Camera _camera;
       

        private void Start()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _clickerEvents.CoinEarned += OnCoinEarned;
        }

        private void OnDisable()
        {
            _clickerEvents.CoinEarned -= OnCoinEarned;
        }

        private void OnCoinEarned(Vector3 earnWorldPosition)
        {
            
            var coin = Instantiate(_coinPrefab
                , earnWorldPosition
                , Quaternion.identity);

            StartCoroutine(CoinPickupCoroutine(coin));
        }

        private IEnumerator CoinPickupCoroutine(GameObject coin)
        {
            bool isTargetReached;

            while (true)
            {
                var targetPivot = _coinPickupPosition.pivot;
                
                var targetViewportPosition = new Vector3(
                      targetPivot.x
                    , targetPivot.y
                    , _camera.nearClipPlane);

                var targetWorldPosition = _camera.ViewportToWorldPoint(targetViewportPosition);

                var coinPosition = coin.transform.position;

                var offset = Vector3.MoveTowards(coinPosition, targetWorldPosition, Time.deltaTime * _coinSpeed);
                coin.transform.position = offset;
                

                if (Vector3.Distance(targetWorldPosition, coinPosition) <= 0.1f)
                {
                    break;
                }

                yield return null;
            }
            OnCoinGetted(coin);
        }

        private void OnCoinGetted(GameObject coin)
        {
            Destroy(coin);
            _wallet.Add(1);
        }
    }
}