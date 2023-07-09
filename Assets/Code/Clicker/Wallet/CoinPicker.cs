using System.Collections;
using Services;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class CoinPicker : MonoBehaviour
    {
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private RectTransform _coinPickupPosition;
        [SerializeField] private float _coinSpeed;
        [SerializeField] private AudioClip _pickupAudio;
            
        [Inject] private IWallet _wallet;
        [Inject] private ClickerEvents _clickerEvents;
        [Inject] private IAudioService _audio;

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
            while (true)
            {
                var targetWorldPosition = GetTargetWorldPosition();
                var coinPosition = coin.transform.position;
                
                var newCoinPosition = Vector3.MoveTowards(coinPosition
                    , targetWorldPosition
                    , _coinSpeed * Time.deltaTime);
                
                coin.transform.position = newCoinPosition;

                if (Vector3.Distance(targetWorldPosition, coinPosition) <= 0.1f)
                {
                    break;
                }

                yield return null;
            }
            
            OnCoinPickup(coin);
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

        private void OnCoinPickup(GameObject coin)
        {
            _clickerEvents.CallCoinPicked();
            _audio.Play(_pickupAudio);
            Destroy(coin);
            _wallet.Add(1);
        }
    }
}