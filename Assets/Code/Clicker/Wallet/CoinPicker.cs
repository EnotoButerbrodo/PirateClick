using System.Collections;
using Services;
using UnityEngine;
using Zenject;

namespace Code.Clicker
{
    public class CoinPicker : MonoBehaviour
    {
        [SerializeField] private CoinFactory _coinFactory;
        [SerializeField] private RectTransform _coinPickupPosition;
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
            _clickerEvents.CoinPicked += OnCoinPickup;
        }

        private void OnDisable()
        {
            _clickerEvents.CoinEarned -= OnCoinEarned;
        }

        private void OnCoinEarned(int count, ICoinsSource coinsSource)
        {
            StartCoroutine(CoinsEarnCoroutine(count, coinsSource));
        }

        private IEnumerator CoinsEarnCoroutine(int coinsCount, ICoinsSource coinsSource)
        {
            var waiter = new WaitForSeconds(1f / coinsCount);
            for (int i = 0; i < coinsCount; i++)
            {
                var coin = _coinFactory.Get(coinsSource.GetRandomEarnPosition());
                coin.SetTarget(_coinPickupPosition);
                yield return waiter;
            }   
        }
        

        private void OnCoinPickup(Coin coin)
        {
            _audio.PlayOneShot(_pickupAudio, 0.5f);
            _wallet.Add(1);
        }
    }
}