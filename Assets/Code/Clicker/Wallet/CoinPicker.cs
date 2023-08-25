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

        [SerializeField] private Vector3 _spendPositionRandomOffset;
            
        [Inject] private IWallet _wallet;
        [Inject] private ClickerEvents _clickerEvents;
        [Inject] private IAudioService _audio;

        private Camera _camera;
        
        public Vector3 GetTargetWorldPosition()
        {
            var targetPivot = _coinPickupPosition.pivot;
                
            var targetViewportPosition = new Vector3(
                targetPivot.x
                , targetPivot.y
                , _camera.nearClipPlane);

            Vector3 targetWorldPosition = _camera.ViewportToWorldPoint(targetViewportPosition);
            
            return targetWorldPosition;
        }
        private void Start()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _clickerEvents.CoinEarned += OnCoinEarned;
            _clickerEvents.ValuableUnlocked += OnValuableUnlock;
        }
        
        private void OnDisable()
        {
            _clickerEvents.CoinEarned -= OnCoinEarned;
            _clickerEvents.ValuableUnlocked -= OnValuableUnlock;
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
                var coin = _coinFactory.GetCoin(coinsSource.GetRandomEarnPosition());
                coin.SetTarget(GetTargetWorldPosition, OnCoinWalletPickup);
                yield return waiter;
            }   
        }

        private void OnCoinWalletPickup(Coin coin)
        {
            _audio.PlayOneShot(_pickupAudio, 0.5f);
            _wallet.Add(1);
        }
        
        private void OnValuableUnlock(int cost, ILockedObject unlockedobject)
        {
            StartCoroutine(UnlockCoroutine(cost, unlockedobject));
        }

        private IEnumerator UnlockCoroutine(int cost, ILockedObject unlockedObject)
        {
            var waiter = new WaitForSeconds(0.1f);
            for (int i = 0; i < cost; i++)
            {
                var spawnPosition = GetTargetWorldPosition();
                spawnPosition += GetSpendRandomOffset();
                Coin coin = _coinFactory.GetCoin(spawnPosition);
                coin.SetTarget(() => unlockedObject.Position
                    , (c) => OnCoinUnlockReached(unlockedObject));
                
                yield return waiter;
            }   
        }

        private void OnCoinUnlockReached(ILockedObject unlockedObject)
        {
            unlockedObject.GetCoin();
            _audio.PlayOneShot(_pickupAudio, 0.5f);
        }

        
        private Vector3 GetSpendRandomOffset()
        {
            return new Vector3(
                Random.Range(-_spendPositionRandomOffset.x, _spendPositionRandomOffset.x)
                , Random.Range(-_spendPositionRandomOffset.y, _spendPositionRandomOffset.y)
                ,Random.Range(-_spendPositionRandomOffset.z, _spendPositionRandomOffset.z));

        }
        
    }
}